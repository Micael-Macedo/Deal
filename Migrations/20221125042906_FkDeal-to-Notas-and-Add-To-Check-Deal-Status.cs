using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deal.Migrations
{
    public partial class FkDealtoNotasandAddToCheckDealStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotaClientes_Clientes_FkCliente",
                table: "NotaClientes");

            migrationBuilder.AddColumn<int>(
                name: "FkAcordo",
                table: "NotaPrestadores",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FkCliente",
                table: "NotaClientes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "FkAcordo",
                table: "NotaClientes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AcordoFinalizado",
                table: "Acordos",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_NotaPrestadores_FkAcordo",
                table: "NotaPrestadores",
                column: "FkAcordo");

            migrationBuilder.CreateIndex(
                name: "IX_NotaClientes_FkAcordo",
                table: "NotaClientes",
                column: "FkAcordo");

            migrationBuilder.AddForeignKey(
                name: "FK_NotaClientes_Acordos_FkAcordo",
                table: "NotaClientes",
                column: "FkAcordo",
                principalTable: "Acordos",
                principalColumn: "AcordoId");

            migrationBuilder.AddForeignKey(
                name: "FK_NotaClientes_Clientes_FkCliente",
                table: "NotaClientes",
                column: "FkCliente",
                principalTable: "Clientes",
                principalColumn: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_NotaPrestadores_Acordos_FkAcordo",
                table: "NotaPrestadores",
                column: "FkAcordo",
                principalTable: "Acordos",
                principalColumn: "AcordoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotaClientes_Acordos_FkAcordo",
                table: "NotaClientes");

            migrationBuilder.DropForeignKey(
                name: "FK_NotaClientes_Clientes_FkCliente",
                table: "NotaClientes");

            migrationBuilder.DropForeignKey(
                name: "FK_NotaPrestadores_Acordos_FkAcordo",
                table: "NotaPrestadores");

            migrationBuilder.DropIndex(
                name: "IX_NotaPrestadores_FkAcordo",
                table: "NotaPrestadores");

            migrationBuilder.DropIndex(
                name: "IX_NotaClientes_FkAcordo",
                table: "NotaClientes");

            migrationBuilder.DropColumn(
                name: "FkAcordo",
                table: "NotaPrestadores");

            migrationBuilder.DropColumn(
                name: "FkAcordo",
                table: "NotaClientes");

            migrationBuilder.DropColumn(
                name: "AcordoFinalizado",
                table: "Acordos");

            migrationBuilder.AlterColumn<int>(
                name: "FkCliente",
                table: "NotaClientes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_NotaClientes_Clientes_FkCliente",
                table: "NotaClientes",
                column: "FkCliente",
                principalTable: "Clientes",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
