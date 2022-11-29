using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deal.Migrations
{
    public partial class AcordoCancelados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcordosCancelados",
                columns: table => new
                {
                    AcordoCanceladoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Justificativa = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AcordoFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcordosCancelados", x => x.AcordoCanceladoId);
                    table.ForeignKey(
                        name: "FK_AcordosCancelados_Acordos_AcordoFk",
                        column: x => x.AcordoFk,
                        principalTable: "Acordos",
                        principalColumn: "AcordoId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AcordosCancelados_AcordoFk",
                table: "AcordosCancelados",
                column: "AcordoFk");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcordosCancelados");
        }
    }
}
