using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deal.Migrations
{
    public partial class AreaAtuacaoToPrestador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PrestadorId",
                table: "AreaAtuacao",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AreaAtuacao_PrestadorId",
                table: "AreaAtuacao",
                column: "PrestadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_AreaAtuacao_Prestadores_PrestadorId",
                table: "AreaAtuacao",
                column: "PrestadorId",
                principalTable: "Prestadores",
                principalColumn: "PrestadorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AreaAtuacao_Prestadores_PrestadorId",
                table: "AreaAtuacao");

            migrationBuilder.DropIndex(
                name: "IX_AreaAtuacao_PrestadorId",
                table: "AreaAtuacao");

            migrationBuilder.DropColumn(
                name: "PrestadorId",
                table: "AreaAtuacao");
        }
    }
}
