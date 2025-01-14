using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt_bazy.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Magazyny",
                columns: table => new
                {
                    IdMagazynu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Funkcjonalnosc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lokalizacja = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Magazyny", x => x.IdMagazynu);
                });

            migrationBuilder.CreateTable(
                name: "Personel",
                columns: table => new
                {
                    IdPersonelu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stopien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrzynaleznoscDoMagazynu = table.Column<int>(type: "int", nullable: true),
                    MagazynIdMagazynu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personel", x => x.IdPersonelu);
                    table.ForeignKey(
                        name: "FK_Personel_Magazyny_MagazynIdMagazynu",
                        column: x => x.MagazynIdMagazynu,
                        principalTable: "Magazyny",
                        principalColumn: "IdMagazynu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sprzety",
                columns: table => new
                {
                    IdSprzetu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaSprzetu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataWstawienia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MagazynId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sprzety", x => x.IdSprzetu);
                    table.ForeignKey(
                        name: "FK_Sprzety_Magazyny_MagazynId",
                        column: x => x.MagazynId,
                        principalTable: "Magazyny",
                        principalColumn: "IdMagazynu");
                });

            migrationBuilder.CreateTable(
                name: "Zamowienia",
                columns: table => new
                {
                    IdZamowienia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaSprzetu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataZamowienia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdZamawiajacego = table.Column<int>(type: "int", nullable: false),
                    ZamawiajacyIdPersonelu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamowienia", x => x.IdZamowienia);
                    table.ForeignKey(
                        name: "FK_Zamowienia_Personel_ZamawiajacyIdPersonelu",
                        column: x => x.ZamawiajacyIdPersonelu,
                        principalTable: "Personel",
                        principalColumn: "IdPersonelu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personel_MagazynIdMagazynu",
                table: "Personel",
                column: "MagazynIdMagazynu");

            migrationBuilder.CreateIndex(
                name: "IX_Sprzety_MagazynId",
                table: "Sprzety",
                column: "MagazynId");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienia_ZamawiajacyIdPersonelu",
                table: "Zamowienia",
                column: "ZamawiajacyIdPersonelu");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sprzety");

            migrationBuilder.DropTable(
                name: "Zamowienia");

            migrationBuilder.DropTable(
                name: "Personel");

            migrationBuilder.DropTable(
                name: "Magazyny");
        }
    }
}
