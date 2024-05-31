using GroupsApp.Models;
using static GroupsApp.Models.EventReport;

namespace GroupsApp.Payload.DTO
{
    public class EventReportDTO
    {
        private Guid userId;
        private Guid eventId;
        private ReportType reportTypeValue;

        public Guid UserId { get => userId; set => userId = value; }
        public Guid EventId { get => eventId; set => eventId = value; }
        public ReportType ReportTypeValue { get => reportTypeValue; set => reportTypeValue = value; }

    }
}
