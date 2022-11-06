using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deal.Migrations
{
    public partial class FkPrestadorToService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FkPrestador",
                table: "Servicos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_FkPrestador",
                table: "Servicos",
                column: "FkPrestador");

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_Prestadores_FkPrestador",
                table: "Servicos",
                column: "FkPrestador",
                principalTable: "Prestadores",
                principalColumn: "PrestadorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_Prestadores_FkPrestador",
                table: "Servicos");

            migrationBuilder.DropIndex(
                name: "IX_Servicos_FkPrestador",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "FkPrestador",
                table: "Servicos");
        }
    }
}
