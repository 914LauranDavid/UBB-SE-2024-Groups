using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GroupsApp.Models;
using GroupsApp.Models.MarketplacePosts;

namespace GroupsApp.Data
{
    public class GroupsAppContext : DbContext
    {
        public GroupsAppContext(DbContextOptions<GroupsAppContext> options)
            : base(options)
        {
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<MarketplacePost> MarketplacePosts { get; set; }
        public DbSet<FixedPricePost> FixedPricePosts { get; set; }
        public DbSet<AuctionPost> AuctionPosts { get; set; }
        public DbSet<DonationPost> DonationPosts { get; set; }

        public DbSet<JoinRequest> JoinRequests { get; set; }
        public DbSet<Cart> Cart { get; set; }

        public DbSet<UsersFavoritePosts> UsersFavoritePosts { get; set; }
        public DbSet<Membership> Memberships { get; set; }

        public DbSet<Poll> Polls { get; set; }
        public DbSet<PollOption> PollOptions { get; set; }

        public DbSet<PollAnswer> PollAnswers { get; set; }

        public DbSet<GroupPost> GroupPosts { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<UserEvent> UserEvents { get; set; }

        public DbSet<EventExpense> EventExpenses { get; set; }

        public DbSet<EventDonation> EventDonations { get; set; }

        public DbSet<MarketplacePostReview> MarketplacePostReviews { get; set; }

        public DbSet<GroupPostReport> GroupPostReports { get; set; }

        public DbSet<EventReport> EventReports { get; set; }

        public DbSet<EventReview> EventReviews { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<InterestStatus> InterestStatuses { get; set; }


        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.UserId);
            modelBuilder.Entity<Group>().HasKey(g => g.GroupId);
            modelBuilder.Entity<EventExpense>().HasKey(ee => ee.EventExpenseId);
            modelBuilder.Entity<EventDonation>().HasKey(ed => ed.EventDonationId);
            modelBuilder.Entity<MarketplacePostReview>().HasKey(mpr => mpr.ReviewId);
            modelBuilder.Entity<GroupPostReport>().HasKey(gpr => gpr.ReportId);
            modelBuilder.Entity<EventReport>().HasKey(er => new { er.EventId, er.UserId });
            modelBuilder.Entity<EventReview>().HasKey(er => new { er.EventId, er.UserId });
            modelBuilder.Entity<Membership>().HasKey(m => new { m.GroupId, m.UserId });
            modelBuilder.Entity<JoinRequest>().HasKey(jr => jr.JoinRequestId);
            modelBuilder.Entity<PollOption>().HasKey(po => po.PollOptionId);
            modelBuilder.Entity<Poll>().HasKey(p => p.PollId);
            modelBuilder.Entity<UserEvent>().HasKey(ue => new { ue.UserId, ue.EventId });
            modelBuilder.Entity<PollAnswer>().HasKey(pa => new { pa.PollOptionId, pa.UserId });
            modelBuilder.Entity<GroupPost>().HasKey(gp => gp.GroupPostId);
            modelBuilder.Entity<Event>().HasKey(e => e.EventId);
            modelBuilder.Entity<Cart>().HasKey(c => new { c.UserId, c.MarketplacePostId });
            modelBuilder.Entity<UsersFavoritePosts>().HasKey(ufp => new { ufp.UserId, ufp.MarketplacePostId });
            modelBuilder.Entity<Comment>().HasKey(c => c.CommentId);
            modelBuilder.Entity<InterestStatus>().HasKey(i => i.InterestStatusId);



            modelBuilder.Entity<Group>()
                .HasOne(g => g.Owner)
                .WithMany(u => u.OwnedGroups)
                .HasForeignKey(g => g.OwnerId);

            modelBuilder.Entity<MarketplacePost>()
                .HasOne(mp => mp.Group)
                .WithMany(g => g.MarketplacePosts)
                .HasForeignKey(mp => mp.GroupId);

            modelBuilder.Entity<MarketplacePost>()
                .HasOne(mp => mp.Author)
                .WithMany(u => u.MarketplacePosts)
                .HasForeignKey(mp => mp.AuthorId);

            modelBuilder.Entity<MarketplacePost>()
                .HasDiscriminator<string>("Type")
                .HasValue<FixedPricePost>(Constants.FIXED_PRICE_POST_TYPE)
                .HasValue<AuctionPost>(Constants.AUCTION_POST_TYPE)
                .HasValue<DonationPost>(Constants.DONATION_POST_TYPE)
                .HasValue<MarketplacePost>(Constants.DEFAULT_POST_TYPE);

            modelBuilder.Entity<User>()
                .HasMany(u => u.PostsInCart)
                .WithMany(mp => mp.PeopleThatPlacedInCart)
                .UsingEntity<Cart>(
                    l => l.HasOne<MarketplacePost>().WithMany().HasForeignKey(e => e.MarketplacePostId),
                    r => r.HasOne<User>().WithMany().HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.NoAction));

            modelBuilder.Entity<User>()
                .HasMany(u => u.FavoritePosts)
                .WithMany(mp => mp.PeopleThatFavored)
                .UsingEntity<UsersFavoritePosts>(
                    l => l.HasOne<MarketplacePost>().WithMany().HasForeignKey(e => e.MarketplacePostId),
                    r => r.HasOne<User>().WithMany().HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.NoAction));


            modelBuilder.Entity<User>()
                .HasMany(u => u.GroupsPartOf)
                .WithMany(g => g.Users)
                .UsingEntity<Membership>();

            modelBuilder.Entity<JoinRequest>()
                .HasOne(jr => jr.User)
                .WithMany(u => u.JoinRequests)
                .HasForeignKey(jr => jr.UserId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<JoinRequest>()
                .HasOne(jr => jr.Group)
                .WithMany(g => g.JoinRequests)
                .HasForeignKey(jr => jr.GroupId);

            modelBuilder.Entity<Group>()
                .HasMany(g => g.UsersTryingToJoin)
                .WithMany(u => u.GroupsTryingToJoin)
                .UsingEntity<JoinRequest>();

            modelBuilder.Entity<Poll>()
                .HasOne(p => p.Group)
                .WithMany(g => g.GroupPolls)
                .HasForeignKey(p => p.GroupId);

            modelBuilder.Entity<PollOption>()
                .HasOne(po => po.Poll)
                .WithMany(p => p.PollOptions)
                .HasForeignKey(po => po.PollId);

            modelBuilder.Entity<PollAnswer>().HasKey(pa => new { pa.PollOptionId, pa.UserId });

            modelBuilder.Entity<PollAnswer>()
                .HasOne(pa => pa.PollOption)
                .WithMany(po => po.PollAnswers)
                .HasForeignKey(pa => pa.PollOptionId);

            modelBuilder.Entity<PollAnswer>()
                .HasOne(pa => pa.UserThatAnswered)
                .WithMany(u => u.PollAnswers)
                .HasForeignKey(pa => pa.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PollOption>()
                .HasMany(pa => pa.UsersThatSelectedOption)
                .WithMany(u => u.SelectedPollOptions)
                .UsingEntity<PollAnswer>();

            modelBuilder.Entity<GroupPost>()
                .HasKey(gp => gp.GroupPostId);

            modelBuilder.Entity<GroupPost>()
                .HasOne(gp => gp.Group)
                .WithMany(g => g.GroupPosts)
                .HasForeignKey(gp => gp.GroupId);

            modelBuilder.Entity<GroupPost>()
                .HasOne(gp => gp.Author)
                .WithMany(u => u.GroupPosts)
                .HasForeignKey(gp => gp.AuthorId);

            modelBuilder.Entity<Membership>()
                .HasOne(m => m.User)
                .WithMany(u => u.Memberships)
                .HasForeignKey(m => m.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Event>()
                .HasOne(e => e.Organizer)
                .WithMany(u => u.OriganizedEvents)
                .HasForeignKey(e => e.OrganizerId)
                .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<User>()
            //    .HasMany(u => u.Events)
            //    .WithMany(e => e.Users)
            //    .UsingEntity<UserEvent>();

            modelBuilder.Entity<EventReport>().HasKey(er => new { er.UserId, er.EventId });

            modelBuilder.Entity<EventReview>().HasKey(er => new { er.UserId, er.EventId });

            modelBuilder.Entity<GroupPostReport>().HasKey(gpr => gpr.ReportId);

            modelBuilder.Entity<MarketplacePostReview>().HasKey(mppr => mppr.ReviewId);

            modelBuilder.Entity<MarketplacePostReview>()
                .HasOne(mppr => mppr.MarketplacePost)
                .WithMany(mp => mp.Reviews)
                .HasForeignKey(mppr => mppr.MarketplacePostId);

            modelBuilder.Entity<MarketplacePostReview>()
                .HasOne(mppr => mppr.Reviewer)
                .WithMany(u => u.MarketPlacePostReviewsMade)
                .HasForeignKey(mppr => mppr.UserId);

            modelBuilder.Entity<EventDonation>()
                .HasOne(ed => ed.Event)
                .WithMany(e => e.Donations)
                .HasForeignKey(ed => ed.EventId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<EventDonation>()
                .HasOne(ed => ed.User)
                .WithMany(u => u.EventDonationsMade)
                .HasForeignKey(ed => ed.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<EventExpense>()
                .HasOne(ee => ee.Event)
                .WithMany(e => e.Expenses)
                .HasForeignKey(ee => ee.EventId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<EventReview>()
                .HasOne(er => er.Event)
                .WithMany(e => e.Reviews)
                .HasForeignKey(er => er.EventId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<EventReview>()
                .HasOne(er => er.Reviewer)
                .WithMany(u => u.EventReviewsMade)
                .HasForeignKey(er => er.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<GroupPostReport>()
                .HasOne(GroupPostReport => GroupPostReport.Reporter)
                .WithMany(u => u.GroupPostReportsMade)
                .HasForeignKey(GroupPostReport => GroupPostReport.UserId);

            modelBuilder.Entity<GroupPostReport>()
                .HasOne(GroupPostReport => GroupPostReport.ReportedPost)
                .WithMany(gp => gp.Reports)
                .HasForeignKey(GroupPostReport => GroupPostReport.PostId);

            modelBuilder.Entity<EventReport>()
                .HasOne(er => er.Reporter)
                .WithMany(u => u.EventReportsMade)
                .HasForeignKey(er => er.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<EventReport>()
                .HasOne(er => er.Event)
                .WithMany(e => e.Reports)
                .HasForeignKey(er => er.EventId)
                .OnDelete(DeleteBehavior.NoAction);

            // fix foreign key constraints on delete cascade
            // not optiomal but i dont care any more
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.NoAction;
            }
            //
        }
        #endregion
    }
}