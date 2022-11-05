using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deal.Migrations
{
    public partial class FixFotosandNotas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foto_Portfolios_PortifolioPortfolioId",
                table: "Foto");

            migrationBuilder.DropForeignKey(
                name: "FK_Nota_Clientes_ClienteId",
                table: "Nota");

            migrationBuilder.DropForeignKey(
                name: "FK_Nota_Prestadores_PrestadorId",
                table: "Nota");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Nota",
                table: "Nota");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Foto",
                table: "Foto");

            migrationBuilder.RenameTable(
                name: "Nota",
                newName: "Notas");

            migrationBuilder.RenameTable(
                name: "Foto",
                newName: "Fotos");

            migrationBuilder.RenameIndex(
                name: "IX_Nota_PrestadorId",
                table: "Notas",
                newName: "IX_Notas_PrestadorId");

            migrationBuilder.RenameIndex(
                name: "IX_Nota_ClienteId",
                table: "Notas",
                newName: "IX_Notas_ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Foto_PortifolioPortfolioId",
                table: "Fotos",
                newName: "IX_Fotos_PortifolioPortfolioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notas",
                table: "Notas",
                column: "NotaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fotos",
                table: "Fotos",
                column: "FotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fotos_Portfolios_PortifolioPortfolioId",
                table: "Fotos",
                column: "PortifolioPortfolioId",
                principalTable: "Portfolios",
                principalColumn: "PortfolioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_Clientes_ClienteId",
                table: "Notas",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_Prestadores_PrestadorId",
                table: "Notas",
                column: "PrestadorId",
                principalTable: "Prestadores",
                principalColumn: "PrestadorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fotos_Portfolios_PortifolioPortfolioId",
                table: "Fotos");

            migrationBuilder.DropForeignKey(
                name: "FK_Notas_Clientes_ClienteId",
                table: "Notas");

            migrationBuilder.DropForeignKey(
                name: "FK_Notas_Prestadores_PrestadorId",
                table: "Notas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notas",
                table: "Notas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fotos",
                table: "Fotos");

            migrationBuilder.RenameTable(
                name: "Notas",
                newName: "Nota");

            migrationBuilder.RenameTable(
                name: "Fotos",
                newName: "Foto");

            migrationBuilder.RenameIndex(
                name: "IX_Notas_PrestadorId",
                table: "Nota",
                newName: "IX_Nota_PrestadorId");

            migrationBuilder.RenameIndex(
                name: "IX_Notas_ClienteId",
                table: "Nota",
                newName: "IX_Nota_ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Fotos_PortifolioPortfolioId",
                table: "Foto",
                newName: "IX_Foto_PortifolioPortfolioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Nota",
                table: "Nota",
                column: "NotaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Foto",
                table: "Foto",
                column: "FotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foto_Portfolios_PortifolioPortfolioId",
                table: "Foto",
                column: "PortifolioPortfolioId",
                principalTable: "Portfolios",
                principalColumn: "PortfolioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Nota_Clientes_ClienteId",
                table: "Nota",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nota_Prestadores_PrestadorId",
                table: "Nota",
                column: "PrestadorId",
                principalTable: "Prestadores",
                principalColumn: "PrestadorId");
        }
    }
}
