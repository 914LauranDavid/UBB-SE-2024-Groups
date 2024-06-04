using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace GroupsApp.Models
{
    public class EventNotification
    {
        [Key]
        private Guid eventNotificationId;
        private Guid eventId;
        private Guid userId;
        private string message;


        public Guid EventNotificationId { get => eventNotificationId; set => eventNotificationId = value; }
        public Guid EventId { get => eventId; set => eventId = value; }
        public Guid UserId { get => userId; set => userId = value; }
        public string Message { get => message; set => message = value; }
        public User User { get; set; }
        public Event Event { get; set; }

        public EventNotification()
        {
            this.eventNotificationId = Guid.NewGuid();
            this.eventId = Guid.Empty;
            this.userId = Guid.Empty;
            this.message = string.Empty;
        }
        public EventNotification(Guid guid, Guid eventGUID, Guid userGUID, string message)
        {
            this.eventNotificationId = guid;
            this.eventId = eventGUID;
            this.userId = userGUID;
            this.message = message;
        }
    }
}
