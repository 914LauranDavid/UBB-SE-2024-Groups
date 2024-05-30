﻿// <auto-generated />
using System;
using GroupsApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GroupsApp.Migrations
{
    [DbContext(typeof(GroupsAppContext))]
    [Migration("20240530192744_CreatedConnectionForMPPReviewsAndEventDonations")]
    partial class CreatedConnectionForMPPReviewsAndEventDonations
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GroupsApp.Models.Cart", b =>
                {
                    b.Property<Guid>("MarketplacePostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MarketplacePostId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("GroupsApp.Models.Event", b =>
                {
                    b.Property<Guid>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AgeLimit")
                        .HasColumnType("int");

                    b.Property<string>("BannerURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Categories")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<float>("EntryFee")
                        .HasColumnType("real");

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LogoURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxParticipants")
                        .HasColumnType("int");

                    b.Property<Guid>("OrganizerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("EventId");

                    b.HasIndex("OrganizerId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("GroupsApp.Models.EventDonation", b =>
                {
                    b.Property<Guid>("EventDonationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<Guid>("EventId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("EventDonationId");

                    b.HasIndex("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("EventDonations");
                });

            modelBuilder.Entity("GroupsApp.Models.EventExpense", b =>
                {
                    b.Property<Guid>("EventExpenseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Cost")
                        .HasColumnType("real");

                    b.Property<Guid>("EventGUID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EventId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ExpenseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EventExpenseId");

                    b.HasIndex("EventId");

                    b.ToTable("EventExpenses");
                });

            modelBuilder.Entity("GroupsApp.Models.EventReport", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EventId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ReportTypeValue")
                        .HasColumnType("int");

                    b.HasKey("UserId", "EventId");

                    b.ToTable("EventReports");
                });

            modelBuilder.Entity("GroupsApp.Models.EventReview", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EventId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ReviewDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Score")
                        .HasColumnType("real");

                    b.HasKey("UserId", "EventId");

                    b.HasIndex("EventId");

                    b.ToTable("EventReviews");
                });

            modelBuilder.Entity("GroupsApp.Models.Group", b =>
                {
                    b.Property<Guid>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("AllowanceOfPostage")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("bit");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GroupId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("GroupsApp.Models.GroupPost", b =>
                {
                    b.Property<Guid>("GroupPostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("AdminOnly")
                        .HasColumnType("bit");

                    b.Property<Guid?>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsPinned")
                        .HasColumnType("bit");

                    b.Property<string>("MediaContent")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GroupPostId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("GroupId");

                    b.ToTable("GroupPosts");
                });

            modelBuilder.Entity("GroupsApp.Models.GroupPostReport", b =>
                {
                    b.Property<Guid>("ReportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfReport")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReasonForReporting")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReportId");

                    b.ToTable("GroupPostReports");
                });

            modelBuilder.Entity("GroupsApp.Models.JoinRequest", b =>
                {
                    b.Property<Guid>("JoinRequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("JoinRequestId");

                    b.HasIndex("GroupId");

                    b.HasIndex("UserId");

                    b.ToTable("JoinRequests");
                });

            modelBuilder.Entity("GroupsApp.Models.MarketPlacePostReview", b =>
                {
                    b.Property<Guid>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("MarketplacePostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ReviewId");

                    b.HasIndex("MarketplacePostId");

                    b.HasIndex("UserId");

                    b.ToTable("MarketPlacePostReviews");
                });

            modelBuilder.Entity("GroupsApp.Models.MarketplacePosts.MarketplacePost", b =>
                {
                    b.Property<Guid>("MarketplacePostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPromoted")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MediaContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.HasKey("MarketplacePostId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("GroupId");

                    b.ToTable("MarketplacePosts");

                    b.HasDiscriminator<string>("Type").HasValue("NormalPost");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("GroupsApp.Models.Membership", b =>
                {
                    b.Property<Guid>("GroupId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(0);

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(1);

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("IsBanned")
                        .HasColumnType("bit");

                    b.Property<bool>("IsTimedOut")
                        .HasColumnType("bit");

                    b.HasKey("GroupId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("Memberships");
                });

            modelBuilder.Entity("GroupsApp.Models.Poll", b =>
                {
                    b.Property<Guid>("PollId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("EndDate")
                        .HasColumnType("date");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsAnonymous")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMultipleChoice")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPinned")
                        .HasColumnType("bit");

                    b.Property<bool>("IsVisible")
                        .HasColumnType("bit");

                    b.HasKey("PollId");

                    b.HasIndex("GroupId");

                    b.ToTable("Polls");
                });

            modelBuilder.Entity("GroupsApp.Models.PollAnswer", b =>
                {
                    b.Property<Guid>("PollOptionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PollOptionId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("PollAnswers");
                });

            modelBuilder.Entity("GroupsApp.Models.PollOption", b =>
                {
                    b.Property<Guid>("PollOptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Option")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PollId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PollOptionId");

                    b.HasIndex("PollId");

                    b.ToTable("PollOptions");
                });

            modelBuilder.Entity("GroupsApp.Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly>("BirthDay")
                        .HasColumnType("date");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GroupsApp.Models.UserEvent", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EventId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "EventId");

                    b.HasIndex("EventId");

                    b.ToTable("UserEvents");
                });

            modelBuilder.Entity("GroupsApp.Models.UsersFavoritePosts", b =>
                {
                    b.Property<Guid>("MarketplacePostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MarketplacePostId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersFavoritePosts");
                });

            modelBuilder.Entity("GroupsApp.Models.MarketplacePosts.DonationPost", b =>
                {
                    b.HasBaseType("GroupsApp.Models.MarketplacePosts.MarketplacePost");

                    b.Property<double>("CurrentDonationAmount")
                        .HasColumnType("float");

                    b.Property<string>("DonationLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Donation");
                });

            modelBuilder.Entity("GroupsApp.Models.MarketplacePosts.FixedPricePost", b =>
                {
                    b.HasBaseType("GroupsApp.Models.MarketplacePosts.MarketplacePost");

                    b.Property<string>("DeliveryType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsNegotiable")
                        .HasColumnType("bit");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasDiscriminator().HasValue("FixedPrice");
                });

            modelBuilder.Entity("GroupsApp.Models.MarketplacePosts.AuctionPost", b =>
                {
                    b.HasBaseType("GroupsApp.Models.MarketplacePosts.FixedPricePost");

                    b.Property<double>("CurrentBidPrice")
                        .HasColumnType("float");

                    b.Property<Guid>("CurrentPriceLeader")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("MinimumBidPrice")
                        .HasColumnType("float");

                    b.HasDiscriminator().HasValue("Auction");
                });

            modelBuilder.Entity("GroupsApp.Models.Cart", b =>
                {
                    b.HasOne("GroupsApp.Models.MarketplacePosts.MarketplacePost", null)
                        .WithMany()
                        .HasForeignKey("MarketplacePostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GroupsApp.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("GroupsApp.Models.Event", b =>
                {
                    b.HasOne("GroupsApp.Models.User", "Organizer")
                        .WithMany("OriganizedEvents")
                        .HasForeignKey("OrganizerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organizer");
                });

            modelBuilder.Entity("GroupsApp.Models.EventDonation", b =>
                {
                    b.HasOne("GroupsApp.Models.Event", "Event")
                        .WithMany("Donations")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GroupsApp.Models.User", "User")
                        .WithMany("EventDonationsMade")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GroupsApp.Models.EventExpense", b =>
                {
                    b.HasOne("GroupsApp.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");
                });

            modelBuilder.Entity("GroupsApp.Models.EventReview", b =>
                {
                    b.HasOne("GroupsApp.Models.Event", null)
                        .WithMany("Reviews")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GroupsApp.Models.Group", b =>
                {
                    b.HasOne("GroupsApp.Models.User", "Owner")
                        .WithMany("OwnedGroups")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("GroupsApp.Models.GroupPost", b =>
                {
                    b.HasOne("GroupsApp.Models.User", "Author")
                        .WithMany("GroupPosts")
                        .HasForeignKey("AuthorId");

                    b.HasOne("GroupsApp.Models.Group", "Group")
                        .WithMany("GroupPosts")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("GroupsApp.Models.JoinRequest", b =>
                {
                    b.HasOne("GroupsApp.Models.Group", "Group")
                        .WithMany("JoinRequests")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GroupsApp.Models.User", "User")
                        .WithMany("JoinRequests")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GroupsApp.Models.MarketPlacePostReview", b =>
                {
                    b.HasOne("GroupsApp.Models.MarketplacePosts.MarketplacePost", "MarketplacePost")
                        .WithMany("Reviews")
                        .HasForeignKey("MarketplacePostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GroupsApp.Models.User", "Reviewer")
                        .WithMany("MarketPlacePostReviewsMade")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MarketplacePost");

                    b.Navigation("Reviewer");
                });

            modelBuilder.Entity("GroupsApp.Models.MarketplacePosts.MarketplacePost", b =>
                {
                    b.HasOne("GroupsApp.Models.User", "Author")
                        .WithMany("MarketplacePosts")
                        .HasForeignKey("AuthorId");

                    b.HasOne("GroupsApp.Models.Group", "Group")
                        .WithMany("MarketplacePosts")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("GroupsApp.Models.Membership", b =>
                {
                    b.HasOne("GroupsApp.Models.Group", "Group")
                        .WithMany("Memberships")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GroupsApp.Models.User", "User")
                        .WithMany("Memberships")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GroupsApp.Models.Poll", b =>
                {
                    b.HasOne("GroupsApp.Models.Group", "Group")
                        .WithMany("GroupPolls")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("GroupsApp.Models.PollAnswer", b =>
                {
                    b.HasOne("GroupsApp.Models.PollOption", "PollOption")
                        .WithMany("PollAnswers")
                        .HasForeignKey("PollOptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GroupsApp.Models.User", "UserThatAnswered")
                        .WithMany("PollAnswers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("PollOption");

                    b.Navigation("UserThatAnswered");
                });

            modelBuilder.Entity("GroupsApp.Models.PollOption", b =>
                {
                    b.HasOne("GroupsApp.Models.Poll", "Poll")
                        .WithMany("PollOptions")
                        .HasForeignKey("PollId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Poll");
                });

            modelBuilder.Entity("GroupsApp.Models.UserEvent", b =>
                {
                    b.HasOne("GroupsApp.Models.Event", null)
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GroupsApp.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GroupsApp.Models.UsersFavoritePosts", b =>
                {
                    b.HasOne("GroupsApp.Models.MarketplacePosts.MarketplacePost", null)
                        .WithMany()
                        .HasForeignKey("MarketplacePostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GroupsApp.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("GroupsApp.Models.Event", b =>
                {
                    b.Navigation("Donations");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("GroupsApp.Models.Group", b =>
                {
                    b.Navigation("GroupPolls");

                    b.Navigation("GroupPosts");

                    b.Navigation("JoinRequests");

                    b.Navigation("MarketplacePosts");

                    b.Navigation("Memberships");
                });

            modelBuilder.Entity("GroupsApp.Models.MarketplacePosts.MarketplacePost", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("GroupsApp.Models.Poll", b =>
                {
                    b.Navigation("PollOptions");
                });

            modelBuilder.Entity("GroupsApp.Models.PollOption", b =>
                {
                    b.Navigation("PollAnswers");
                });

            modelBuilder.Entity("GroupsApp.Models.User", b =>
                {
                    b.Navigation("EventDonationsMade");

                    b.Navigation("GroupPosts");

                    b.Navigation("JoinRequests");

                    b.Navigation("MarketPlacePostReviewsMade");

                    b.Navigation("MarketplacePosts");

                    b.Navigation("Memberships");

                    b.Navigation("OriganizedEvents");

                    b.Navigation("OwnedGroups");

                    b.Navigation("PollAnswers");
                });
#pragma warning restore 612, 618
        }
    }
}
