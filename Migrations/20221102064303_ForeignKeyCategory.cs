using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deal.Migrations
{
    public partial class ForeignKeyCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Servicos");

            migrationBuilder.AddColumn<int>(
                name: "FkCategoria",
                table: "Servicos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_FkCategoria",
                table: "Servicos",
                column: "FkCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_AreaAtuacao_FkCategoria",
                table: "Servicos",
                column: "FkCategoria",
                principalTable: "AreaAtuacao",
                principalColumn: "AreaAtuacaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_AreaAtuacao_FkCategoria",
                table: "Servicos");

            migrationBuilder.DropIndex(
                name: "IX_Servicos_FkCategoria",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "FkCategoria",
                table: "Servicos");

            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Servicos",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
