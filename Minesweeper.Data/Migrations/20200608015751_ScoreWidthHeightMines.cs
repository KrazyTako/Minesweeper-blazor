using Microsoft.EntityFrameworkCore.Migrations;

namespace Minesweeper.Data.Migrations
{
    public partial class ScoreWidthHeightMines : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Points",
                table: "Scores");

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "Scores",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MineCount",
                table: "Scores",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Width",
                table: "Scores",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Height",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "MineCount",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "Scores");

            migrationBuilder.AddColumn<int>(
                name: "Points",
                table: "Scores",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
