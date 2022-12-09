using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deal.Migrations
{
    public partial class MoreContentPortfolio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Portfolios",
                newName: "Site");

            migrationBuilder.AlterColumn<double>(
                name: "Pontuacao",
                table: "Prestadores",
                type: "double",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float");

            migrationBuilder.AddColumn<string>(
                name: "Apresentação",
                table: "Portfolios",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Linkedin",
                table: "Portfolios",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<double>(
                name: "Pontuacao",
                table: "Clientes",
                type: "double",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apresentação",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "Linkedin",
                table: "Portfolios");

            migrationBuilder.RenameColumn(
                name: "Site",
                table: "Portfolios",
                newName: "Descricao");

            migrationBuilder.AlterColumn<float>(
                name: "Pontuacao",
                table: "Prestadores",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AlterColumn<float>(
                name: "Pontuacao",
                table: "Clientes",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");
        }
    }
}
