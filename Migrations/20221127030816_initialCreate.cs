using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deal.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FotoUsuario = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cpf = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    Endereco = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cep = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Senha = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    QtdAcordoRealizados = table.Column<int>(type: "int", nullable: false),
                    ServicosCancelados = table.Column<int>(type: "int", nullable: false),
                    Pontuacao = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "NovasAreasAtuacoes",
                columns: table => new
                {
                    NovaAreaAtuacaoId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AreaAtuacao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NovasAreasAtuacoes", x => x.NovaAreaAtuacaoId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Portfolios",
                columns: table => new
                {
                    PortfolioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExperienciaProfissional = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolios", x => x.PortfolioId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Certificado",
                columns: table => new
                {
                    CertificadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CertificadoFotoPortfolio = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FkPortfolio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificado", x => x.CertificadoId);
                    table.ForeignKey(
                        name: "FK_Certificado_Portfolios_FkPortfolio",
                        column: x => x.FkPortfolio,
                        principalTable: "Portfolios",
                        principalColumn: "PortfolioId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Fotos",
                columns: table => new
                {
                    FotoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FotoPrestador = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FkPortfolio = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fotos", x => x.FotoId);
                    table.ForeignKey(
                        name: "FK_Fotos_Portfolios_FkPortfolio",
                        column: x => x.FkPortfolio,
                        principalTable: "Portfolios",
                        principalColumn: "PortfolioId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Prestadores",
                columns: table => new
                {
                    PrestadorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FotoPrestador = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FkPortfolio = table.Column<int>(type: "int", nullable: true),
                    Nome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cpf = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    Endereco = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cep = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Senha = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    QtdServicoRealizados = table.Column<int>(type: "int", nullable: false),
                    Pontuacao = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestadores", x => x.PrestadorId);
                    table.ForeignKey(
                        name: "FK_Prestadores_Portfolios_FkPortfolio",
                        column: x => x.FkPortfolio,
                        principalTable: "Portfolios",
                        principalColumn: "PortfolioId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Video",
                columns: table => new
                {
                    VideoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VideoPrestador = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FkPortfolio = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Video", x => x.VideoId);
                    table.ForeignKey(
                        name: "FK_Video_Portfolios_FkPortfolio",
                        column: x => x.FkPortfolio,
                        principalTable: "Portfolios",
                        principalColumn: "PortfolioId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AreaAtuacao",
                columns: table => new
                {
                    AreaAtuacaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Atuacao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PrestadorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaAtuacao", x => x.AreaAtuacaoId);
                    table.ForeignKey(
                        name: "FK_AreaAtuacao_Prestadores_PrestadorId",
                        column: x => x.PrestadorId,
                        principalTable: "Prestadores",
                        principalColumn: "PrestadorId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AreasDeAtuacaoDoPrestador",
                columns: table => new
                {
                    AreasDeAtuacaoDoPrestadorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FkPrestador = table.Column<int>(type: "int", nullable: true),
                    FkAreaAtuacao = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreasDeAtuacaoDoPrestador", x => x.AreasDeAtuacaoDoPrestadorId);
                    table.ForeignKey(
                        name: "FK_AreasDeAtuacaoDoPrestador_AreaAtuacao_FkAreaAtuacao",
                        column: x => x.FkAreaAtuacao,
                        principalTable: "AreaAtuacao",
                        principalColumn: "AreaAtuacaoId");
                    table.ForeignKey(
                        name: "FK_AreasDeAtuacaoDoPrestador_Prestadores_FkPrestador",
                        column: x => x.FkPrestador,
                        principalTable: "Prestadores",
                        principalColumn: "PrestadorId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    ServicoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FkCliente = table.Column<int>(type: "int", nullable: true),
                    Nome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descricao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Endereco = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cidade = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Numero = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cep = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FkCategoria = table.Column<int>(type: "int", nullable: true),
                    FkPrestador = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Latitude = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Longitude = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.ServicoId);
                    table.ForeignKey(
                        name: "FK_Servicos_AreaAtuacao_FkCategoria",
                        column: x => x.FkCategoria,
                        principalTable: "AreaAtuacao",
                        principalColumn: "AreaAtuacaoId");
                    table.ForeignKey(
                        name: "FK_Servicos_Clientes_FkCliente",
                        column: x => x.FkCliente,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId");
                    table.ForeignKey(
                        name: "FK_Servicos_Prestadores_FkPrestador",
                        column: x => x.FkPrestador,
                        principalTable: "Prestadores",
                        principalColumn: "PrestadorId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Acordos",
                columns: table => new
                {
                    AcordoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FkServico = table.Column<int>(type: "int", nullable: true),
                    NotaCliente = table.Column<float>(type: "float", nullable: true),
                    NotaPrestador = table.Column<float>(type: "float", nullable: true),
                    AvaliouCliente = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AvaliouPrestador = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ClienteFinalizaAcordo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PrestadorFinalizaAcordo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AcordoFinalizado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acordos", x => x.AcordoId);
                    table.ForeignKey(
                        name: "FK_Acordos_Servicos_FkServico",
                        column: x => x.FkServico,
                        principalTable: "Servicos",
                        principalColumn: "ServicoId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "NotaClientes",
                columns: table => new
                {
                    NotaClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Avaliacao = table.Column<float>(type: "float", nullable: false),
                    FkCliente = table.Column<int>(type: "int", nullable: true),
                    FkAcordo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotaClientes", x => x.NotaClienteId);
                    table.ForeignKey(
                        name: "FK_NotaClientes_Acordos_FkAcordo",
                        column: x => x.FkAcordo,
                        principalTable: "Acordos",
                        principalColumn: "AcordoId");
                    table.ForeignKey(
                        name: "FK_NotaClientes_Clientes_FkCliente",
                        column: x => x.FkCliente,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "NotaPrestadores",
                columns: table => new
                {
                    NotaPrestadorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Avaliacao = table.Column<float>(type: "float", nullable: false),
                    FkPrestador = table.Column<int>(type: "int", nullable: true),
                    FkAcordo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotaPrestadores", x => x.NotaPrestadorId);
                    table.ForeignKey(
                        name: "FK_NotaPrestadores_Acordos_FkAcordo",
                        column: x => x.FkAcordo,
                        principalTable: "Acordos",
                        principalColumn: "AcordoId");
                    table.ForeignKey(
                        name: "FK_NotaPrestadores_Prestadores_FkPrestador",
                        column: x => x.FkPrestador,
                        principalTable: "Prestadores",
                        principalColumn: "PrestadorId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Acordos_FkServico",
                table: "Acordos",
                column: "FkServico");

            migrationBuilder.CreateIndex(
                name: "IX_AreaAtuacao_PrestadorId",
                table: "AreaAtuacao",
                column: "PrestadorId");

            migrationBuilder.CreateIndex(
                name: "IX_AreasDeAtuacaoDoPrestador_FkAreaAtuacao",
                table: "AreasDeAtuacaoDoPrestador",
                column: "FkAreaAtuacao");

            migrationBuilder.CreateIndex(
                name: "IX_AreasDeAtuacaoDoPrestador_FkPrestador",
                table: "AreasDeAtuacaoDoPrestador",
                column: "FkPrestador");

            migrationBuilder.CreateIndex(
                name: "IX_Certificado_FkPortfolio",
                table: "Certificado",
                column: "FkPortfolio");

            migrationBuilder.CreateIndex(
                name: "IX_Fotos_FkPortfolio",
                table: "Fotos",
                column: "FkPortfolio");

            migrationBuilder.CreateIndex(
                name: "IX_NotaClientes_FkAcordo",
                table: "NotaClientes",
                column: "FkAcordo");

            migrationBuilder.CreateIndex(
                name: "IX_NotaClientes_FkCliente",
                table: "NotaClientes",
                column: "FkCliente");

            migrationBuilder.CreateIndex(
                name: "IX_NotaPrestadores_FkAcordo",
                table: "NotaPrestadores",
                column: "FkAcordo");

            migrationBuilder.CreateIndex(
                name: "IX_NotaPrestadores_FkPrestador",
                table: "NotaPrestadores",
                column: "FkPrestador");

            migrationBuilder.CreateIndex(
                name: "IX_Prestadores_FkPortfolio",
                table: "Prestadores",
                column: "FkPortfolio");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_FkCategoria",
                table: "Servicos",
                column: "FkCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_FkCliente",
                table: "Servicos",
                column: "FkCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_FkPrestador",
                table: "Servicos",
                column: "FkPrestador");

            migrationBuilder.CreateIndex(
                name: "IX_Video_FkPortfolio",
                table: "Video",
                column: "FkPortfolio");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AreasDeAtuacaoDoPrestador");

            migrationBuilder.DropTable(
                name: "Certificado");

            migrationBuilder.DropTable(
                name: "Fotos");

            migrationBuilder.DropTable(
                name: "NotaClientes");

            migrationBuilder.DropTable(
                name: "NotaPrestadores");

            migrationBuilder.DropTable(
                name: "NovasAreasAtuacoes");

            migrationBuilder.DropTable(
                name: "Video");

            migrationBuilder.DropTable(
                name: "Acordos");

            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "AreaAtuacao");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Prestadores");

            migrationBuilder.DropTable(
                name: "Portfolios");
        }
    }
}
