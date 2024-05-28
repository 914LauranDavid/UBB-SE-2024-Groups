using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GroupsApp.Migrations
{
    /// <inheritdoc />
    public partial class MarketplacePostType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "TestMarketplacePost");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "TestMarketplacePost");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "TestMarketplacePost",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "TestMarketplacePost");

            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "TestMarketplacePost",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GroupId",
                table: "TestMarketplacePost",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
