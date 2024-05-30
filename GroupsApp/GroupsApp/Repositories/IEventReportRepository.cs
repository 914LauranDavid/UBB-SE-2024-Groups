using GroupsApp.Models;

namespace GroupsApp.Repositories
{
    public interface IEventReportRepository
    {
        public EventReport AddEventReport(EventReport eventReport);
        public void DeleteEventReport(Guid userId, Guid eventId);
        public EventReport UpdateEventReport(EventReport eventReport);
        public EventReport? GetEventReportById(Guid userId,Guid eventId);
        public List<EventReport> GetAllEventReports();
    }
}
