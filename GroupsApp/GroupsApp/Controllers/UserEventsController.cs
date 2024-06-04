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
    public class UserEventsController : Controller
    {
        private readonly GroupsAppContext _context;

        public UserEventsController(GroupsAppContext context)
        {
            _context = context;
        }

        // GET: UserEvents
        public async Task<IActionResult> Index()
        {
            var groupsAppContext = _context.UserEvents.Include(u => u.Event).Include(u => u.User);
            return View(await groupsAppContext.ToListAsync());
        }

        // GET: UserEvents/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userEvent = await _context.UserEvents
                .Include(u => u.Event)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (userEvent == null)
            {
                return NotFound();
            }

            return View(userEvent);
        }

        // GET: UserEvents/Create
        public IActionResult Create()
        {
            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "EventId");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId");
            return View();
        }

        // POST: UserEvents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,EventId,Status")] UserEvent userEvent)
        {
            if (ModelState.IsValid)
            {
                userEvent.UserId = Guid.NewGuid();
                _context.Add(userEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "EventId", userEvent.EventId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", userEvent.UserId);
            return View(userEvent);
        }

        // GET: UserEvents/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userEvent = await _context.UserEvents.FindAsync(id);
            if (userEvent == null)
            {
                return NotFound();
            }
            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "EventId", userEvent.EventId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", userEvent.UserId);
            return View(userEvent);
        }

        // POST: UserEvents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("UserId,EventId,Status")] UserEvent userEvent)
        {
            if (id != userEvent.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userEvent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserEventExists(userEvent.UserId))
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
            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "EventId", userEvent.EventId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", userEvent.UserId);
            return View(userEvent);
        }

        // GET: UserEvents/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userEvent = await _context.UserEvents
                .Include(u => u.Event)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (userEvent == null)
            {
                return NotFound();
            }

            return View(userEvent);
        }

        // POST: UserEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var userEvent = await _context.UserEvents.FindAsync(id);
            if (userEvent != null)
            {
                _context.UserEvents.Remove(userEvent);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserEventExists(Guid id)
        {
            return _context.UserEvents.Any(e => e.UserId == id);
        }
    }
}
