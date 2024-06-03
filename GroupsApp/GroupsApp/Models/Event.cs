using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace GroupsApp.Models
{
    public class Event
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

        [Key]
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

        public User Organizer { get; set; }

        public ICollection<User> Users { get; set; } = new List<User>();

        public ICollection<EventDonation> Donations { get; set; } = new List<EventDonation>();

        public ICollection<EventReview> Reviews { get; set; } = new List<EventReview>();

        public ICollection<EventExpense> Expenses { get; set; } = new List<EventExpense>();

        public ICollection<EventReport> Reports { get; set; } = new List<EventReport>();


        public Event(DataRow row)
        {
            eventId = (Guid)row["GUID"];
            organizerId = (Guid)row["OrganizerGUID"];
            eventName = (string)row["EventName"];
            categories = (string)row["Categories"];
            location = (string)row["Location"];
            maxParticipants = (int)row["MaxParticipants"];
            description = (string)row["Description"];
            startDate = (DateTime)row["StartDate"];
            endDate = (DateTime)row["EndDate"];
            bannerURL = (string)row["BannerURL"];
            logoURL = (string)row["LogoURL"];
            ageLimit = (int)row["AgeLimit"];
            entryFee = (float)row["EntryFee"];
        }

        public Event(Guid guid, Guid userGUID, string eventName, string categories, string location, int maxParticipants, string description, DateTime startDate, DateTime endDate, string bannerURL, string logoURL, int ageLimit, float entryFee)
        {
            this.eventId = guid;
            this.organizerId = userGUID;
            this.eventName = eventName;
            this.categories = categories;
            this.location = location;
            this.maxParticipants = maxParticipants;
            this.description = description;
            this.startDate = startDate;
            this.endDate = endDate;
            this.bannerURL = bannerURL;
            this.logoURL = logoURL;
            this.ageLimit = ageLimit;
            this.entryFee = entryFee;
        }

        public Event(Guid userGUID, string eventName, string categories, string location, int maxParticipants, string description, DateTime startDate, DateTime endDate, string bannerURL, string logoURL, int ageLimit, float entryFee)
        {
            this.eventId = Guid.NewGuid();
            this.organizerId = userGUID;
            this.eventName = eventName;
            this.categories = categories;
            this.location = location;
            this.maxParticipants = maxParticipants;
            this.description = description;
            this.startDate = startDate;
            this.endDate = endDate;
            this.bannerURL = bannerURL;
            this.logoURL = logoURL;
            this.ageLimit = ageLimit;
            this.entryFee = entryFee;
        }

        public Event(Guid guid)
        {
            this.eventId = guid;
            this.organizerId = Guid.Empty;
            this.eventName = string.Empty;
            this.categories = string.Empty;
            this.location = string.Empty;
            this.maxParticipants = 0;
            this.description = string.Empty;
            this.startDate = DateTime.Now;
            this.endDate = DateTime.Now;
            this.bannerURL = string.Empty;
            this.logoURL = string.Empty;
            this.ageLimit = 0;
            this.entryFee = 0;
        }

        public Event()
        {
            this.eventId = Guid.NewGuid();
            this.organizerId = Guid.Empty;
            this.eventName = string.Empty;
            this.categories = string.Empty;
            this.location = string.Empty;
            this.maxParticipants = 0;
            this.description = string.Empty;
            this.startDate = DateTime.Now;
            this.endDate = DateTime.Now;
            this.bannerURL = string.Empty;
            this.logoURL = string.Empty;
            this.ageLimit = 0;
            this.entryFee = 0;
        }
    }
}
