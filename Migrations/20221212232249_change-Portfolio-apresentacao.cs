using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deal.Migrations
{
    public partial class changePortfolioapresentacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Apresentação",
                table: "Portfolios",
                newName: "Apresentacao");

            migrationBuilder.UpdateData(
                table: "Prestadores",
                keyColumn: "Senha",
                keyValue: null,
                column: "Senha",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                table: "Prestadores",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Apresentacao",
                table: "Portfolios",
                newName: "Apresentação");

            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                table: "Prestadores",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
