using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoonGameRev.Data.Migrations
{
    public partial class FixingJournalistEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Journalists_AspNetUsers_UserId1",
                table: "Journalists");

            migrationBuilder.DropIndex(
                name: "IX_Journalists_UserId1",
                table: "Journalists");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Journalists");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Journalists",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Journalists_UserId",
                table: "Journalists",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Journalists_AspNetUsers_UserId",
                table: "Journalists",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Journalists_AspNetUsers_UserId",
                table: "Journalists");

            migrationBuilder.DropIndex(
                name: "IX_Journalists_UserId",
                table: "Journalists");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Journalists",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId1",
                table: "Journalists",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Journalists_UserId1",
                table: "Journalists",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Journalists_AspNetUsers_UserId1",
                table: "Journalists",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
