using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoonGameRev.Data.Migrations
{
    public partial class EditedRatingForReviewModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Rating",
                table: "Reviews",
                type: "float",
                nullable: false,
                comment: "Rating given by the user for the game",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Rating given by the user for the game");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "Reviews",
                type: "int",
                nullable: false,
                comment: "Rating given by the user for the game",
                oldClrType: typeof(double),
                oldType: "float",
                oldComment: "Rating given by the user for the game");
        }
    }
}
