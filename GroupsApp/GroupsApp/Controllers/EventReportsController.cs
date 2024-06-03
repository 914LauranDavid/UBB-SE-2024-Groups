using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GroupsApp.Data;
using GroupsApp.Models;
using NuGet.Packaging.Signing;
using static GroupsApp.Models.EventReport;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GroupsApp.Controllers
{
    public class EventReportsController : Controller
    {
        private readonly GroupsAppContext _context;

        public EventReportsController(GroupsAppContext context)
        {
            _context = context;
        }

        // GET: EventReports
        public async Task<IActionResult> Index()
        {
            var groupsAppContext = _context.EventReports.Include(e => e.Event).Include(e => e.Reporter);
            //TODO add where check to display only the reports for the logged in user
            return View(await groupsAppContext.ToListAsync());
        }

        // GET: EventReports/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventReport = await _context.EventReports
                .Include(e => e.Event)
                .Include(e => e.Reporter)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (eventReport == null)
            {
                return NotFound();
            }

            return View(eventReport);
        }

        // GET: EventReports/Create
        public IActionResult Create()
        {
            string EventId = Request.Query["EventId"];
            string UserId = Request.Query["UserId"];

            ViewData["EventId"] = Guid.Parse(EventId);
            ViewData["UserId"] = Guid.Parse(UserId);
            ViewData["ReportTypes"] = new SelectList(Enum.GetValues(typeof(ReportType)).Cast<ReportType>());
            return View();
        }

        // POST: EventReports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,EventId,ReportTypeValue")] EventReport eventReport)
        {
            eventReport.Event = _context.Events.Find(eventReport.EventId);
            eventReport.Reporter = _context.Users.Find(eventReport.UserId);
            ModelState["Event"].ValidationState = ModelValidationState.Valid;
            ModelState["Reporter"].ValidationState = ModelValidationState.Valid;
            if (EventReportExists(eventReport.UserId))
            {
                return RedirectToAction(nameof(Index));
            }
            if (ModelState.IsValid)
            {
                eventReport.UserId = Guid.NewGuid();
                _context.Add(eventReport);
                await _context.SaveChangesAsync();

                //if event has more then 3 reports, set it to under investigation
                int nrreports = _context.EventReports.Where(e => e.EventId == eventReport.EventId).Count();
                if (nrreports > 3)
                {
                    Event eventToInvestigate = _context.Events.Find(eventReport.EventId);
                    eventToInvestigate.UnderInvestigation = true;
                    _context.Update(eventToInvestigate);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }
            return View(eventReport);
        }

        // GET: EventReports/Edit/5
        public async Task<IActionResult> Edit(Guid? EventId, Guid? UserId)
        {
            if (EventId == null || UserId == null)
            {
                return NotFound();
            }

            var eventReport = await _context.EventReports.FindAsync(EventId, UserId);
            if (eventReport == null)
            {
                return NotFound();
            }
            return View(eventReport);
        }

        // POST: EventReports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid EventId, Guid UserId, [Bind("UserId,EventId,ReportTypeValue")] EventReport eventReport)
        {
            if (UserId != eventReport.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventReport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventReportExists(eventReport.UserId))
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
            return View(eventReport);
        }

        // GET: EventReports/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventReport = await _context.EventReports
                .Include(e => e.Event)
                .Include(e => e.Reporter)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (eventReport == null)
            {
                return NotFound();
            }

            return View(eventReport);
        }

        // POST: EventReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid EventId, Guid UserId)
        {
            var eventReport = await _context.EventReports.FindAsync(EventId, UserId);
            if (eventReport != null)
            {
                _context.EventReports.Remove(eventReport);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventReportExists(Guid id)
        {
            return _context.EventReports.Any(e => e.UserId == id);
        }
    }
}
