using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt_bazy.Migrations
{
    /// <inheritdoc />
    public partial class updatezama : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MagazynId",
                table: "Zamowienia",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MagazynIdMagazynu",
                table: "Zamowienia",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienia_MagazynId",
                table: "Zamowienia",
                column: "MagazynId");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienia_MagazynIdMagazynu",
                table: "Zamowienia",
                column: "MagazynIdMagazynu");

            migrationBuilder.AddForeignKey(
                name: "FK_Zamowienia_Magazyny_MagazynId",
                table: "Zamowienia",
                column: "MagazynId",
                principalTable: "Magazyny",
                principalColumn: "IdMagazynu",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Zamowienia_Magazyny_MagazynIdMagazynu",
                table: "Zamowienia",
                column: "MagazynIdMagazynu",
                principalTable: "Magazyny",
                principalColumn: "IdMagazynu");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zamowienia_Magazyny_MagazynId",
                table: "Zamowienia");

            migrationBuilder.DropForeignKey(
                name: "FK_Zamowienia_Magazyny_MagazynIdMagazynu",
                table: "Zamowienia");

            migrationBuilder.DropIndex(
                name: "IX_Zamowienia_MagazynId",
                table: "Zamowienia");

            migrationBuilder.DropIndex(
                name: "IX_Zamowienia_MagazynIdMagazynu",
                table: "Zamowienia");

            migrationBuilder.DropColumn(
                name: "MagazynId",
                table: "Zamowienia");

            migrationBuilder.DropColumn(
                name: "MagazynIdMagazynu",
                table: "Zamowienia");
        }
    }
}
