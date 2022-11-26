using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deal.Migrations
{
    public partial class SetPontuacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Pontuacao",
                table: "Prestadores",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Pontuacao",
                table: "Clientes",
                type: "float",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pontuacao",
                table: "Prestadores");

            migrationBuilder.DropColumn(
                name: "Pontuacao",
                table: "Clientes");
        }
    }
}
