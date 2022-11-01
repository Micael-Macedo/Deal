using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deal.Migrations
{
    public partial class addForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_Clientes_ClienteId",
                table: "Servicos");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Servicos",
                newName: "FkCliente");

            migrationBuilder.RenameIndex(
                name: "IX_Servicos_ClienteId",
                table: "Servicos",
                newName: "IX_Servicos_FkCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_Clientes_FkCliente",
                table: "Servicos",
                column: "FkCliente",
                principalTable: "Clientes",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_Clientes_FkCliente",
                table: "Servicos");

            migrationBuilder.RenameColumn(
                name: "FkCliente",
                table: "Servicos",
                newName: "ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Servicos_FkCliente",
                table: "Servicos",
                newName: "IX_Servicos_ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_Clientes_ClienteId",
                table: "Servicos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
