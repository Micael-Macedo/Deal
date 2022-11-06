using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deal.Migrations
{
    public partial class PortfolioToPrestadores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prestadores_Portfolios_PortfolioId",
                table: "Prestadores");

            migrationBuilder.DropIndex(
                name: "IX_Prestadores_PortfolioId",
                table: "Prestadores");

            migrationBuilder.DropColumn(
                name: "PortfolioId",
                table: "Prestadores");

            migrationBuilder.AlterColumn<int>(
                name: "QtdServicoRealizados",
                table: "Prestadores",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "FkPortfolio",
                table: "Prestadores",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AreasDeAtuacaoDoPrestador",
                columns: table => new
                {
                    AreasDeAtuacaoDoPrestadorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FkPrestador = table.Column<int>(type: "int", nullable: false),
                    FkAreaAtuacao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreasDeAtuacaoDoPrestador", x => x.AreasDeAtuacaoDoPrestadorId);
                    table.ForeignKey(
                        name: "FK_AreasDeAtuacaoDoPrestador_AreaAtuacao_FkAreaAtuacao",
                        column: x => x.FkAreaAtuacao,
                        principalTable: "AreaAtuacao",
                        principalColumn: "AreaAtuacaoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AreasDeAtuacaoDoPrestador_Prestadores_FkPrestador",
                        column: x => x.FkPrestador,
                        principalTable: "Prestadores",
                        principalColumn: "PrestadorId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Prestadores_FkPortfolio",
                table: "Prestadores",
                column: "FkPortfolio");

            migrationBuilder.CreateIndex(
                name: "IX_AreasDeAtuacaoDoPrestador_FkAreaAtuacao",
                table: "AreasDeAtuacaoDoPrestador",
                column: "FkAreaAtuacao");

            migrationBuilder.CreateIndex(
                name: "IX_AreasDeAtuacaoDoPrestador_FkPrestador",
                table: "AreasDeAtuacaoDoPrestador",
                column: "FkPrestador");

            migrationBuilder.AddForeignKey(
                name: "FK_Prestadores_Portfolios_FkPortfolio",
                table: "Prestadores",
                column: "FkPortfolio",
                principalTable: "Portfolios",
                principalColumn: "PortfolioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prestadores_Portfolios_FkPortfolio",
                table: "Prestadores");

            migrationBuilder.DropTable(
                name: "AreasDeAtuacaoDoPrestador");

            migrationBuilder.DropIndex(
                name: "IX_Prestadores_FkPortfolio",
                table: "Prestadores");

            migrationBuilder.DropColumn(
                name: "FkPortfolio",
                table: "Prestadores");

            migrationBuilder.AlterColumn<int>(
                name: "QtdServicoRealizados",
                table: "Prestadores",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PortfolioId",
                table: "Prestadores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Prestadores_PortfolioId",
                table: "Prestadores",
                column: "PortfolioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prestadores_Portfolios_PortfolioId",
                table: "Prestadores",
                column: "PortfolioId",
                principalTable: "Portfolios",
                principalColumn: "PortfolioId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
