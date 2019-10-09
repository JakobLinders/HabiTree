using Microsoft.EntityFrameworkCore.Migrations;

namespace HabiTree2.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FridayStatus",
                table: "UserHabit",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MondayStatus",
                table: "UserHabit",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SaturdayStatus",
                table: "UserHabit",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SundayStatus",
                table: "UserHabit",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ThursdayStatus",
                table: "UserHabit",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TuesdayStatus",
                table: "UserHabit",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WednesdayStatus",
                table: "UserHabit",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FridayStatus",
                table: "UserHabit");

            migrationBuilder.DropColumn(
                name: "MondayStatus",
                table: "UserHabit");

            migrationBuilder.DropColumn(
                name: "SaturdayStatus",
                table: "UserHabit");

            migrationBuilder.DropColumn(
                name: "SundayStatus",
                table: "UserHabit");

            migrationBuilder.DropColumn(
                name: "ThursdayStatus",
                table: "UserHabit");

            migrationBuilder.DropColumn(
                name: "TuesdayStatus",
                table: "UserHabit");

            migrationBuilder.DropColumn(
                name: "WednesdayStatus",
                table: "UserHabit");
        }
    }
}
