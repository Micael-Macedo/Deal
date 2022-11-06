using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deal.Migrations
{
    public partial class FotosCertificadosVideosContent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foto_Portfolios_FkPortfolio",
                table: "Foto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Foto",
                table: "Foto");

            migrationBuilder.RenameTable(
                name: "Foto",
                newName: "Fotos");

            migrationBuilder.RenameIndex(
                name: "IX_Foto_FkPortfolio",
                table: "Fotos",
                newName: "IX_Fotos_FkPortfolio");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fotos",
                table: "Fotos",
                column: "FotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fotos_Portfolios_FkPortfolio",
                table: "Fotos",
                column: "FkPortfolio",
                principalTable: "Portfolios",
                principalColumn: "PortfolioId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fotos_Portfolios_FkPortfolio",
                table: "Fotos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fotos",
                table: "Fotos");

            migrationBuilder.RenameTable(
                name: "Fotos",
                newName: "Foto");

            migrationBuilder.RenameIndex(
                name: "IX_Fotos_FkPortfolio",
                table: "Foto",
                newName: "IX_Foto_FkPortfolio");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Foto",
                table: "Foto",
                column: "FotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foto_Portfolios_FkPortfolio",
                table: "Foto",
                column: "FkPortfolio",
                principalTable: "Portfolios",
                principalColumn: "PortfolioId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
