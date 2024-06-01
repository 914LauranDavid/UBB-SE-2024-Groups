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
    public class GroupPostsController : Controller
    {
        private readonly GroupsAppContext _context;

        public GroupPostsController(GroupsAppContext context)
        {
            _context = context;
        }

        // GET: GroupPosts
        public async Task<IActionResult> Index()
        {
            var groupsAppContext = _context.GroupPosts.Include(g => g.Author).Include(g => g.Group);
            return View(await groupsAppContext.ToListAsync());
        }

        // GET: GroupPosts/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupPost = await _context.GroupPosts
                .Include(g => g.Author)
                .Include(g => g.Group)
                .FirstOrDefaultAsync(m => m.GroupPostId == id);
            if (groupPost == null)
            {
                return NotFound();
            }

            return View(groupPost);
        }

        // GET: GroupPosts/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_context.Users, "UserId", "UserId");
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "GroupId");
            return View();
        }

        // POST: GroupPosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GroupPostId,AuthorId,GroupId,Description,MediaContent,IsPinned,AdminOnly")] GroupPost groupPost)
        {
            if (ModelState.IsValid)
            {
                groupPost.GroupPostId = Guid.NewGuid();
                _context.Add(groupPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Users, "UserId", "UserId", groupPost.AuthorId);
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "GroupId", groupPost.GroupId);
            return View(groupPost);
        }

        // GET: GroupPosts/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupPost = await _context.GroupPosts.FindAsync(id);
            if (groupPost == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_context.Users, "UserId", "UserId", groupPost.AuthorId);
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "GroupId", groupPost.GroupId);
            return View(groupPost);
        }

        // POST: GroupPosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("GroupPostId,AuthorId,GroupId,Description,MediaContent,IsPinned,AdminOnly")] GroupPost groupPost)
        {
            if (id != groupPost.GroupPostId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groupPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupPostExists(groupPost.GroupPostId))
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
            ViewData["AuthorId"] = new SelectList(_context.Users, "UserId", "UserId", groupPost.AuthorId);
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "GroupId", groupPost.GroupId);
            return View(groupPost);
        }

        // GET: GroupPosts/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupPost = await _context.GroupPosts
                .Include(g => g.Author)
                .Include(g => g.Group)
                .FirstOrDefaultAsync(m => m.GroupPostId == id);
            if (groupPost == null)
            {
                return NotFound();
            }

            return View(groupPost);
        }

        // POST: GroupPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var groupPost = await _context.GroupPosts.FindAsync(id);
            if (groupPost != null)
            {
                _context.GroupPosts.Remove(groupPost);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupPostExists(Guid id)
        {
            return _context.GroupPosts.Any(e => e.GroupPostId == id);
        }
    }
}
