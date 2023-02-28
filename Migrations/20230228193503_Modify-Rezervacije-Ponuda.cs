using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Migrations
{
    public partial class ModifyRezervacijePonuda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Iskoriscena",
                table: "Rezervacije");

            migrationBuilder.RenameColumn(
                name: "BrojSoba",
                table: "Ponude",
                newName: "BrojKreveta");

            migrationBuilder.AddColumn<int>(
                name: "BrojGostiju",
                table: "Rezervacije",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Rezervacije",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrojGostiju",
                table: "Rezervacije");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Rezervacije");

            migrationBuilder.RenameColumn(
                name: "BrojKreveta",
                table: "Ponude",
                newName: "BrojSoba");

            migrationBuilder.AddColumn<bool>(
                name: "Iskoriscena",
                table: "Rezervacije",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
