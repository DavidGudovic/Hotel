using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Migrations
{
    public partial class Modify_Index_Korisnici : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Korisnici_KorisnickoIme_Email",
                table: "Korisnici");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnici_Email",
                table: "Korisnici",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Korisnici_KorisnickoIme",
                table: "Korisnici",
                column: "KorisnickoIme",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Korisnici_Email",
                table: "Korisnici");

            migrationBuilder.DropIndex(
                name: "IX_Korisnici_KorisnickoIme",
                table: "Korisnici");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnici_KorisnickoIme_Email",
                table: "Korisnici",
                columns: new[] { "KorisnickoIme", "Email" },
                unique: true);
        }
    }
}
