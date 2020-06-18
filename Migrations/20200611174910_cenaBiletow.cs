using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjektImplementacja.Migrations
{
    public partial class cenaBiletow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "CenaBiletow",
                table: "Eventy",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CenaBiletow",
                table: "Eventy");
        }
    }
}
