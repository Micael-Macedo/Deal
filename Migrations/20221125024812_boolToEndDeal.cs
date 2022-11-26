using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deal.Migrations
{
    public partial class boolToEndDeal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ClienteFinalizaAcordo",
                table: "Acordos",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PrestadorFinalizaAcordo",
                table: "Acordos",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClienteFinalizaAcordo",
                table: "Acordos");

            migrationBuilder.DropColumn(
                name: "PrestadorFinalizaAcordo",
                table: "Acordos");
        }
    }
}
