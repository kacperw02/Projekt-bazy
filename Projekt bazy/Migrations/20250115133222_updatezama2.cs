using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt_bazy.Migrations
{
    /// <inheritdoc />
    public partial class updatezama2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumerOdznaki",
                table: "Personel",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumerOdznaki",
                table: "Personel");
        }
    }
}
