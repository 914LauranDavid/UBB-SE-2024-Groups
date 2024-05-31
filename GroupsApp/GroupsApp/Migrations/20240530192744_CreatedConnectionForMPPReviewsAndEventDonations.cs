using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GroupsApp.Migrations
{
    /// <inheritdoc />
    public partial class CreatedConnectionForMPPReviewsAndEventDonations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MarketplacePostId",
                table: "MarketPlacePostReviews",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "MarketPlacePostReviews",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_MarketPlacePostReviews_MarketplacePostId",
                table: "MarketPlacePostReviews",
                column: "MarketplacePostId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketPlacePostReviews_UserId",
                table: "MarketPlacePostReviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EventReviews_EventId",
                table: "EventReviews",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventDonations_EventId",
                table: "EventDonations",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventDonations_UserId",
                table: "EventDonations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventDonations_Events_EventId",
                table: "EventDonations",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_EventDonations_Users_UserId",
                table: "EventDonations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventReviews_Events_EventId",
                table: "EventReviews",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MarketPlacePostReviews_MarketplacePosts_MarketplacePostId",
                table: "MarketPlacePostReviews",
                column: "MarketplacePostId",
                principalTable: "MarketplacePosts",
                principalColumn: "MarketplacePostId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_MarketPlacePostReviews_Users_UserId",
                table: "MarketPlacePostReviews",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventDonations_Events_EventId",
                table: "EventDonations");

            migrationBuilder.DropForeignKey(
                name: "FK_EventDonations_Users_UserId",
                table: "EventDonations");

            migrationBuilder.DropForeignKey(
                name: "FK_EventReviews_Events_EventId",
                table: "EventReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_MarketPlacePostReviews_MarketplacePosts_MarketplacePostId",
                table: "MarketPlacePostReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_MarketPlacePostReviews_Users_UserId",
                table: "MarketPlacePostReviews");

            migrationBuilder.DropIndex(
                name: "IX_MarketPlacePostReviews_MarketplacePostId",
                table: "MarketPlacePostReviews");

            migrationBuilder.DropIndex(
                name: "IX_MarketPlacePostReviews_UserId",
                table: "MarketPlacePostReviews");

            migrationBuilder.DropIndex(
                name: "IX_EventReviews_EventId",
                table: "EventReviews");

            migrationBuilder.DropIndex(
                name: "IX_EventDonations_EventId",
                table: "EventDonations");

            migrationBuilder.DropIndex(
                name: "IX_EventDonations_UserId",
                table: "EventDonations");

            migrationBuilder.DropColumn(
                name: "MarketplacePostId",
                table: "MarketPlacePostReviews");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MarketPlacePostReviews");
        }
    }
}
