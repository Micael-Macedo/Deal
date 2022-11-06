using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deal.Migrations
{
    public partial class UpdateFkToPortfolio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foto_Portfolios_FkPortfolio",
                table: "Foto");

            migrationBuilder.DropForeignKey(
                name: "FK_Prestadores_Portfolios_PortfolioId",
                table: "Prestadores");

            migrationBuilder.DropForeignKey(
                name: "FK_Video_Portfolios_FkPortfolio",
                table: "Video");

            migrationBuilder.DropIndex(
                name: "IX_Video_FkPortfolio",
                table: "Video");

            migrationBuilder.DropIndex(
                name: "IX_Prestadores_PortfolioId",
                table: "Prestadores");

            migrationBuilder.DropIndex(
                name: "IX_Foto_FkPortfolio",
                table: "Foto");

            migrationBuilder.DropColumn(
                name: "PortfolioId",
                table: "Prestadores");

            migrationBuilder.RenameColumn(
                name: "VideoPortfolio",
                table: "Video",
                newName: "VideoPrestador");

            migrationBuilder.RenameColumn(
                name: "FotoPortfolio",
                table: "Foto",
                newName: "FotoPrestador");

            migrationBuilder.AlterColumn<int>(
                name: "FkPortfolio",
                table: "Video",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PortifolioPortfolioId",
                table: "Video",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FkPrestador",
                table: "Servicos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FkPortfolio",
                table: "Prestadores",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FkPortfolio",
                table: "Foto",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PortifolioPortfolioId",
                table: "Foto",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                name: "IX_Video_PortifolioPortfolioId",
                table: "Video",
                column: "PortifolioPortfolioId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_FkPrestador",
                table: "Servicos",
                column: "FkPrestador");

            migrationBuilder.CreateIndex(
                name: "IX_Prestadores_FkPortfolio",
                table: "Prestadores",
                column: "FkPortfolio");

            migrationBuilder.CreateIndex(
                name: "IX_Foto_PortifolioPortfolioId",
                table: "Foto",
                column: "PortifolioPortfolioId");

            migrationBuilder.CreateIndex(
                name: "IX_AreasDeAtuacaoDoPrestador_FkAreaAtuacao",
                table: "AreasDeAtuacaoDoPrestador",
                column: "FkAreaAtuacao");

            migrationBuilder.CreateIndex(
                name: "IX_AreasDeAtuacaoDoPrestador_FkPrestador",
                table: "AreasDeAtuacaoDoPrestador",
                column: "FkPrestador");

            migrationBuilder.AddForeignKey(
                name: "FK_Foto_Portfolios_PortifolioPortfolioId",
                table: "Foto",
                column: "PortifolioPortfolioId",
                principalTable: "Portfolios",
                principalColumn: "PortfolioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prestadores_Portfolios_FkPortfolio",
                table: "Prestadores",
                column: "FkPortfolio",
                principalTable: "Portfolios",
                principalColumn: "PortfolioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_Prestadores_FkPrestador",
                table: "Servicos",
                column: "FkPrestador",
                principalTable: "Prestadores",
                principalColumn: "PrestadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Video_Portfolios_PortifolioPortfolioId",
                table: "Video",
                column: "PortifolioPortfolioId",
                principalTable: "Portfolios",
                principalColumn: "PortfolioId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foto_Portfolios_PortifolioPortfolioId",
                table: "Foto");

            migrationBuilder.DropForeignKey(
                name: "FK_Prestadores_Portfolios_FkPortfolio",
                table: "Prestadores");

            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_Prestadores_FkPrestador",
                table: "Servicos");

            migrationBuilder.DropForeignKey(
                name: "FK_Video_Portfolios_PortifolioPortfolioId",
                table: "Video");

            migrationBuilder.DropTable(
                name: "AreasDeAtuacaoDoPrestador");

            migrationBuilder.DropIndex(
                name: "IX_Video_PortifolioPortfolioId",
                table: "Video");

            migrationBuilder.DropIndex(
                name: "IX_Servicos_FkPrestador",
                table: "Servicos");

            migrationBuilder.DropIndex(
                name: "IX_Prestadores_FkPortfolio",
                table: "Prestadores");

            migrationBuilder.DropIndex(
                name: "IX_Foto_PortifolioPortfolioId",
                table: "Foto");

            migrationBuilder.DropColumn(
                name: "PortifolioPortfolioId",
                table: "Video");

            migrationBuilder.DropColumn(
                name: "FkPrestador",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "FkPortfolio",
                table: "Prestadores");

            migrationBuilder.DropColumn(
                name: "PortifolioPortfolioId",
                table: "Foto");

            migrationBuilder.RenameColumn(
                name: "VideoPrestador",
                table: "Video",
                newName: "VideoPortfolio");

            migrationBuilder.RenameColumn(
                name: "FotoPrestador",
                table: "Foto",
                newName: "FotoPortfolio");

            migrationBuilder.AlterColumn<int>(
                name: "FkPortfolio",
                table: "Video",
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

            migrationBuilder.AlterColumn<int>(
                name: "FkPortfolio",
                table: "Foto",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Video_FkPortfolio",
                table: "Video",
                column: "FkPortfolio");

            migrationBuilder.CreateIndex(
                name: "IX_Prestadores_PortfolioId",
                table: "Prestadores",
                column: "PortfolioId");

            migrationBuilder.CreateIndex(
                name: "IX_Foto_FkPortfolio",
                table: "Foto",
                column: "FkPortfolio");

            migrationBuilder.AddForeignKey(
                name: "FK_Foto_Portfolios_FkPortfolio",
                table: "Foto",
                column: "FkPortfolio",
                principalTable: "Portfolios",
                principalColumn: "PortfolioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prestadores_Portfolios_PortfolioId",
                table: "Prestadores",
                column: "PortfolioId",
                principalTable: "Portfolios",
                principalColumn: "PortfolioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Video_Portfolios_FkPortfolio",
                table: "Video",
                column: "FkPortfolio",
                principalTable: "Portfolios",
                principalColumn: "PortfolioId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
