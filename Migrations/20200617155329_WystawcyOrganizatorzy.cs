using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjektImplementacja.Migrations
{
    public partial class WystawcyOrganizatorzy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrganizatorIdOrganizator",
                table: "Wystawcy",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wystawcy_OrganizatorIdOrganizator",
                table: "Wystawcy",
                column: "OrganizatorIdOrganizator");

            migrationBuilder.AddForeignKey(
                name: "FK_Wystawcy_Organizatorzy_OrganizatorIdOrganizator",
                table: "Wystawcy",
                column: "OrganizatorIdOrganizator",
                principalTable: "Organizatorzy",
                principalColumn: "IdOrganizator",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wystawcy_Organizatorzy_OrganizatorIdOrganizator",
                table: "Wystawcy");

            migrationBuilder.DropIndex(
                name: "IX_Wystawcy_OrganizatorIdOrganizator",
                table: "Wystawcy");

            migrationBuilder.DropColumn(
                name: "OrganizatorIdOrganizator",
                table: "Wystawcy");
        }
    }
}
