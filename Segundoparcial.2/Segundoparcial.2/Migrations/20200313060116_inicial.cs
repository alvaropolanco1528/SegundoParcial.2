using Microsoft.EntityFrameworkCore.Migrations;

namespace Segundoparcial._2.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "telefonos",
                columns: table => new
                {
                    LlamadaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Problema = table.Column<string>(nullable: false),
                    Solucion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_telefonos", x => x.LlamadaId);
                });

            migrationBuilder.CreateTable(
                name: "Detalle",
                columns: table => new
                {
                    CasoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LlamadaId = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(nullable: false),
                    Solucion = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detalle", x => x.CasoId);
                    table.ForeignKey(
                        name: "FK_Detalle_telefonos_LlamadaId",
                        column: x => x.LlamadaId,
                        principalTable: "telefonos",
                        principalColumn: "LlamadaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_LlamadaId",
                table: "Detalle",
                column: "LlamadaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Detalle");

            migrationBuilder.DropTable(
                name: "telefonos");
        }
    }
}
