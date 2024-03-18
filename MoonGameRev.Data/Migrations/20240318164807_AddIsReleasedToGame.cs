using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoonGameRev.Data.Migrations
{
    public partial class AddIsReleasedToGame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsReleased",
                table: "Games",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Specifies whether the game is released or upcoming.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsReleased",
                table: "Games");
        }
    }
}
