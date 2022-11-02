using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deal.Migrations
{
    public partial class AdressContentService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Localizacao",
                table: "Servicos",
                newName: "Numero");

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Servicos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "Servicos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Servicos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Servicos");

            migrationBuilder.RenameColumn(
                name: "Numero",
                table: "Servicos",
                newName: "Localizacao");
        }
    }
}
