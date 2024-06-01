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

namespace GroupsApp.Controllers
{
    public class MarketplacePostsController : Controller
    {
        private readonly GroupsAppContext _context;
        private readonly IPostService postService;
        private readonly IGroupService groupService;
        private readonly IUserService userService;

        public MarketplacePostsController(GroupsAppContext context, IPostService postService, IGroupService groupService,
            IUserService userService)
        {
            _context = context;
            this.postService = postService;
            this.groupService = groupService;
            this.userService = userService;
        }

        // GET: MarketplacePosts
        public async Task<IActionResult> Index()
        {
            //var groupsAppContext = _context.MarketplacePosts.Include(m => m.Author).Include(m => m.Group);
            //return View(await groupsAppContext.ToListAsync());
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

            //var marketplacePost = await _context.MarketplacePosts
            //    .Include(m => m.Author)
            //    .Include(m => m.Group)
            //    .FirstOrDefaultAsync(m => m.MarketplacePostId == id);
            if (marketplacePost == null)
            {
                return NotFound();
            }

            return View(marketplacePost);
        }

        // GET: MarketplacePosts/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_context.Users, "UserId", "UserId");
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "GroupId");
            return View();
        }

        // POST: MarketplacePosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,MediaContent,Location,CreationDate,EndDate,IsPromoted,IsActive")] MarketplacePost marketplacePost)
        {
            marketplacePost.Type = "Donation"; // TODO don't hardcode these
            marketplacePost.GroupId = Guid.Parse("1ae4795d-c170-4b7e-ba40-681b6f9993f5");
            marketplacePost.AuthorId = Guid.Parse("4f02e552-c02b-48d4-8d7c-1162bcdab88c");

            postService.AddMarketplacePost(MarketplacePostMapper.MapMarketplacePostToMarketplacePostDTO(marketplacePost));  // TODO avoid this

            //_context.Add(marketplacePost);
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: MarketplacePosts/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marketplacePost = await _context.MarketplacePosts
                .Include(m => m.Author)
                .Include(m => m.Group)
                .FirstOrDefaultAsync(m => m.MarketplacePostId == id);
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
            var marketplacePost = await _context.MarketplacePosts.FindAsync(id);
            if (marketplacePost != null)
            {
                _context.MarketplacePosts.Remove(marketplacePost);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarketplacePostExists(Guid id)
        {
            return _context.MarketplacePosts.Any(e => e.MarketplacePostId == id);
        }
    }
}
