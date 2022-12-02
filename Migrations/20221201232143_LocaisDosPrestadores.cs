using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deal.Migrations
{
    public partial class LocaisDosPrestadores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocaisDoPrestador",
                columns: table => new
                {
                    LocaisDoPrestadorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PrestadorFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocaisDoPrestador", x => x.LocaisDoPrestadorId);
                    table.ForeignKey(
                        name: "FK_LocaisDoPrestador_Prestadores_PrestadorFk",
                        column: x => x.PrestadorFk,
                        principalTable: "Prestadores",
                        principalColumn: "PrestadorId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_LocaisDoPrestador_PrestadorFk",
                table: "LocaisDoPrestador",
                column: "PrestadorFk");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocaisDoPrestador");
        }
    }
}
