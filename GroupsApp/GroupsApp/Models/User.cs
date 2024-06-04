using System.ComponentModel.DataAnnotations;
using System.Diagnostics.SymbolStore;
using GroupsApp.Models.MarketplacePosts;
using Microsoft.AspNetCore.Identity;

namespace GroupsApp.Models
{
    public class User : IdentityUser<Guid>
    {
        //private Guid userId;
        //private string username;
        private string? fullName;
        private string? password;
        //private string email;
        //private string phoneNumber;
        private DateOnly birthDay;
        private DateTime createdDate;

        [Key]
        //public Guid UserId { get => userId; set => userId = value; }
        //public string Username { get => username; set => username = value; }
        public string? FullName { get => fullName; set => fullName = value; }
        public string? Password { get => password; set => password = value; }
        //public string Email { get => email; set => email = value; }
        //public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public DateOnly BirthDay { get => birthDay; set => birthDay = value; }
        public DateTime CreatedDate { get => createdDate; set => createdDate = value; }

        public ICollection<MarketplacePost> PostsInCart { get; set; } = new List<MarketplacePost>();

        public ICollection<MarketplacePost> FavoritePosts { get; set; } = new List<MarketplacePost>();
        public ICollection<Group> OwnedGroups { get; set; } = new List<Group>();

        public ICollection<MarketplacePost> MarketplacePosts { get; set; } = new List<MarketplacePost>();

        public ICollection<Group> GroupsPartOf { get; set; } = new List<Group>();
        public ICollection<Membership> Memberships { get; set; } = new List<Membership>();

        public ICollection<Group> GroupsTryingToJoin { get; set; } = new List<Group>();
        public ICollection<JoinRequest> JoinRequests { get; set; } = new List<JoinRequest>();

        public ICollection<PollOption> SelectedPollOptions { get; set; } = new List<PollOption>();
        public ICollection<PollAnswer> PollAnswers { get; set; } = new List<PollAnswer>();
        public ICollection<GroupPost> GroupPosts { get; set; } = new List<GroupPost>();

        public ICollection<Event> Events { get; set; } = new List<Event>();

        public ICollection<Event> OriganizedEvents { get; set; } = new List<Event>();

        public ICollection<MarketplacePostReview> MarketPlacePostReviewsMade { get; set; } = new List<MarketplacePostReview>();

        public  ICollection<EventDonation> EventDonationsMade { get; set; } = new List<EventDonation>();

        public ICollection<GroupPostReport> GroupPostReportsMade { get; set; } = new List<GroupPostReport>();

        public ICollection<EventReview> EventReviewsMade { get; set; } = new List<EventReview>();

        public ICollection<EventReport> EventReportsMade { get; set; } = new List<EventReport>();
    }
}
