using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deal.Migrations
{
    public partial class ChangeTypeLocaisToLocal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LocaisDoPrestadorId",
                table: "LocaisDoPrestador",
                newName: "LocalDoPrestadorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LocalDoPrestadorId",
                table: "LocaisDoPrestador",
                newName: "LocaisDoPrestadorId");
        }
    }
}
