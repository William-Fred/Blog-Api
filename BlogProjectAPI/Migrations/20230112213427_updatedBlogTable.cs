using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogProjectAPI.Migrations
{
    public partial class updatedBlogTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EntryDate",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Blogs");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "identityUserId",
                table: "Blogs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "postedDate",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_identityUserId",
                table: "Blogs",
                column: "identityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_AspNetUsers_identityUserId",
                table: "Blogs",
                column: "identityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_AspNetUsers_identityUserId",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_identityUserId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "identityUserId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "postedDate",
                table: "Blogs");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "EntryDate",
                table: "Blogs",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Blogs",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
