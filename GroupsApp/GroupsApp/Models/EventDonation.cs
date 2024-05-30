using System.ComponentModel.DataAnnotations;
using System.Data;

namespace GroupsApp.Models
{
    public class EventDonation
    {
        private Guid eventDonationId;
        private Guid eventId;
        private Guid userId;
        private float amount;


        [Key]
        public Guid EventDonationId { get => eventDonationId; set => eventDonationId = value; }
        public Guid EventId { get => eventId; set => eventId = value; }
        public Guid UserId { get => userId; set => userId = value; }
        public float Amount { get => amount; set => amount = value; }



        public EventDonation(DataRow row)
        {
            eventDonationId = (Guid)row["GUID"];
            eventId = (Guid)row["EventGUID"];
            userId = (Guid)row["UserGUID"];
            amount = (float)row["Amount"];
        }

        public EventDonation(Guid guid, Guid eventGUID, Guid userGUID, float amount)
        {
            this.eventDonationId = guid;
            this.eventId = eventGUID;
            this.userId = userGUID;
            this.amount = amount;
        }

        public EventDonation(Guid eventGUID, Guid userGUID, float amount)
        {
            this.eventId = eventGUID;
            this.userId = userGUID;
            this.amount = amount;
            this.eventDonationId = Guid.NewGuid();
        }

        public EventDonation(Guid guid)
        {
            this.eventDonationId = guid;
            this.eventId = Guid.Empty;
            this.userId = Guid.Empty;
            this.amount = 0;
        }

        public EventDonation()
        {
            this.eventDonationId = Guid.NewGuid();
            this.eventId = Guid.Empty;
            this.userId = Guid.Empty;
            this.amount = 0;
        }
    }
}
