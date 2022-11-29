using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deal.Migrations
{
    public partial class AcordoCancelado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcordosCancelados");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcordosCancelados",
                columns: table => new
                {
                    AcordoCanceladoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AcordoFk = table.Column<int>(type: "int", nullable: false),
                    Justificativa = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
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
    }
}
