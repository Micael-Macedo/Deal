using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deal.Migrations
{
    public partial class NotaToUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acordos_Clientes_FkCliente",
                table: "Acordos");

            migrationBuilder.DropForeignKey(
                name: "FK_Acordos_Prestadores_FkPrestador",
                table: "Acordos");

            migrationBuilder.DropIndex(
                name: "IX_Acordos_FkCliente",
                table: "Acordos");

            migrationBuilder.DropIndex(
                name: "IX_Acordos_FkPrestador",
                table: "Acordos");

            migrationBuilder.DropColumn(
                name: "FkCliente",
                table: "Acordos");

            migrationBuilder.DropColumn(
                name: "FkPrestador",
                table: "Acordos");

            migrationBuilder.AddColumn<float>(
                name: "NotaCliente",
                table: "Acordos",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "NotaPrestador",
                table: "Acordos",
                type: "float",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotaCliente",
                table: "Acordos");

            migrationBuilder.DropColumn(
                name: "NotaPrestador",
                table: "Acordos");

            migrationBuilder.AddColumn<int>(
                name: "FkCliente",
                table: "Acordos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FkPrestador",
                table: "Acordos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Acordos_FkCliente",
                table: "Acordos",
                column: "FkCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Acordos_FkPrestador",
                table: "Acordos",
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
        }
    }
}
