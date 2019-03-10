using Microsoft.EntityFrameworkCore.Migrations;

namespace CookingDatabase.Migrations
{
    public partial class AddMaden : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Maden",
                table: "Foods",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Maden",
                table: "Foods");
        }
    }
}
