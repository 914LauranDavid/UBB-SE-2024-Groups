﻿using System;
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

        // POST: MarketplacePosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,MediaContent,Location,CreationDate,EndDate,IsPromoted,IsActive")] MarketplacePost marketplacePost)
        {
            marketplacePost.GroupId = Guid.Parse("1ae4795d-c170-4b7e-ba40-681b6f9993f5");
            marketplacePost.AuthorId = Guid.Parse("4f02e552-c02b-48d4-8d7c-1162bcdab88c");

            switch (marketplacePost.Type)
            {
                case "Donation":
                    DonationPost donationPost = new DonationPost
                    {
                        Title = marketplacePost.Title,
                        Description = marketplacePost.Description,
                        MediaContent = marketplacePost.MediaContent,
                        Location = marketplacePost.Location,
                        CreationDate = marketplacePost.CreationDate,
                        EndDate = marketplacePost.EndDate,
                        IsPromoted = marketplacePost.IsPromoted,
                        IsActive = marketplacePost.IsActive,
                        DonationLink = "random link", // Initialize with default value
                        CurrentDonationAmount = 0 // Initialize with default value
                    };
                    postService.AddMarketplacePost(donationPost);
                    break;
                case "FixedPrice":
                    FixedPricePost fixedPricePost = new FixedPricePost
                    {
                        Title = marketplacePost.Title,
                        Description = marketplacePost.Description,
                        MediaContent = marketplacePost.MediaContent,
                        Location = marketplacePost.Location,
                        CreationDate = marketplacePost.CreationDate,
                        EndDate = marketplacePost.EndDate,
                        IsPromoted = marketplacePost.IsPromoted,
                        IsActive = marketplacePost.IsActive,
                        Price = 0, // Initialize with default value
                        IsNegotiable = false, // Initialize with default value
                        DeliveryType = "" // Initialize with default value
                    };
                    postService.AddMarketplacePost(fixedPricePost);
                    break;
                case "Auction":
                    AuctionPost auctionPost = new AuctionPost
                    {
                        Title = marketplacePost.Title,
                        Description = marketplacePost.Description,
                        MediaContent = marketplacePost.MediaContent,
                        Location = marketplacePost.Location,
                        CreationDate = marketplacePost.CreationDate,
                        EndDate = marketplacePost.EndDate,
                        IsPromoted = marketplacePost.IsPromoted,
                        IsActive = marketplacePost.IsActive,
                        CurrentPriceLeader = Guid.NewGuid(), // Initialize with default value
                        CurrentBidPrice = 0, // Initialize with default value
                        MinimumBidPrice = 0 // Initialize with default value
                    };
                    postService.AddMarketplacePost(auctionPost);
                    break;
                default:
                    // Handle error case where an invalid post type is selected
                    return RedirectToAction(nameof(Index));
            }

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
