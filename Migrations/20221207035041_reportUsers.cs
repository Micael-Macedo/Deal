using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deal.Migrations
{
    public partial class reportUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QtdContaReportada",
                table: "Prestadores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QtdContaReportada",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ReportesClientes",
                columns: table => new
                {
                    ReporteClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Motivo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FkCliente = table.Column<int>(type: "int", nullable: false),
                    FkPrestador = table.Column<int>(type: "int", nullable: false),
                    FkServico = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportesClientes", x => x.ReporteClienteId);
                    table.ForeignKey(
                        name: "FK_ReportesClientes_Clientes_FkCliente",
                        column: x => x.FkCliente,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportesClientes_Prestadores_FkPrestador",
                        column: x => x.FkPrestador,
                        principalTable: "Prestadores",
                        principalColumn: "PrestadorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportesClientes_Servicos_FkServico",
                        column: x => x.FkServico,
                        principalTable: "Servicos",
                        principalColumn: "ServicoId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ReportesPrestadores",
                columns: table => new
                {
                    ReportePrestadorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Motivo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FkPrestador = table.Column<int>(type: "int", nullable: false),
                    PrestadorId = table.Column<int>(type: "int", nullable: true),
                    FkCliente = table.Column<int>(type: "int", nullable: false),
                    FkServico = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportesPrestadores", x => x.ReportePrestadorId);
                    table.ForeignKey(
                        name: "FK_ReportesPrestadores_Clientes_FkCliente",
                        column: x => x.FkCliente,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportesPrestadores_Prestadores_PrestadorId",
                        column: x => x.PrestadorId,
                        principalTable: "Prestadores",
                        principalColumn: "PrestadorId");
                    table.ForeignKey(
                        name: "FK_ReportesPrestadores_Servicos_FkServico",
                        column: x => x.FkServico,
                        principalTable: "Servicos",
                        principalColumn: "ServicoId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ReportesClientes_FkCliente",
                table: "ReportesClientes",
                column: "FkCliente");

            migrationBuilder.CreateIndex(
                name: "IX_ReportesClientes_FkPrestador",
                table: "ReportesClientes",
                column: "FkPrestador");

            migrationBuilder.CreateIndex(
                name: "IX_ReportesClientes_FkServico",
                table: "ReportesClientes",
                column: "FkServico");

            migrationBuilder.CreateIndex(
                name: "IX_ReportesPrestadores_FkCliente",
                table: "ReportesPrestadores",
                column: "FkCliente");

            migrationBuilder.CreateIndex(
                name: "IX_ReportesPrestadores_FkServico",
                table: "ReportesPrestadores",
                column: "FkServico");

            migrationBuilder.CreateIndex(
                name: "IX_ReportesPrestadores_PrestadorId",
                table: "ReportesPrestadores",
                column: "PrestadorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportesClientes");

            migrationBuilder.DropTable(
                name: "ReportesPrestadores");

            migrationBuilder.DropColumn(
                name: "QtdContaReportada",
                table: "Prestadores");

            migrationBuilder.DropColumn(
                name: "QtdContaReportada",
                table: "Clientes");
        }
    }
}
