using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GroupsApp.Data;
using GroupsApp.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Dynamic;

namespace GroupsApp.Controllers
{
    public class EventsController : Controller
    {
        private readonly GroupsAppContext _context;

        public EventsController(GroupsAppContext context)
        {
            _context = context;
        }

        // GET: Events
        public async Task<IActionResult> Index()
        {
            var groupsAppContext = _context.Events.Include(e => e.Organizer);
            return View(await groupsAppContext.Where(e => e.UnderInvestigation == false).ToListAsync());
        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events
                .Include(e => e.Organizer)
                .FirstOrDefaultAsync(m => m.EventId == id);

            var @Going = await _context.UserEvents
                .Include(e => e.Event)
                .Include(e => e.User)
                .FirstOrDefaultAsync(m => m.EventId == id && m.UserId == Guid.Parse("00000000-0000-0000-0000-000000000000"));

            if (@event == null)
            {
                return NotFound();
            }
            if (@Going == null)
            {
                ViewData["Going"] = "Not Going";
            }
            else
            {
                ViewData["Going"] = @Going.Status;
            }

            return View(@event);
        }

        // GET: Events/Create
        public IActionResult Create()
        {
            // TODO: replace seelct from front end with the guid of the logged in user
            // TODO: if the logged in user is not an organizer, do not allow them to modify/delete the event
            ViewData["OrganizerId"] = new SelectList(_context.Users, "UserId", "UserId");
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventId,OrganizerId,EventName,Categories,Location,MaxParticipants,Description,StartDate,EndDate,BannerURL,LogoURL,AgeLimit,EntryFee")] Event @event)
        {
            @event.Organizer = _context.Users.Find(@event.OrganizerId);
            ModelState["Organizer"].ValidationState = ModelValidationState.Valid;
            if (ModelState.IsValid)
            {
                @event.EventId = Guid.NewGuid();
                _context.Add(@event);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrganizerId"] = new SelectList(_context.Users, "UserId", "UserId", @event.OrganizerId);
            return View(@event);
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }
            ViewData["OrganizerId"] = new SelectList(_context.Users, "UserId", "UserId", @event.OrganizerId);
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("EventId,OrganizerId,EventName,Categories,Location,MaxParticipants,Description,StartDate,EndDate,BannerURL,LogoURL,AgeLimit,EntryFee")] Event @event)
        {
            if (id != @event.EventId)
            {
                return NotFound();
            }
            @event.Organizer = _context.Users.Find(@event.OrganizerId);
            ModelState["Organizer"].ValidationState = ModelValidationState.Valid;
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@event);


                    var users = _context.UserEvents.Where(e => e.EventId == @event.EventId && e.Status == "Going").ToList();
                    foreach (var user in users)
                    {
                        var notification = new EventNotification
                        {
                            EventNotificationId = Guid.NewGuid(),
                            EventId = @event.EventId,
                            UserId = user.UserId,
                            Message = "Event " + @event.EventName + " has been updated",
                        };
                        _context.EventNotifications.Add(notification);
                    }
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.EventId))
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
            ViewData["OrganizerId"] = new SelectList(_context.Users, "UserId", "UserId", @event.OrganizerId);
            return View(@event);
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events
                .Include(e => e.Organizer)
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var @event = await _context.Events.FindAsync(id);
            if (@event != null)
            {
                _context.Events.Remove(@event);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(Guid id)
        {
            return _context.Events.Any(e => e.EventId == id);
        }

        private bool EventReportExists(Guid id)
        {
            return _context.EventReports.Any(e => e.UserId == id);
        }

        // TODO: change to the userId to the logged in userId
        public async Task<IActionResult> Going(Guid? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            Guid userId = Guid.Parse("00000000-0000-0000-0000-000000000000");

            Guid eventId = (Guid)Id;

            var userEvent = _context.UserEvents.FirstOrDefault(e => e.EventId == eventId && e.UserId == userId);
            if (userEvent == null)
            {
                userEvent = new UserEvent
                {
                    EventId = eventId,
                    UserId = userId,
                    Status = "Going"
                };
                userEvent.User = _context.Users.Find(userId);
                userEvent.Event = _context.Events.Find(eventId);
                _context.UserEvents.Add(userEvent);
            }
            else
            {
                if (userEvent.Status == "Going")
                {
                    _context.UserEvents.Remove(userEvent);
                }
                else
                {
                    userEvent.Status = "Going";
                }
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
