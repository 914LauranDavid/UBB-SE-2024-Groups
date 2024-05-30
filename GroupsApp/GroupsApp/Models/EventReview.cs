namespace GroupsApp.Models
{
    public class EventReview
    {
        private Guid userId;
        private Guid eventId;
        private float score;
        private string reviewDescription;
        
        public Guid UserId { get => userId; set => userId = value; }
        public Guid EventId { get => eventId; set => eventId = value; }
        public float Score { get => score; set => score = value; }
        public string ReviewDescription { get => reviewDescription; set => reviewDescription = value; }

        public User Reviewer { get; set; }

        public Event Event { get; set; }

        public EventReview(Guid userGUID, Guid eventGUID, float score, string reviewDescription)
        {
            this.userId = userGUID;
            this.eventId = eventGUID;
            this.score = score;
            this.reviewDescription = reviewDescription;
        }

        public EventReview(Guid userGUID, Guid eventGUID)
        {
            this.userId = userGUID;
            this.eventId = eventGUID;
            this.score = 0;
            this.reviewDescription = string.Empty;
        }

        public EventReview()
        {
            this.userId = Guid.Empty;
            this.eventId = Guid.Empty;
            this.score = 0;
            this.reviewDescription = string.Empty;
        }
    }
}
