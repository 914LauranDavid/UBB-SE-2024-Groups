using System.Data;

namespace GroupsApp.Models
{
    public class EventReport
    {
        private Guid userId;
        private Guid eventId;
        private ReportType reportTypeValue;

        public Guid UserId { get => userId; set => userId = value; }
        public Guid EventId { get => eventId; set => eventId = value; }
        public ReportType ReportTypeValue { get => reportTypeValue; set => reportTypeValue = value; }

        public EventReport(DataRow row)
        {
            userId = (Guid)row["UserGUID"];
            eventId = (Guid)row["EventGUID"];
            reportTypeValue = (ReportType)row["ReportTypeValue"];
        }

        public EventReport(Guid userGUID, Guid eventGUID, ReportType reportType)
        {
            this.userId = userGUID;
            this.EventId = eventGUID;
            this.reportTypeValue = reportType;
        }

        public EventReport(Guid userGUID, Guid eventGUID)
        {
            this.userId = userGUID;
            this.eventId = eventGUID;
            this.reportTypeValue = ReportType.Harassment;
        }

        public EventReport()
        {
            this.userId = Guid.Empty;
            this.eventId = Guid.Empty;
            this.reportTypeValue = ReportType.Harassment;
        }

        public enum ReportType
        {
            /// <summary>
            /// Harassment
            /// </summary>
            Harassment,

            /// <summary>
            /// Nudity
            /// </summary>
            Nudity,

            /// <summary>
            /// Spam
            /// </summary>
            Spam,

            /// <summary>
            /// Violence
            /// </summary>
            Violence,

            /// <summary>
            /// None
            /// </summary>
            None,

            /// <summary>
            /// Fraud
            /// </summary>
            Fraud,

            /// <summary>
            /// Offensive
            /// </summary>
            Offensive,

            /// <summary>
            /// GuidelinesViolations
            /// </summary>
            GuidelinesViolations,
        }
    }
}
