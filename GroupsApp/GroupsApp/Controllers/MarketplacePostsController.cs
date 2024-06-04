using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GroupsApp.Data;
using GroupsApp.Models.MarketplacePosts;
using GroupsApp.Services;
using GroupsApp.Models;
using GroupsApp.Mapper;
using System.Security.Claims;

namespace GroupsApp.Controllers
{
    public class MarketplacePostsController : Controller
    {
        private readonly IPostService postService;
        private readonly IGroupService groupService;
        private readonly IUserService userService;

        public MarketplacePostsController(IPostService postService, IGroupService groupService, IUserService userService)
        {
            this.postService = postService;
            this.groupService = groupService;
            this.userService = userService;
        }

        // GET: MarketplacePosts
        public async Task<IActionResult> Index()
        {
            return View(postService.GetMarketplacePosts());
        }

        // GET: MarketplacePosts/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marketplacePost = postService.GetMarketplacePostById(id.Value);

            if (marketplacePost == null)
            {
                return NotFound();
            }

            return View(marketplacePost);
        }

        // GET: MarketplacePosts/Create
        public IActionResult Create()
        {
            var users = userService.GetUsers().Value;
            var groups = groupService.GetAllGroups();

            ViewData["AuthorId"] = new SelectList(users, "UserId", "UserId");
            ViewData["GroupId"] = new SelectList(groups, "GroupId", "GroupId");

            return View();
        }
        
        // GET: MarketplacePosts/CreateDonationPost
        public IActionResult CreateDonationPost()
        {
            var users = userService.GetUsers().Value;
            var groups = groupService.GetAllGroups();

            ViewData["AuthorId"] = new SelectList(users, "UserId", "UserId");
            ViewData["GroupId"] = new SelectList(groups, "GroupId", "GroupId");

            return View();
        }

        public IActionResult CreateFixedPricePost()
        {
            var users = userService.GetUsers().Value;
            var groups = groupService.GetAllGroups();

            ViewData["AuthorId"] = new SelectList(users, "UserId", "UserId");
            ViewData["GroupId"] = new SelectList(groups, "GroupId", "GroupId");

            return View();
        }
        
        public IActionResult CreateAuctionPost()
        {
            var users = userService.GetUsers().Value;
            var groups = groupService.GetAllGroups();

            ViewData["AuthorId"] = new SelectList(users, "UserId", "UserId");
            ViewData["GroupId"] = new SelectList(groups, "GroupId", "GroupId");

            return View();
        }

        [HttpPost]
        public IActionResult AddToFavorites(Guid id)
        {
            var userId = Guid.Parse("2fda6ef7-ca09-4c63-9c25-dd4e31f67374");

            try
            {
                userService.AddPostToFavorites(id, userId);
                return RedirectToAction("Index", "UsersFavoritePosts");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "MarketplacePosts");
            }
        }

        // POST: MarketplacePosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,MediaContent,Location,CreationDate,EndDate,IsPromoted,IsActive")] MarketplacePost marketplacePost)
        {
            marketplacePost.Type = "Donation"; // TODO don't hardcode these
            marketplacePost.GroupId = Guid.Parse("9f7061d4-a193-4e63-87f1-8fc4c2251aed");
            marketplacePost.AuthorId = Guid.Parse("2fda6ef7-ca09-4c63-9c25-dd4e31f67374");

            postService.AddMarketplacePost(MarketplacePostMapper.MapMarketplacePostToMarketplacePostDTO(marketplacePost));  // TODO avoid this

            return RedirectToAction(nameof(Index));
        }

        // POST: MarketplacePosts/CreateDonationPost
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDonationPost
            ([Bind("Title,Description,MediaContent,Location,CreationDate,EndDate,IsPromoted,IsActive,DonationLink")]
        DonationPost donationPost)
        {
            donationPost.Type = "Donation"; 
            donationPost.GroupId = Guid.Parse("1ae4795d-c170-4b7e-ba40-681b6f9993f5");
            donationPost.AuthorId = Guid.Parse("4f02e552-c02b-48d4-8d7c-1162bcdab88c");

            postService.AddMarketplacePost(donationPost);

            return RedirectToAction(nameof(Index));
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFixedPricePost
            ([Bind("Title,Description,MediaContent,Location,CreationDate,EndDate,IsPromoted,IsActive,Price")]
        FixedPricePost fixedPricePost)
        {
            fixedPricePost.Type = Constants.FIXED_PRICE_POST_TYPE;
            fixedPricePost.GroupId = Guid.Parse("1ae4795d-c170-4b7e-ba40-681b6f9993f5");
            fixedPricePost.AuthorId = Guid.Parse("4f02e552-c02b-48d4-8d7c-1162bcdab88c");

            postService.AddMarketplacePost(fixedPricePost);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAuctionPost
            ([Bind("Title,Description,MediaContent,Location,CreationDate,EndDate,IsPromoted,IsActive,MinimumBidPrice")]
        AuctionPost auctionPost)
        {
            auctionPost.Type = Constants.AUCTION_POST_TYPE;
            auctionPost.GroupId = Guid.Parse("1ae4795d-c170-4b7e-ba40-681b6f9993f5");
            auctionPost.AuthorId = Guid.Parse("4f02e552-c02b-48d4-8d7c-1162bcdab88c");

            postService.AddMarketplacePost(auctionPost);

            return RedirectToAction(nameof(Index));
        }


        // GET: MarketplacePosts/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marketplacePost = postService.GetMarketplacePostById(id.Value);

            if (marketplacePost == null)
            {
                return NotFound();
            }

            return View(marketplacePost);
        }

        // POST: MarketplacePosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var marketplacePost = postService.GetMarketplacePostById(id);
            if (marketplacePost != null)
            {
                postService.RemoveMarketplacePost(MarketplacePostMapper.MapMarketplacePostToMarketplacePostDTO(marketplacePost));
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult GetFields(string type)
        {
            switch (type)
            {
                case "Donation":
                    return PartialView("_DonationFields");
                case "FixedPrice":
                    return PartialView("_FixedPriceFields");
                case "Auction":
                    return PartialView("_AuctionFields");
                default:
                    return Content("Invalid post type");
            }
        }


        private bool MarketplacePostExists(Guid id)
        {
            return postService.GetMarketplacePostById(id) != null;
        }
    }
}
