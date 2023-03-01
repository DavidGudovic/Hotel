using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Migrations
{
    public partial class FixCoupons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
              name: "Kuponi",
              columns: table => new
              {
                  KuponID = table.Column<string>(type: "nvarchar(8)", nullable: false),
                  Iskoriscen = table.Column<bool>(type: "bit", nullable: false),
                  RezervacijaID = table.Column<int>(type: "int", nullable: false)
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_Kuponi", x => x.KuponID);
                  table.ForeignKey(
                      name: "FK_Kuponi_Rezervacije_RezervacijaID",
                      column: x => x.RezervacijaID,
                      principalTable: "Rezervacije",
                      principalColumn: "RezervacijaID",
                      onDelete: ReferentialAction.Cascade);
              });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
            name: "KuponID",
            table: "Kuponi");
        }
    }
}
