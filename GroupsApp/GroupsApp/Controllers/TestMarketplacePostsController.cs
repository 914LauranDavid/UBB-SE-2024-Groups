using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GroupsApp.Data;
using GroupsApp.Models;

namespace GroupsApp.Controllers
{
    public class TestMarketplacePostsController : Controller
    {
        private readonly GroupsAppContext _context;

        public TestMarketplacePostsController(GroupsAppContext context)
        {
            _context = context;
        }

        // GET: TestMarketplacePosts
        public async Task<IActionResult> Index()
        {
            return View(await _context.TestMarketplacePost.ToListAsync());
        }

        // GET: TestMarketplacePosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testMarketplacePost = await _context.TestMarketplacePost
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testMarketplacePost == null)
            {
                return NotFound();
            }

            return View(testMarketplacePost);
        }

        // GET: TestMarketplacePosts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TestMarketplacePosts1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Type")] TestMarketplacePost testMarketplacePost)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testMarketplacePost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(testMarketplacePost);
        }

        // GET: TestMarketplacePosts1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testMarketplacePost = await _context.TestMarketplacePost.FindAsync(id);
            if (testMarketplacePost == null)
            {
                return NotFound();
            }
            return View(testMarketplacePost);
        }

        // POST: TestMarketplacePosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Type")] TestMarketplacePost testMarketplacePost)
        {
            if (id != testMarketplacePost.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testMarketplacePost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestMarketplacePostExists(testMarketplacePost.Id))
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
            return View(testMarketplacePost);
        }

        // GET: TestMarketplacePosts1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testMarketplacePost = await _context.TestMarketplacePost
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testMarketplacePost == null)
            {
                return NotFound();
            }

            return View(testMarketplacePost);
        }

        // POST: TestMarketplacePosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var testMarketplacePost = await _context.TestMarketplacePost.FindAsync(id);
            if (testMarketplacePost != null)
            {
                _context.TestMarketplacePost.Remove(testMarketplacePost);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestMarketplacePostExists(int id)
        {
            return _context.TestMarketplacePost.Any(e => e.Id == id);
        }
    }
}
