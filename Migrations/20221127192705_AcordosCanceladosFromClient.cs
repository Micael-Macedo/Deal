using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deal.Migrations
{
    public partial class AcordosCanceladosFromClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ServicosCancelados",
                table: "Clientes",
                newName: "AcordosCancelados");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AcordosCancelados",
                table: "Clientes",
                newName: "ServicosCancelados");
        }
    }
}
