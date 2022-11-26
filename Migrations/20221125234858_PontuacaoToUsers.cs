using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deal.Migrations
{
    public partial class PontuacaoToUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotaPrestadores_Prestadores_FkPrestador",
                table: "NotaPrestadores");

            migrationBuilder.DropColumn(
                name: "Pontuacao",
                table: "Prestadores");

            migrationBuilder.DropColumn(
                name: "Pontuacao",
                table: "Clientes");

            migrationBuilder.AlterColumn<int>(
                name: "FkPrestador",
                table: "NotaPrestadores",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_NotaPrestadores_Prestadores_FkPrestador",
                table: "NotaPrestadores",
                column: "FkPrestador",
                principalTable: "Prestadores",
                principalColumn: "PrestadorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotaPrestadores_Prestadores_FkPrestador",
                table: "NotaPrestadores");

            migrationBuilder.AddColumn<float>(
                name: "Pontuacao",
                table: "Prestadores",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AlterColumn<int>(
                name: "FkPrestador",
                table: "NotaPrestadores",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Pontuacao",
                table: "Clientes",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddForeignKey(
                name: "FK_NotaPrestadores_Prestadores_FkPrestador",
                table: "NotaPrestadores",
                column: "FkPrestador",
                principalTable: "Prestadores",
                principalColumn: "PrestadorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
