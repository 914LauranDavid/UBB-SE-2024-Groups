﻿namespace GroupsApp.Models.MarketplacePosts
{
    public class DonationPost : MarketplacePost
    {
        private string donationLink;
        private double currentDonationAmount;

        public string DonationLink { get => donationLink; set => donationLink = value; }
        public double CurrentDonationAmount { get => currentDonationAmount; set => currentDonationAmount = value; }
        

        public DonationPost(Guid marketplacePostId, Guid authorId, Guid groupId, string title, string description, string mediaContent, string location,
                       DateTime creationDate, DateTime? endDate, bool isPromoted, bool isActive, string donationLink, double currentDonationAmount)
            : base(marketplacePostId, authorId, groupId, title, description, mediaContent, location, creationDate, endDate, isPromoted, isActive, "Donation")
        {
            this.donationLink = donationLink;
            this.currentDonationAmount = currentDonationAmount; 
        }

        public DonationPost() : base()
        {
            this.donationLink = Constants.EMPTY_STRING;
            this.currentDonationAmount = 0;
        }

        public override string ToString()
        {
            return $"{this.AuthorId}, {this.MarketplacePostId}";
        }
    }
}
