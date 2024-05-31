using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GroupsApp.Migrations
{
    /// <inheritdoc />
    public partial class CreatedConnectionForreviewreportsandshiet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventGUID",
                table: "EventExpenses");

            migrationBuilder.AddColumn<Guid>(
                name: "PostId",
                table: "GroupPostReports",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "GroupPostReports",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_GroupPostReports_PostId",
                table: "GroupPostReports",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupPostReports_UserId",
                table: "GroupPostReports",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EventReports_EventId",
                table: "EventReports",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventReports_Events_EventId",
                table: "EventReports",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_EventReports_Users_UserId",
                table: "EventReports",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventReviews_Users_UserId",
                table: "EventReviews",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupPostReports_GroupPosts_PostId",
                table: "GroupPostReports",
                column: "PostId",
                principalTable: "GroupPosts",
                principalColumn: "GroupPostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupPostReports_Users_UserId",
                table: "GroupPostReports",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventReports_Events_EventId",
                table: "EventReports");

            migrationBuilder.DropForeignKey(
                name: "FK_EventReports_Users_UserId",
                table: "EventReports");

            migrationBuilder.DropForeignKey(
                name: "FK_EventReviews_Users_UserId",
                table: "EventReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupPostReports_GroupPosts_PostId",
                table: "GroupPostReports");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupPostReports_Users_UserId",
                table: "GroupPostReports");

            migrationBuilder.DropIndex(
                name: "IX_GroupPostReports_PostId",
                table: "GroupPostReports");

            migrationBuilder.DropIndex(
                name: "IX_GroupPostReports_UserId",
                table: "GroupPostReports");

            migrationBuilder.DropIndex(
                name: "IX_EventReports_EventId",
                table: "EventReports");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "GroupPostReports");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "GroupPostReports");

            migrationBuilder.AddColumn<Guid>(
                name: "EventGUID",
                table: "EventExpenses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
