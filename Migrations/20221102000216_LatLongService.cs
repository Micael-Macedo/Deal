using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deal.Migrations
{
    public partial class LatLongService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acordos_Clientes_ClienteId",
                table: "Acordos");

            migrationBuilder.DropForeignKey(
                name: "FK_Acordos_Prestadores_PrestadorId",
                table: "Acordos");

            migrationBuilder.DropForeignKey(
                name: "FK_Acordos_Servicos_ServicoId",
                table: "Acordos");

            migrationBuilder.DropForeignKey(
                name: "FK_Certificado_Portfolios_PortfolioId",
                table: "Certificado");

            migrationBuilder.DropForeignKey(
                name: "FK_Foto_Portfolios_PortfolioId",
                table: "Foto");

            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_Clientes_FkCliente",
                table: "Servicos");

            migrationBuilder.DropForeignKey(
                name: "FK_Video_Portfolios_PortfolioId",
                table: "Video");

            migrationBuilder.DropIndex(
                name: "IX_Video_PortfolioId",
                table: "Video");

            migrationBuilder.DropIndex(
                name: "IX_Foto_PortfolioId",
                table: "Foto");

            migrationBuilder.DropIndex(
                name: "IX_Certificado_PortfolioId",
                table: "Certificado");

            migrationBuilder.DropColumn(
                name: "PortfolioId",
                table: "Video");

            migrationBuilder.DropColumn(
                name: "PortfolioId",
                table: "Foto");

            migrationBuilder.DropColumn(
                name: "PortfolioId",
                table: "Certificado");

            migrationBuilder.RenameColumn(
                name: "ServicoId",
                table: "Acordos",
                newName: "FkServico");

            migrationBuilder.RenameColumn(
                name: "PrestadorId",
                table: "Acordos",
                newName: "FkPrestador");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Acordos",
                newName: "FkCliente");

            migrationBuilder.RenameIndex(
                name: "IX_Acordos_ServicoId",
                table: "Acordos",
                newName: "IX_Acordos_FkServico");

            migrationBuilder.RenameIndex(
                name: "IX_Acordos_PrestadorId",
                table: "Acordos",
                newName: "IX_Acordos_FkPrestador");

            migrationBuilder.RenameIndex(
                name: "IX_Acordos_ClienteId",
                table: "Acordos",
                newName: "IX_Acordos_FkCliente");

            migrationBuilder.AddColumn<int>(
                name: "FkPortfolio",
                table: "Video",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "FkCliente",
                table: "Servicos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Servicos",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Servicos",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "FkPortfolio",
                table: "Foto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FkPortfolio",
                table: "Certificado",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Video_FkPortfolio",
                table: "Video",
                column: "FkPortfolio");

            migrationBuilder.CreateIndex(
                name: "IX_Foto_FkPortfolio",
                table: "Foto",
                column: "FkPortfolio");

            migrationBuilder.CreateIndex(
                name: "IX_Certificado_FkPortfolio",
                table: "Certificado",
                column: "FkPortfolio");

            migrationBuilder.AddForeignKey(
                name: "FK_Acordos_Clientes_FkCliente",
                table: "Acordos",
                column: "FkCliente",
                principalTable: "Clientes",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Acordos_Prestadores_FkPrestador",
                table: "Acordos",
                column: "FkPrestador",
                principalTable: "Prestadores",
                principalColumn: "PrestadorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Acordos_Servicos_FkServico",
                table: "Acordos",
                column: "FkServico",
                principalTable: "Servicos",
                principalColumn: "ServicoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Certificado_Portfolios_FkPortfolio",
                table: "Certificado",
                column: "FkPortfolio",
                principalTable: "Portfolios",
                principalColumn: "PortfolioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Foto_Portfolios_FkPortfolio",
                table: "Foto",
                column: "FkPortfolio",
                principalTable: "Portfolios",
                principalColumn: "PortfolioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_Clientes_FkCliente",
                table: "Servicos",
                column: "FkCliente",
                principalTable: "Clientes",
                principalColumn: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Video_Portfolios_FkPortfolio",
                table: "Video",
                column: "FkPortfolio",
                principalTable: "Portfolios",
                principalColumn: "PortfolioId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acordos_Clientes_FkCliente",
                table: "Acordos");

            migrationBuilder.DropForeignKey(
                name: "FK_Acordos_Prestadores_FkPrestador",
                table: "Acordos");

            migrationBuilder.DropForeignKey(
                name: "FK_Acordos_Servicos_FkServico",
                table: "Acordos");

            migrationBuilder.DropForeignKey(
                name: "FK_Certificado_Portfolios_FkPortfolio",
                table: "Certificado");

            migrationBuilder.DropForeignKey(
                name: "FK_Foto_Portfolios_FkPortfolio",
                table: "Foto");

            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_Clientes_FkCliente",
                table: "Servicos");

            migrationBuilder.DropForeignKey(
                name: "FK_Video_Portfolios_FkPortfolio",
                table: "Video");

            migrationBuilder.DropIndex(
                name: "IX_Video_FkPortfolio",
                table: "Video");

            migrationBuilder.DropIndex(
                name: "IX_Foto_FkPortfolio",
                table: "Foto");

            migrationBuilder.DropIndex(
                name: "IX_Certificado_FkPortfolio",
                table: "Certificado");

            migrationBuilder.DropColumn(
                name: "FkPortfolio",
                table: "Video");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "FkPortfolio",
                table: "Foto");

            migrationBuilder.DropColumn(
                name: "FkPortfolio",
                table: "Certificado");

            migrationBuilder.RenameColumn(
                name: "FkServico",
                table: "Acordos",
                newName: "ServicoId");

            migrationBuilder.RenameColumn(
                name: "FkPrestador",
                table: "Acordos",
                newName: "PrestadorId");

            migrationBuilder.RenameColumn(
                name: "FkCliente",
                table: "Acordos",
                newName: "ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Acordos_FkServico",
                table: "Acordos",
                newName: "IX_Acordos_ServicoId");

            migrationBuilder.RenameIndex(
                name: "IX_Acordos_FkPrestador",
                table: "Acordos",
                newName: "IX_Acordos_PrestadorId");

            migrationBuilder.RenameIndex(
                name: "IX_Acordos_FkCliente",
                table: "Acordos",
                newName: "IX_Acordos_ClienteId");

            migrationBuilder.AddColumn<int>(
                name: "PortfolioId",
                table: "Video",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FkCliente",
                table: "Servicos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PortfolioId",
                table: "Foto",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PortfolioId",
                table: "Certificado",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Video_PortfolioId",
                table: "Video",
                column: "PortfolioId");

            migrationBuilder.CreateIndex(
                name: "IX_Foto_PortfolioId",
                table: "Foto",
                column: "PortfolioId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificado_PortfolioId",
                table: "Certificado",
                column: "PortfolioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Acordos_Clientes_ClienteId",
                table: "Acordos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Acordos_Prestadores_PrestadorId",
                table: "Acordos",
                column: "PrestadorId",
                principalTable: "Prestadores",
                principalColumn: "PrestadorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Acordos_Servicos_ServicoId",
                table: "Acordos",
                column: "ServicoId",
                principalTable: "Servicos",
                principalColumn: "ServicoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Certificado_Portfolios_PortfolioId",
                table: "Certificado",
                column: "PortfolioId",
                principalTable: "Portfolios",
                principalColumn: "PortfolioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foto_Portfolios_PortfolioId",
                table: "Foto",
                column: "PortfolioId",
                principalTable: "Portfolios",
                principalColumn: "PortfolioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_Clientes_FkCliente",
                table: "Servicos",
                column: "FkCliente",
                principalTable: "Clientes",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Video_Portfolios_PortfolioId",
                table: "Video",
                column: "PortfolioId",
                principalTable: "Portfolios",
                principalColumn: "PortfolioId");
        }
    }
}
