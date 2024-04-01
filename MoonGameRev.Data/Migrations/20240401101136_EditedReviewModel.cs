using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoonGameRev.Data.Migrations
{
    public partial class EditedReviewModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReviewDate",
                table: "Reviews",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                comment: "Date and time when the review was submitted.",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Date and time when the review was submitted.");

            migrationBuilder.AddColumn<string>(
                name: "Cons",
                table: "Reviews",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                comment: "The Cons of the game");

            migrationBuilder.AddColumn<string>(
                name: "Pros",
                table: "Reviews",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                comment: "The Pros of the game");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cons",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "Pros",
                table: "Reviews");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReviewDate",
                table: "Reviews",
                type: "datetime2",
                nullable: false,
                comment: "Date and time when the review was submitted.",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()",
                oldComment: "Date and time when the review was submitted.");
        }
    }
}
