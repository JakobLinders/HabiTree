using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HabiTree2.Migrations
{
    public partial class addedWeekResults : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "WeekResults",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Monday = table.Column<DateTime>(nullable: false),
                    userHabitAppUserId = table.Column<string>(nullable: true),
                    userHabitHabitId = table.Column<int>(nullable: true),
                    Monday_StatusCode = table.Column<int>(nullable: false),
                    Tuesday_StatusCode = table.Column<int>(nullable: false),
                    Wednesday_StatusCode = table.Column<int>(nullable: false),
                    Thursday_StatusCode = table.Column<int>(nullable: false),
                    Friday_StatusCode = table.Column<int>(nullable: false),
                    Saturday_StatusCode = table.Column<int>(nullable: false),
                    Sunday_StatusCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeekResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeekResults_UserHabit_userHabitAppUserId_userHabitHabitId",
                        columns: x => new { x.userHabitAppUserId, x.userHabitHabitId },
                        principalTable: "UserHabit",
                        principalColumns: new[] { "AppUserId", "HabitId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeekResults_userHabitAppUserId_userHabitHabitId",
                table: "WeekResults",
                columns: new[] { "userHabitAppUserId", "userHabitHabitId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeekResults");

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
    }
}
