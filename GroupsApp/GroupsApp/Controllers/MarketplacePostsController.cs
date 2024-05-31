using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GroupsApp.Data;
using GroupsApp.Models.MarketplacePosts;

namespace GroupsApp.Controllers
{
    public class MarketplacePostsController : Controller
    {
        private readonly GroupsAppContext _context;

        public MarketplacePostsController(GroupsAppContext context)
        {
            _context = context;
        }

        // GET: MarketplacePosts
        public async Task<IActionResult> Index()
        {
            var groupsAppContext = _context.MarketplacePosts.Include(m => m.Author).Include(m => m.Group);
            return View(await groupsAppContext.ToListAsync());
        }

        // GET: MarketplacePosts/Details/5
        public async Task<IActionResult> Details(Guid? id)
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
        public async Task<IActionResult> Create([Bind("MarketplacePostId,AuthorId,GroupId,Title,Description,MediaContent,Location,CreationDate,EndDate,IsPromoted,IsActive,Type")] MarketplacePost marketplacePost)
        {
            if (ModelState.IsValid)
            {
                marketplacePost.MarketplacePostId = Guid.NewGuid();
                _context.Add(marketplacePost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Users, "UserId", "UserId", marketplacePost.AuthorId);
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "GroupId", marketplacePost.GroupId);
            return View(marketplacePost);
        }

        // GET: MarketplacePosts/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marketplacePost = await _context.MarketplacePosts.FindAsync(id);
            if (marketplacePost == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_context.Users, "UserId", "UserId", marketplacePost.AuthorId);
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "GroupId", marketplacePost.GroupId);
            return View(marketplacePost);
        }

        // POST: MarketplacePosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("MarketplacePostId,AuthorId,GroupId,Title,Description,MediaContent,Location,CreationDate,EndDate,IsPromoted,IsActive,Type")] MarketplacePost marketplacePost)
        {
            if (id != marketplacePost.MarketplacePostId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(marketplacePost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarketplacePostExists(marketplacePost.MarketplacePostId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Users, "UserId", "UserId", marketplacePost.AuthorId);
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "GroupId", marketplacePost.GroupId);
            return View(marketplacePost);
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
