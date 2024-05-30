using GroupsApp.Data;
using GroupsApp.Models;

namespace GroupsApp.Repositories
{
    public class EventReportRepository
    {
        private readonly GroupsAppContext _context;

        public EventReportRepository(GroupsAppContext context)
        {
            _context = context;
        }

        public EventReport AddEventReport(EventReport eventReport)
        {
            _context.EventReports.Add(eventReport);
            _context.SaveChanges();
            return eventReport;
        }

        public EventReport? GetEventReportById(Guid userId, Guid eventId)
        {
            return _context.EventReports.SingleOrDefault(er => er.UserId == userId && er.EventId == eventId);
        }

        public EventReport UpdateEventReport(EventReport eventReport)
        {
            EventReport? foundEventReport = _context.EventReports.SingleOrDefault(er => er.UserId == eventReport.UserId && er.EventId == eventReport.EventId);
            if (foundEventReport == null)
            {
                throw new Exception("Event report not found");
            }
            foundEventReport.ReportTypeValue = eventReport.ReportTypeValue;
            EventReport updatedEventReport = _context.EventReports.Update(foundEventReport).Entity;
            _context.SaveChanges();
            return updatedEventReport;
        }

        public void DeleteEventReport(Guid userId, Guid eventId)
        {
            EventReport? foundEventReport = _context.EventReports.SingleOrDefault(er => er.UserId == userId && er.EventId == eventId);
            if (foundEventReport == null)
            {
                throw new Exception("Event report not found");
            }
            _context.EventReports.Remove(foundEventReport);
            _context.SaveChanges();
        }

        public List<EventReport> GetAllEventReports()
        {
            return _context.EventReports.ToList();
        }

        public List<EventReport> GetEventReportsByEventId(Guid eventId)
        {
            return _context.EventReports.Where(er => er.EventId == eventId).ToList();
        }
    }
}
