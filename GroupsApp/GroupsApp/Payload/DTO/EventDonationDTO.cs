namespace GroupsApp.Payload.DTO
{
    public class EventDonationDTO
    {
        private Guid eventDonationId;
        private Guid eventId;
        private Guid userId;
        private float amount;

        public Guid EventDonationId { get => eventDonationId; set => eventDonationId = value; }
        public Guid EventId { get => eventId; set => eventId = value; }
        public Guid UserId { get => userId; set => userId = value; }
        public float Amount { get => amount; set => amount = value; }
    }
}
