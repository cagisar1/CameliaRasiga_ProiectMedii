using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CameliaRasiga_ProiectMedii.Migrations
{
    public partial class UserServicii : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Utilizator",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizator", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UtilizatorServiciu",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtilizatorID = table.Column<int>(type: "int", nullable: true),
                    ServiciuID = table.Column<int>(type: "int", nullable: true),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtilizatorServiciu", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UtilizatorServiciu_Serviciu_ServiciuID",
                        column: x => x.ServiciuID,
                        principalTable: "Serviciu",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_UtilizatorServiciu_Utilizator_UtilizatorID",
                        column: x => x.UtilizatorID,
                        principalTable: "Utilizator",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UtilizatorServiciu_ServiciuID",
                table: "UtilizatorServiciu",
                column: "ServiciuID");

            migrationBuilder.CreateIndex(
                name: "IX_UtilizatorServiciu_UtilizatorID",
                table: "UtilizatorServiciu",
                column: "UtilizatorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UtilizatorServiciu");

            migrationBuilder.DropTable(
                name: "Utilizator");
        }
    }
}
