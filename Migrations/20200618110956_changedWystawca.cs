using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjektImplementacja.Migrations
{
    public partial class changedWystawca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RodzajStoiska",
                table: "Wystawcy",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RodzajStoiska",
                table: "Wystawcy");
        }
    }
}
