namespace GroupsApp.Payload.DTO
{
    public class EventReviewDTO
    {
        private Guid userId;
        private Guid eventId;
        private float score;
        private string reviewDescription;

        public Guid UserId { get => userId; set => userId = value; }
        public Guid EventId { get => eventId; set => eventId = value; }
        public float Score { get => score; set => score = value; }
        public string ReviewDescription { get => reviewDescription; set => reviewDescription = value; }
    }
}
