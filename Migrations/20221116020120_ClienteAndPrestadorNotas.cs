using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deal.Migrations
{
    public partial class ClienteAndPrestadorNotas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "FK_AreasDeAtuacaoDoPrestador_AreaAtuacao_FkAreaAtuacao",
                table: "AreasDeAtuacaoDoPrestador");

            migrationBuilder.DropForeignKey(
                name: "FK_AreasDeAtuacaoDoPrestador_Prestadores_FkPrestador",
                table: "AreasDeAtuacaoDoPrestador");

            migrationBuilder.DropTable(
                name: "Notas");

            migrationBuilder.AddColumn<int>(
                name: "ServicosCancelados",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "FkPrestador",
                table: "AreasDeAtuacaoDoPrestador",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FkAreaAtuacao",
                table: "AreasDeAtuacaoDoPrestador",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FkServico",
                table: "Acordos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FkPrestador",
                table: "Acordos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FkCliente",
                table: "Acordos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "NotaClientes",
                columns: table => new
                {
                    NotaClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Avaliacao = table.Column<float>(type: "float", nullable: false),
                    FkCliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotaClientes", x => x.NotaClienteId);
                    table.ForeignKey(
                        name: "FK_NotaClientes_Clientes_FkCliente",
                        column: x => x.FkCliente,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "NotaPrestadores",
                columns: table => new
                {
                    NotaPrestadorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Avaliacao = table.Column<float>(type: "float", nullable: false),
                    FkPrestador = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotaPrestadores", x => x.NotaPrestadorId);
                    table.ForeignKey(
                        name: "FK_NotaPrestadores_Prestadores_FkPrestador",
                        column: x => x.FkPrestador,
                        principalTable: "Prestadores",
                        principalColumn: "PrestadorId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_NotaClientes_FkCliente",
                table: "NotaClientes",
                column: "FkCliente");

            migrationBuilder.CreateIndex(
                name: "IX_NotaPrestadores_FkPrestador",
                table: "NotaPrestadores",
                column: "FkPrestador");

            migrationBuilder.AddForeignKey(
                name: "FK_Acordos_Clientes_FkCliente",
                table: "Acordos",
                column: "FkCliente",
                principalTable: "Clientes",
                principalColumn: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Acordos_Prestadores_FkPrestador",
                table: "Acordos",
                column: "FkPrestador",
                principalTable: "Prestadores",
                principalColumn: "PrestadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Acordos_Servicos_FkServico",
                table: "Acordos",
                column: "FkServico",
                principalTable: "Servicos",
                principalColumn: "ServicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AreasDeAtuacaoDoPrestador_AreaAtuacao_FkAreaAtuacao",
                table: "AreasDeAtuacaoDoPrestador",
                column: "FkAreaAtuacao",
                principalTable: "AreaAtuacao",
                principalColumn: "AreaAtuacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AreasDeAtuacaoDoPrestador_Prestadores_FkPrestador",
                table: "AreasDeAtuacaoDoPrestador",
                column: "FkPrestador",
                principalTable: "Prestadores",
                principalColumn: "PrestadorId");
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
                name: "FK_AreasDeAtuacaoDoPrestador_AreaAtuacao_FkAreaAtuacao",
                table: "AreasDeAtuacaoDoPrestador");

            migrationBuilder.DropForeignKey(
                name: "FK_AreasDeAtuacaoDoPrestador_Prestadores_FkPrestador",
                table: "AreasDeAtuacaoDoPrestador");

            migrationBuilder.DropTable(
                name: "NotaClientes");

            migrationBuilder.DropTable(
                name: "NotaPrestadores");

            migrationBuilder.DropColumn(
                name: "ServicosCancelados",
                table: "Clientes");

            migrationBuilder.AlterColumn<int>(
                name: "FkPrestador",
                table: "AreasDeAtuacaoDoPrestador",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FkAreaAtuacao",
                table: "AreasDeAtuacaoDoPrestador",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FkServico",
                table: "Acordos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FkPrestador",
                table: "Acordos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FkCliente",
                table: "Acordos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Notas",
                columns: table => new
                {
                    NotaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Avaliacao = table.Column<float>(type: "float", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: true),
                    PrestadorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notas", x => x.NotaId);
                    table.ForeignKey(
                        name: "FK_Notas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId");
                    table.ForeignKey(
                        name: "FK_Notas_Prestadores_PrestadorId",
                        column: x => x.PrestadorId,
                        principalTable: "Prestadores",
                        principalColumn: "PrestadorId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_ClienteId",
                table: "Notas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_PrestadorId",
                table: "Notas",
                column: "PrestadorId");

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
                name: "FK_AreasDeAtuacaoDoPrestador_AreaAtuacao_FkAreaAtuacao",
                table: "AreasDeAtuacaoDoPrestador",
                column: "FkAreaAtuacao",
                principalTable: "AreaAtuacao",
                principalColumn: "AreaAtuacaoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AreasDeAtuacaoDoPrestador_Prestadores_FkPrestador",
                table: "AreasDeAtuacaoDoPrestador",
                column: "FkPrestador",
                principalTable: "Prestadores",
                principalColumn: "PrestadorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
