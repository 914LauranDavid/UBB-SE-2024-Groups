﻿using GroupsApp.Models.MarketplacePosts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GroupsApp.Models
{
    public class MarketplacePostReview
    {
        private Guid reviewId;
        private Guid userId;
        private Guid marketplacePostId;
        private string content;
        private int rating;
        private DateOnly postTime;

        public MarketplacePostReview(Guid userId, Guid marketplacePostId, string content, int rating, DateOnly postTime)
        {
            this.userId = userId;
            this.marketplacePostId = marketplacePostId;
            this.content = content;
            this.rating = rating;
            this.postTime = postTime;
        }

        public MarketplacePostReview()
        {
            this.userId = Guid.NewGuid();
            this.marketplacePostId = Guid.NewGuid();
            this.content = Constants.EMPTY_STRING;
            this.rating = 0;
            this.postTime = DateOnly.FromDateTime(DateTime.Now);
        }

        public MarketplacePostReview(Guid userId, Guid marketplacePostId)
        {
            this.userId = userId;
            this.marketplacePostId = marketplacePostId;
            this.content = Constants.EMPTY_STRING;
            this.rating = 0;
            this.postTime = DateOnly.FromDateTime(DateTime.Now);
        }

        public Guid ReviewId { get => reviewId; }
        public Guid UserId { get => userId; }
        public Guid MarketplacePostId { get => marketplacePostId; }
        public string Content { get => content; set => content = value; }
        public int Rating { get => rating; set => rating = value; }
        public DateOnly PostTime { get => postTime; }

        public MarketplacePost MarketplacePost { get; set; }
        public User Reviewer { get; set; }
    }
}
