using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt_bazy.Migrations
{
    /// <inheritdoc />
    public partial class updatedata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personel_Magazyny_MagazynIdMagazynu",
                table: "Personel");

            migrationBuilder.DropForeignKey(
                name: "FK_Sprzety_Magazyny_MagazynId",
                table: "Sprzety");

            migrationBuilder.DropForeignKey(
                name: "FK_Zamowienia_Personel_ZamawiajacyIdPersonelu",
                table: "Zamowienia");

            migrationBuilder.DropColumn(
                name: "IdZamawiajacego",
                table: "Zamowienia");

            migrationBuilder.DropColumn(
                name: "PrzynaleznoscDoMagazynu",
                table: "Personel");

            migrationBuilder.RenameColumn(
                name: "ZamawiajacyIdPersonelu",
                table: "Zamowienia",
                newName: "ZamawiajacyId");

            migrationBuilder.RenameIndex(
                name: "IX_Zamowienia_ZamawiajacyIdPersonelu",
                table: "Zamowienia",
                newName: "IX_Zamowienia_ZamawiajacyId");

            migrationBuilder.RenameColumn(
                name: "MagazynIdMagazynu",
                table: "Personel",
                newName: "Przynaleznosc");

            migrationBuilder.RenameIndex(
                name: "IX_Personel_MagazynIdMagazynu",
                table: "Personel",
                newName: "IX_Personel_Przynaleznosc");

            migrationBuilder.AlterColumn<int>(
                name: "MagazynId",
                table: "Sprzety",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Personel_Magazyny_Przynaleznosc",
                table: "Personel",
                column: "Przynaleznosc",
                principalTable: "Magazyny",
                principalColumn: "IdMagazynu",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sprzety_Magazyny_MagazynId",
                table: "Sprzety",
                column: "MagazynId",
                principalTable: "Magazyny",
                principalColumn: "IdMagazynu",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Zamowienia_Personel_ZamawiajacyId",
                table: "Zamowienia",
                column: "ZamawiajacyId",
                principalTable: "Personel",
                principalColumn: "IdPersonelu",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personel_Magazyny_Przynaleznosc",
                table: "Personel");

            migrationBuilder.DropForeignKey(
                name: "FK_Sprzety_Magazyny_MagazynId",
                table: "Sprzety");

            migrationBuilder.DropForeignKey(
                name: "FK_Zamowienia_Personel_ZamawiajacyId",
                table: "Zamowienia");

            migrationBuilder.RenameColumn(
                name: "ZamawiajacyId",
                table: "Zamowienia",
                newName: "ZamawiajacyIdPersonelu");

            migrationBuilder.RenameIndex(
                name: "IX_Zamowienia_ZamawiajacyId",
                table: "Zamowienia",
                newName: "IX_Zamowienia_ZamawiajacyIdPersonelu");

            migrationBuilder.RenameColumn(
                name: "Przynaleznosc",
                table: "Personel",
                newName: "MagazynIdMagazynu");

            migrationBuilder.RenameIndex(
                name: "IX_Personel_Przynaleznosc",
                table: "Personel",
                newName: "IX_Personel_MagazynIdMagazynu");

            migrationBuilder.AddColumn<int>(
                name: "IdZamawiajacego",
                table: "Zamowienia",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "MagazynId",
                table: "Sprzety",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PrzynaleznoscDoMagazynu",
                table: "Personel",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Personel_Magazyny_MagazynIdMagazynu",
                table: "Personel",
                column: "MagazynIdMagazynu",
                principalTable: "Magazyny",
                principalColumn: "IdMagazynu",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sprzety_Magazyny_MagazynId",
                table: "Sprzety",
                column: "MagazynId",
                principalTable: "Magazyny",
                principalColumn: "IdMagazynu");

            migrationBuilder.AddForeignKey(
                name: "FK_Zamowienia_Personel_ZamawiajacyIdPersonelu",
                table: "Zamowienia",
                column: "ZamawiajacyIdPersonelu",
                principalTable: "Personel",
                principalColumn: "IdPersonelu",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
