namespace GroupsApp.Payload.DTO
{
    public class EventDTO
    {
        private Guid eventId;
        private Guid organizerId;
        private string eventName;
        private string categories;
        private string location;
        private int maxParticipants;
        private string description;
        private DateTime startDate;
        private DateTime endDate;
        private string bannerURL;
        private string logoURL;
        private int ageLimit;
        private float entryFee;

        public Guid EventId { get => eventId; set => eventId = value; }
        public Guid OrganizerId { get => organizerId; set => organizerId = value; }

        public string EventName { get => eventName; set => eventName = value; }

        public string Categories { get => categories; set => categories = value; }

        public string Location { get => location; set => location = value; }

        public int MaxParticipants { get => maxParticipants; set => maxParticipants = value; }

        public string Description { get => description; set => description = value; }

        public DateTime StartDate { get => startDate; set => startDate = value; }

        public DateTime EndDate { get => endDate; set => endDate = value; }

        public string BannerURL { get => bannerURL; set => bannerURL = value; }

        public string LogoURL { get => logoURL; set => logoURL = value; }

        public int AgeLimit { get => ageLimit; set => ageLimit = value; }

        public float EntryFee { get => entryFee; set => entryFee = value; }

    }
}
