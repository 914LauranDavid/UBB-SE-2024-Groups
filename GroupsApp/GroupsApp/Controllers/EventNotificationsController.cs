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
    public class EventNotificationsController : Controller
    {
        private readonly GroupsAppContext _context;

        public EventNotificationsController(GroupsAppContext context)
        {
            _context = context;
        }

        // GET: EventNotifications
        public async Task<IActionResult> Index()
        {
            //TODO: return only the event notifications for the current user
            var groupsAppContext = _context.EventNotifications.Include(e => e.Event).Include(e => e.User);
            return View(await groupsAppContext.ToListAsync());
        }

        // GET: EventNotifications/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventNotification = await _context.EventNotifications
                .Include(e => e.Event)
                .Include(e => e.User)
                .FirstOrDefaultAsync(m => m.EventNotificationId == id);
            if (eventNotification == null)
            {
                return NotFound();
            }

            return View(eventNotification);
        }

        // GET: EventNotifications/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventNotification = await _context.EventNotifications
                .Include(e => e.Event)
                .Include(e => e.User)
                .FirstOrDefaultAsync(m => m.EventNotificationId == id);
            if (eventNotification == null)
            {
                return NotFound();
            }

            return View(eventNotification);
        }

        // POST: EventNotifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var eventNotification = await _context.EventNotifications.FindAsync(id);
            if (eventNotification != null)
            {
                _context.EventNotifications.Remove(eventNotification);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventNotificationExists(Guid id)
        {
            return _context.EventNotifications.Any(e => e.EventNotificationId == id);
        }
    }
}
