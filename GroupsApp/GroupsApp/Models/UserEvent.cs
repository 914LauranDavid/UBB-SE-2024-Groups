using System.Data;

namespace GroupsApp.Models
{
    public class UserEvent
    {
        private Guid userId;
        private Guid eventId;
        private string status;

        public Guid UserId { get => userId; set => userId = value; }
        public Guid EventId { get => eventId; set => eventId = value; }
        public string Status { get => status; set => status = value; }

        public UserEvent(DataRow row)
        {
            userId = (Guid)row["UserGUID"];
            eventId = (Guid)row["EventGUID"];
            status = (string)row["Status"];
        }

        public UserEvent(Guid userGUID, Guid eventGUID, string status)
        {
            this.userId = userGUID;
            this.eventId = eventGUID;
            this.status = status;
        }

        public UserEvent(Guid userGUID, Guid eventGUID)
        {
            this.userId = userGUID;
            this.eventId = eventGUID;
            this.status = string.Empty;
        }

        public UserEvent()
        {
            this.userId = Guid.Empty;
            this.eventId = Guid.Empty;
            this.status = string.Empty;
        }
    }
}
