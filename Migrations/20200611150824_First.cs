using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjektImplementacja.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MiejscaEventu",
                columns: table => new
                {
                    IdMiejsceEventu = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WolneMiejsca = table.Column<int>(nullable: false),
                    Adres = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiejscaEventu", x => x.IdMiejsceEventu);
                });

            migrationBuilder.CreateTable(
                name: "Nagrody",
                columns: table => new
                {
                    IdNagroda = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(nullable: false),
                    Wartosc = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nagrody", x => x.IdNagroda);
                });

            migrationBuilder.CreateTable(
                name: "Organizatorzy",
                columns: table => new
                {
                    IdOrganizator = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizatorzy", x => x.IdOrganizator);
                });

            migrationBuilder.CreateTable(
                name: "Pracownicy",
                columns: table => new
                {
                    IdPracownik = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PESEL = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pracownicy", x => x.IdPracownik);
                });

            migrationBuilder.CreateTable(
                name: "Uczestnicy",
                columns: table => new
                {
                    IdUczestnik = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uczestnicy", x => x.IdUczestnik);
                });

            migrationBuilder.CreateTable(
                name: "Wystawcy",
                columns: table => new
                {
                    IdWystawca = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaFirmy = table.Column<string>(maxLength: 20, nullable: false),
                    RozmiarStoiska = table.Column<float>(nullable: false),
                    DaneKontaktowe = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wystawcy", x => x.IdWystawca);
                });

            migrationBuilder.CreateTable(
                name: "Eventy",
                columns: table => new
                {
                    IdEvent = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaEventu = table.Column<string>(nullable: false),
                    DataRozpoczecia = table.Column<DateTime>(nullable: false),
                    DataZakonczenia = table.Column<DateTime>(nullable: false),
                    IloscMiejsc = table.Column<int>(nullable: false),
                    Tematyka = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    OrganizatorIdOrganizator = table.Column<int>(nullable: false),
                    MiejsceEventuIdMiejsceEventu = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventy", x => x.IdEvent);
                    table.ForeignKey(
                        name: "FK_Eventy_MiejscaEventu_MiejsceEventuIdMiejsceEventu",
                        column: x => x.MiejsceEventuIdMiejsceEventu,
                        principalTable: "MiejscaEventu",
                        principalColumn: "IdMiejsceEventu",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Eventy_Organizatorzy_OrganizatorIdOrganizator",
                        column: x => x.OrganizatorIdOrganizator,
                        principalTable: "Organizatorzy",
                        principalColumn: "IdOrganizator",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Uzytkownicy",
                columns: table => new
                {
                    IdUzytkownik = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaUzytkownika = table.Column<string>(maxLength: 12, nullable: false),
                    Haslo = table.Column<string>(maxLength: 20, nullable: false),
                    Imie = table.Column<string>(nullable: false),
                    Nazwisko = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    NumerTelefonu = table.Column<string>(nullable: false),
                    IdOrganizator = table.Column<int>(nullable: false),
                    IdUczestnik = table.Column<int>(nullable: false),
                    IdPracownik = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uzytkownicy", x => x.IdUzytkownik);
                    table.ForeignKey(
                        name: "FK_Uzytkownicy_Organizatorzy_IdOrganizator",
                        column: x => x.IdOrganizator,
                        principalTable: "Organizatorzy",
                        principalColumn: "IdOrganizator",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Uzytkownicy_Pracownicy_IdPracownik",
                        column: x => x.IdPracownik,
                        principalTable: "Pracownicy",
                        principalColumn: "IdPracownik",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Uzytkownicy_Uczestnicy_IdUczestnik",
                        column: x => x.IdUczestnik,
                        principalTable: "Uczestnicy",
                        principalColumn: "IdUczestnik",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Atrakcje",
                columns: table => new
                {
                    IdAtrakcja = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(nullable: false),
                    Czas = table.Column<DateTime>(nullable: false),
                    Opis = table.Column<string>(nullable: false),
                    PracownikIdPracownik = table.Column<int>(nullable: true),
                    IdPracownik = table.Column<int>(nullable: false),
                    EventIdEvent = table.Column<int>(nullable: false),
                    IdEvent = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    IdNagroda = table.Column<int>(nullable: true),
                    Miejsce = table.Column<string>(nullable: true),
                    IloscMiejsc = table.Column<int>(nullable: true),
                    PanelKonkursowyIdAtrakcja = table.Column<int>(nullable: true),
                    IdKonkurs = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atrakcje", x => x.IdAtrakcja);
                    table.ForeignKey(
                        name: "FK_Atrakcje_Eventy_EventIdEvent",
                        column: x => x.EventIdEvent,
                        principalTable: "Eventy",
                        principalColumn: "IdEvent",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Atrakcje_Pracownicy_PracownikIdPracownik",
                        column: x => x.PracownikIdPracownik,
                        principalTable: "Pracownicy",
                        principalColumn: "IdPracownik",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Atrakcje_Nagrody_IdNagroda",
                        column: x => x.IdNagroda,
                        principalTable: "Nagrody",
                        principalColumn: "IdNagroda",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Atrakcje_Atrakcje_PanelKonkursowyIdAtrakcja",
                        column: x => x.PanelKonkursowyIdAtrakcja,
                        principalTable: "Atrakcje",
                        principalColumn: "IdAtrakcja",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Atrakcje_Atrakcje_IdKonkurs",
                        column: x => x.IdKonkurs,
                        principalTable: "Atrakcje",
                        principalColumn: "IdAtrakcja",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bilety",
                columns: table => new
                {
                    IdBilet = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Typ = table.Column<string>(nullable: true),
                    UczestnikIdUczestnik = table.Column<int>(nullable: false),
                    EventIdEvent = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bilety", x => x.IdBilet);
                    table.ForeignKey(
                        name: "FK_Bilety_Eventy_EventIdEvent",
                        column: x => x.EventIdEvent,
                        principalTable: "Eventy",
                        principalColumn: "IdEvent",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bilety_Uczestnicy_UczestnikIdUczestnik",
                        column: x => x.UczestnikIdUczestnik,
                        principalTable: "Uczestnicy",
                        principalColumn: "IdUczestnik",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Event_Pracownicy",
                columns: table => new
                {
                    IdEvent = table.Column<int>(nullable: false),
                    IdPracownik = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event_Pracownicy", x => new { x.IdEvent, x.IdPracownik });
                    table.ForeignKey(
                        name: "FK_Event_Pracownicy_Eventy_IdEvent",
                        column: x => x.IdEvent,
                        principalTable: "Eventy",
                        principalColumn: "IdEvent",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Event_Pracownicy_Pracownicy_IdPracownik",
                        column: x => x.IdPracownik,
                        principalTable: "Pracownicy",
                        principalColumn: "IdPracownik",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Event_Wystawcy",
                columns: table => new
                {
                    IdEvent = table.Column<int>(nullable: false),
                    IdWystawca = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event_Wystawcy", x => new { x.IdWystawca, x.IdEvent });
                    table.ForeignKey(
                        name: "FK_Event_Wystawcy_Eventy_IdEvent",
                        column: x => x.IdEvent,
                        principalTable: "Eventy",
                        principalColumn: "IdEvent",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Event_Wystawcy_Wystawcy_IdWystawca",
                        column: x => x.IdWystawca,
                        principalTable: "Wystawcy",
                        principalColumn: "IdWystawca",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Atrakcja_Uczestnicy",
                columns: table => new
                {
                    IdAtrakcja = table.Column<int>(nullable: false),
                    IdUczestnik = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atrakcja_Uczestnicy", x => new { x.IdAtrakcja, x.IdUczestnik });
                    table.ForeignKey(
                        name: "FK_Atrakcja_Uczestnicy_Atrakcje_IdAtrakcja",
                        column: x => x.IdAtrakcja,
                        principalTable: "Atrakcje",
                        principalColumn: "IdAtrakcja",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Atrakcja_Uczestnicy_Uczestnicy_IdUczestnik",
                        column: x => x.IdUczestnik,
                        principalTable: "Uczestnicy",
                        principalColumn: "IdUczestnik",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atrakcja_Uczestnicy_IdUczestnik",
                table: "Atrakcja_Uczestnicy",
                column: "IdUczestnik");

            migrationBuilder.CreateIndex(
                name: "IX_Atrakcje_EventIdEvent",
                table: "Atrakcje",
                column: "EventIdEvent");

            migrationBuilder.CreateIndex(
                name: "IX_Atrakcje_PracownikIdPracownik",
                table: "Atrakcje",
                column: "PracownikIdPracownik");

            migrationBuilder.CreateIndex(
                name: "IX_Atrakcje_IdNagroda",
                table: "Atrakcje",
                column: "IdNagroda",
                unique: true,
                filter: "[IdNagroda] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Atrakcje_PanelKonkursowyIdAtrakcja",
                table: "Atrakcje",
                column: "PanelKonkursowyIdAtrakcja");

            migrationBuilder.CreateIndex(
                name: "IX_Atrakcje_IdKonkurs",
                table: "Atrakcje",
                column: "IdKonkurs",
                unique: true,
                filter: "[IdKonkurs] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Bilety_EventIdEvent",
                table: "Bilety",
                column: "EventIdEvent");

            migrationBuilder.CreateIndex(
                name: "IX_Bilety_UczestnikIdUczestnik",
                table: "Bilety",
                column: "UczestnikIdUczestnik");

            migrationBuilder.CreateIndex(
                name: "IX_Event_Pracownicy_IdPracownik",
                table: "Event_Pracownicy",
                column: "IdPracownik");

            migrationBuilder.CreateIndex(
                name: "IX_Event_Wystawcy_IdEvent",
                table: "Event_Wystawcy",
                column: "IdEvent");

            migrationBuilder.CreateIndex(
                name: "IX_Eventy_MiejsceEventuIdMiejsceEventu",
                table: "Eventy",
                column: "MiejsceEventuIdMiejsceEventu");

            migrationBuilder.CreateIndex(
                name: "IX_Eventy_OrganizatorIdOrganizator",
                table: "Eventy",
                column: "OrganizatorIdOrganizator");

            migrationBuilder.CreateIndex(
                name: "IX_Uzytkownicy_IdOrganizator",
                table: "Uzytkownicy",
                column: "IdOrganizator",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Uzytkownicy_IdPracownik",
                table: "Uzytkownicy",
                column: "IdPracownik",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Uzytkownicy_IdUczestnik",
                table: "Uzytkownicy",
                column: "IdUczestnik",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atrakcja_Uczestnicy");

            migrationBuilder.DropTable(
                name: "Bilety");

            migrationBuilder.DropTable(
                name: "Event_Pracownicy");

            migrationBuilder.DropTable(
                name: "Event_Wystawcy");

            migrationBuilder.DropTable(
                name: "Uzytkownicy");

            migrationBuilder.DropTable(
                name: "Atrakcje");

            migrationBuilder.DropTable(
                name: "Wystawcy");

            migrationBuilder.DropTable(
                name: "Uczestnicy");

            migrationBuilder.DropTable(
                name: "Eventy");

            migrationBuilder.DropTable(
                name: "Pracownicy");

            migrationBuilder.DropTable(
                name: "Nagrody");

            migrationBuilder.DropTable(
                name: "MiejscaEventu");

            migrationBuilder.DropTable(
                name: "Organizatorzy");
        }
    }
}
