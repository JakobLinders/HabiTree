using Microsoft.EntityFrameworkCore.Migrations;

namespace HabiTree2.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Monday",
                table: "WeekResults",
                newName: "MondayDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MondayDate",
                table: "WeekResults",
                newName: "Monday");
        }
    }
}
