using Microsoft.EntityFrameworkCore.Migrations;

namespace HabiTree2.Migrations
{
    public partial class vetigge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FridayStatus",
                table: "Habit");

            migrationBuilder.DropColumn(
                name: "MondayStatus",
                table: "Habit");

            migrationBuilder.DropColumn(
                name: "SaturdayStatus",
                table: "Habit");

            migrationBuilder.DropColumn(
                name: "SundayStatus",
                table: "Habit");

            migrationBuilder.DropColumn(
                name: "ThursdayStatus",
                table: "Habit");

            migrationBuilder.DropColumn(
                name: "TuesdayStatus",
                table: "Habit");

            migrationBuilder.DropColumn(
                name: "WednesdayStatus",
                table: "Habit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FridayStatus",
                table: "Habit",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MondayStatus",
                table: "Habit",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SaturdayStatus",
                table: "Habit",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SundayStatus",
                table: "Habit",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ThursdayStatus",
                table: "Habit",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TuesdayStatus",
                table: "Habit",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WednesdayStatus",
                table: "Habit",
                nullable: false,
                defaultValue: 0);
        }
    }
}
