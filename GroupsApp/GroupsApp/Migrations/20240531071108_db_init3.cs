using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GroupsApp.Migrations
{
    /// <inheritdoc />
    public partial class db_init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MarketPlacePostReviews_MarketplacePosts_MarketplacePostId",
                table: "MarketPlacePostReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_MarketPlacePostReviews_Users_UserId",
                table: "MarketPlacePostReviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersFavoritePosts",
                table: "UsersFavoritePosts");

            migrationBuilder.DropIndex(
                name: "IX_UsersFavoritePosts_UserId",
                table: "UsersFavoritePosts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MarketPlacePostReviews",
                table: "MarketPlacePostReviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cart",
                table: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Cart_UserId",
                table: "Cart");

            migrationBuilder.RenameTable(
                name: "MarketPlacePostReviews",
                newName: "MarketplacePostReviews");

            migrationBuilder.RenameIndex(
                name: "IX_MarketPlacePostReviews_UserId",
                table: "MarketplacePostReviews",
                newName: "IX_MarketplacePostReviews_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_MarketPlacePostReviews_MarketplacePostId",
                table: "MarketplacePostReviews",
                newName: "IX_MarketplacePostReviews_MarketplacePostId");

            migrationBuilder.AddColumn<Guid>(
                name: "MarketplacePostId1",
                table: "Cart",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId1",
                table: "Cart",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersFavoritePosts",
                table: "UsersFavoritePosts",
                columns: new[] { "UserId", "MarketplacePostId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MarketplacePostReviews",
                table: "MarketplacePostReviews",
                column: "ReviewId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cart",
                table: "Cart",
                columns: new[] { "UserId", "MarketplacePostId" });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Comments_CommentId1",
                        column: x => x.CommentId1,
                        principalTable: "Comments",
                        principalColumn: "CommentId");
                });

            migrationBuilder.CreateTable(
                name: "EventUser",
                columns: table => new
                {
                    EventsEventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventUser", x => new { x.EventsEventId, x.UsersUserId });
                    table.ForeignKey(
                        name: "FK_EventUser_Events_EventsEventId",
                        column: x => x.EventsEventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventUser_Users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InterestStatuses",
                columns: table => new
                {
                    InterestStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestStatuses", x => x.InterestStatusId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersFavoritePosts_MarketplacePostId",
                table: "UsersFavoritePosts",
                column: "MarketplacePostId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_MarketplacePostId",
                table: "Cart",
                column: "MarketplacePostId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_MarketplacePostId1",
                table: "Cart",
                column: "MarketplacePostId1");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_UserId1",
                table: "Cart",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommentId1",
                table: "Comments",
                column: "CommentId1");

            migrationBuilder.CreateIndex(
                name: "IX_EventUser_UsersUserId",
                table: "EventUser",
                column: "UsersUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_MarketplacePosts_MarketplacePostId1",
                table: "Cart",
                column: "MarketplacePostId1",
                principalTable: "MarketplacePosts",
                principalColumn: "MarketplacePostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Users_UserId1",
                table: "Cart",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MarketplacePostReviews_MarketplacePosts_MarketplacePostId",
                table: "MarketplacePostReviews",
                column: "MarketplacePostId",
                principalTable: "MarketplacePosts",
                principalColumn: "MarketplacePostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MarketplacePostReviews_Users_UserId",
                table: "MarketplacePostReviews",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_MarketplacePosts_MarketplacePostId1",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Users_UserId1",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_MarketplacePostReviews_MarketplacePosts_MarketplacePostId",
                table: "MarketplacePostReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_MarketplacePostReviews_Users_UserId",
                table: "MarketplacePostReviews");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "EventUser");

            migrationBuilder.DropTable(
                name: "InterestStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersFavoritePosts",
                table: "UsersFavoritePosts");

            migrationBuilder.DropIndex(
                name: "IX_UsersFavoritePosts_MarketplacePostId",
                table: "UsersFavoritePosts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MarketplacePostReviews",
                table: "MarketplacePostReviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cart",
                table: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Cart_MarketplacePostId",
                table: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Cart_MarketplacePostId1",
                table: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Cart_UserId1",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "MarketplacePostId1",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Cart");

            migrationBuilder.RenameTable(
                name: "MarketplacePostReviews",
                newName: "MarketPlacePostReviews");

            migrationBuilder.RenameIndex(
                name: "IX_MarketplacePostReviews_UserId",
                table: "MarketPlacePostReviews",
                newName: "IX_MarketPlacePostReviews_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_MarketplacePostReviews_MarketplacePostId",
                table: "MarketPlacePostReviews",
                newName: "IX_MarketPlacePostReviews_MarketplacePostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersFavoritePosts",
                table: "UsersFavoritePosts",
                columns: new[] { "MarketplacePostId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MarketPlacePostReviews",
                table: "MarketPlacePostReviews",
                column: "ReviewId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cart",
                table: "Cart",
                columns: new[] { "MarketplacePostId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_UsersFavoritePosts_UserId",
                table: "UsersFavoritePosts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_UserId",
                table: "Cart",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MarketPlacePostReviews_MarketplacePosts_MarketplacePostId",
                table: "MarketPlacePostReviews",
                column: "MarketplacePostId",
                principalTable: "MarketplacePosts",
                principalColumn: "MarketplacePostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MarketPlacePostReviews_Users_UserId",
                table: "MarketPlacePostReviews",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
