using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GroupsApp.Migrations
{
    /// <inheritdoc />
    public partial class useridentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_AspNetUsers_UserId",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_AspNetUsers_UserId1",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_EventDonations_AspNetUsers_UserId",
                table: "EventDonations");

            migrationBuilder.DropForeignKey(
                name: "FK_EventReports_AspNetUsers_UserId",
                table: "EventReports");

            migrationBuilder.DropForeignKey(
                name: "FK_EventReviews_AspNetUsers_UserId",
                table: "EventReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_AspNetUsers_OrganizerId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_EventUser_AspNetUsers_UsersUserId",
                table: "EventUser");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupPostReports_AspNetUsers_UserId",
                table: "GroupPostReports");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupPosts_AspNetUsers_AuthorId",
                table: "GroupPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_AspNetUsers_OwnerId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_JoinRequests_AspNetUsers_UserId",
                table: "JoinRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_MarketplacePostReviews_AspNetUsers_UserId",
                table: "MarketplacePostReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_MarketplacePosts_AspNetUsers_AuthorId",
                table: "MarketplacePosts");

            migrationBuilder.DropForeignKey(
                name: "FK_Memberships_AspNetUsers_UserId",
                table: "Memberships");

            migrationBuilder.DropForeignKey(
                name: "FK_PollAnswers_AspNetUsers_UserId",
                table: "PollAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserEvents_AspNetUsers_UserId",
                table: "UserEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersFavoritePosts_AspNetUsers_UserId",
                table: "UsersFavoritePosts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "UsersUserId",
                table: "EventUser",
                newName: "UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_EventUser_UsersUserId",
                table: "EventUser",
                newName: "IX_EventUser_UsersId");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_AspNetUsers_UserId",
                table: "Cart",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_AspNetUsers_UserId1",
                table: "Cart",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventDonations_AspNetUsers_UserId",
                table: "EventDonations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventReports_AspNetUsers_UserId",
                table: "EventReports",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventReviews_AspNetUsers_UserId",
                table: "EventReviews",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_AspNetUsers_OrganizerId",
                table: "Events",
                column: "OrganizerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventUser_AspNetUsers_UsersId",
                table: "EventUser",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupPostReports_AspNetUsers_UserId",
                table: "GroupPostReports",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupPosts_AspNetUsers_AuthorId",
                table: "GroupPosts",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_AspNetUsers_OwnerId",
                table: "Groups",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JoinRequests_AspNetUsers_UserId",
                table: "JoinRequests",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MarketplacePostReviews_AspNetUsers_UserId",
                table: "MarketplacePostReviews",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MarketplacePosts_AspNetUsers_AuthorId",
                table: "MarketplacePosts",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Memberships_AspNetUsers_UserId",
                table: "Memberships",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PollAnswers_AspNetUsers_UserId",
                table: "PollAnswers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserEvents_AspNetUsers_UserId",
                table: "UserEvents",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersFavoritePosts_AspNetUsers_UserId",
                table: "UsersFavoritePosts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_AspNetUsers_UserId",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_AspNetUsers_UserId1",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_EventDonations_AspNetUsers_UserId",
                table: "EventDonations");

            migrationBuilder.DropForeignKey(
                name: "FK_EventReports_AspNetUsers_UserId",
                table: "EventReports");

            migrationBuilder.DropForeignKey(
                name: "FK_EventReviews_AspNetUsers_UserId",
                table: "EventReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_AspNetUsers_OrganizerId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_EventUser_AspNetUsers_UsersId",
                table: "EventUser");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupPostReports_AspNetUsers_UserId",
                table: "GroupPostReports");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupPosts_AspNetUsers_AuthorId",
                table: "GroupPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_AspNetUsers_OwnerId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_JoinRequests_AspNetUsers_UserId",
                table: "JoinRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_MarketplacePostReviews_AspNetUsers_UserId",
                table: "MarketplacePostReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_MarketplacePosts_AspNetUsers_AuthorId",
                table: "MarketplacePosts");

            migrationBuilder.DropForeignKey(
                name: "FK_Memberships_AspNetUsers_UserId",
                table: "Memberships");

            migrationBuilder.DropForeignKey(
                name: "FK_PollAnswers_AspNetUsers_UserId",
                table: "PollAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserEvents_AspNetUsers_UserId",
                table: "UserEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersFavoritePosts_AspNetUsers_UserId",
                table: "UsersFavoritePosts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "EventUser",
                newName: "UsersUserId");

            migrationBuilder.RenameIndex(
                name: "IX_EventUser_UsersId",
                table: "EventUser",
                newName: "IX_EventUser_UsersUserId");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_AspNetUsers_UserId",
                table: "Cart",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_AspNetUsers_UserId1",
                table: "Cart",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventDonations_AspNetUsers_UserId",
                table: "EventDonations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventReports_AspNetUsers_UserId",
                table: "EventReports",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventReviews_AspNetUsers_UserId",
                table: "EventReviews",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_AspNetUsers_OrganizerId",
                table: "Events",
                column: "OrganizerId",
                principalTable: "AspNetUsers",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventUser_AspNetUsers_UsersUserId",
                table: "EventUser",
                column: "UsersUserId",
                principalTable: "AspNetUsers",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupPostReports_AspNetUsers_UserId",
                table: "GroupPostReports",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupPosts_AspNetUsers_AuthorId",
                table: "GroupPosts",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_AspNetUsers_OwnerId",
                table: "Groups",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_JoinRequests_AspNetUsers_UserId",
                table: "JoinRequests",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MarketplacePostReviews_AspNetUsers_UserId",
                table: "MarketplacePostReviews",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MarketplacePosts_AspNetUsers_AuthorId",
                table: "MarketplacePosts",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Memberships_AspNetUsers_UserId",
                table: "Memberships",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PollAnswers_AspNetUsers_UserId",
                table: "PollAnswers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserEvents_AspNetUsers_UserId",
                table: "UserEvents",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersFavoritePosts_AspNetUsers_UserId",
                table: "UsersFavoritePosts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "UserId");
        }
    }
}
