using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CameliaRasiga_ProiectMedii.Migrations
{
    public partial class FirstClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locatie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Localitate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locatie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Specialitate",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denumire = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialitate", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Medic",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecialitateID = table.Column<int>(type: "int", nullable: true),
                    Grad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocatieID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medic", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Medic_Locatie_LocatieID",
                        column: x => x.LocatieID,
                        principalTable: "Locatie",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Medic_Specialitate_SpecialitateID",
                        column: x => x.SpecialitateID,
                        principalTable: "Specialitate",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Serviciu",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denumire = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecialitateID = table.Column<int>(type: "int", nullable: true),
                    Pret = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MedicID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serviciu", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Serviciu_Medic_MedicID",
                        column: x => x.MedicID,
                        principalTable: "Medic",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Serviciu_Specialitate_SpecialitateID",
                        column: x => x.SpecialitateID,
                        principalTable: "Specialitate",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medic_LocatieID",
                table: "Medic",
                column: "LocatieID");

            migrationBuilder.CreateIndex(
                name: "IX_Medic_SpecialitateID",
                table: "Medic",
                column: "SpecialitateID");

            migrationBuilder.CreateIndex(
                name: "IX_Serviciu_MedicID",
                table: "Serviciu",
                column: "MedicID");

            migrationBuilder.CreateIndex(
                name: "IX_Serviciu_SpecialitateID",
                table: "Serviciu",
                column: "SpecialitateID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Serviciu");

            migrationBuilder.DropTable(
                name: "Medic");

            migrationBuilder.DropTable(
                name: "Locatie");

            migrationBuilder.DropTable(
                name: "Specialitate");
        }
    }
}
