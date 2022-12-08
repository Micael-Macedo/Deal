﻿// <auto-generated />
using System;
using Deal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Deal.Migrations
{
    [DbContext(typeof(ProjectDealContext))]
    [Migration("20221208200244_TabelaUsuario")]
    partial class TabelaUsuario
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Deal.Models.Acordo", b =>
                {
                    b.Property<int>("AcordoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("AcordoFinalizado")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("AvaliouCliente")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("AvaliouPrestador")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("ClienteFinalizaAcordo")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("FkServico")
                        .HasColumnType("int");

                    b.Property<float?>("NotaCliente")
                        .HasColumnType("float");

                    b.Property<float?>("NotaPrestador")
                        .HasColumnType("float");

                    b.Property<bool>("PrestadorFinalizaAcordo")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("AcordoId");

                    b.HasIndex("FkServico");

                    b.ToTable("Acordos");
                });

            modelBuilder.Entity("Deal.Models.AcordoCancelado", b =>
                {
                    b.Property<int>("AcordoCanceladoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AcordoFk")
                        .HasColumnType("int");

                    b.Property<string>("Justificativa")
                        .HasColumnType("longtext");

                    b.HasKey("AcordoCanceladoId");

                    b.HasIndex("AcordoFk");

                    b.ToTable("AcordosCancelados");
                });

            modelBuilder.Entity("Deal.Models.AreaAtuacao", b =>
                {
                    b.Property<int>("AreaAtuacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Atuacao")
                        .HasColumnType("longtext");

                    b.Property<int?>("PrestadorId")
                        .HasColumnType("int");

                    b.Property<bool>("isOnline")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("AreaAtuacaoId");

                    b.HasIndex("PrestadorId");

                    b.ToTable("AreaAtuacao");
                });

            modelBuilder.Entity("Deal.Models.AreasDeAtuacaoDoPrestador", b =>
                {
                    b.Property<int>("AreasDeAtuacaoDoPrestadorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("FkAreaAtuacao")
                        .HasColumnType("int");

                    b.Property<int?>("FkPrestador")
                        .HasColumnType("int");

                    b.HasKey("AreasDeAtuacaoDoPrestadorId");

                    b.HasIndex("FkAreaAtuacao");

                    b.HasIndex("FkPrestador");

                    b.ToTable("AreasDeAtuacaoDoPrestador");
                });

            modelBuilder.Entity("Deal.Models.Certificado", b =>
                {
                    b.Property<int>("CertificadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CertificadoFotoPortfolio")
                        .HasColumnType("longtext");

                    b.Property<int>("FkPortfolio")
                        .HasColumnType("int");

                    b.HasKey("CertificadoId");

                    b.HasIndex("FkPortfolio");

                    b.ToTable("Certificado");
                });

            modelBuilder.Entity("Deal.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AcordosCancelados")
                        .HasColumnType("int");

                    b.Property<string>("Cep")
                        .HasColumnType("longtext");

                    b.Property<string>("Cpf")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Endereco")
                        .HasColumnType("longtext");

                    b.Property<string>("FotoUsuario")
                        .HasColumnType("longtext");

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.Property<double>("Pontuacao")
                        .HasColumnType("double");

                    b.Property<int>("QtdAcordoRealizados")
                        .HasColumnType("int");

                    b.Property<int>("QtdContaReportada")
                        .HasColumnType("int");

                    b.Property<string>("Senha")
                        .HasColumnType("longtext");

                    b.Property<string>("Telefone")
                        .HasColumnType("longtext");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Deal.Models.Foto", b =>
                {
                    b.Property<int>("FotoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("FkPortfolio")
                        .HasColumnType("int");

                    b.Property<string>("FotoPrestador")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("FotoId");

                    b.HasIndex("FkPortfolio");

                    b.ToTable("Fotos");
                });

            modelBuilder.Entity("Deal.Models.LocalDoPrestador", b =>
                {
                    b.Property<int?>("LocalDoPrestadorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cidade")
                        .HasColumnType("longtext");

                    b.Property<int>("PrestadorFk")
                        .HasColumnType("int");

                    b.HasKey("LocalDoPrestadorId");

                    b.HasIndex("PrestadorFk");

                    b.ToTable("LocaisDoPrestador");
                });

            modelBuilder.Entity("Deal.Models.NotaCliente", b =>
                {
                    b.Property<int>("NotaClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<float>("Avaliacao")
                        .HasColumnType("float");

                    b.Property<int?>("FkAcordo")
                        .HasColumnType("int");

                    b.Property<int?>("FkCliente")
                        .HasColumnType("int");

                    b.HasKey("NotaClienteId");

                    b.HasIndex("FkAcordo");

                    b.HasIndex("FkCliente");

                    b.ToTable("NotaClientes");
                });

            modelBuilder.Entity("Deal.Models.NotaPrestador", b =>
                {
                    b.Property<int>("NotaPrestadorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<float>("Avaliacao")
                        .HasColumnType("float");

                    b.Property<int?>("FkAcordo")
                        .HasColumnType("int");

                    b.Property<int?>("FkPrestador")
                        .HasColumnType("int");

                    b.HasKey("NotaPrestadorId");

                    b.HasIndex("FkAcordo");

                    b.HasIndex("FkPrestador");

                    b.ToTable("NotaPrestadores");
                });

            modelBuilder.Entity("Deal.Models.NovaAreaAtuacao", b =>
                {
                    b.Property<string>("NovaAreaAtuacaoId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("AreaAtuacao")
                        .HasColumnType("longtext");

                    b.Property<bool>("isOnline")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("NovaAreaAtuacaoId");

                    b.ToTable("NovasAreasAtuacoes");
                });

            modelBuilder.Entity("Deal.Models.Portfolio", b =>
                {
                    b.Property<int>("PortfolioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Apresentação")
                        .HasColumnType("longtext");

                    b.Property<string>("ExperienciaProfissional")
                        .HasColumnType("longtext");

                    b.Property<string>("Linkedin")
                        .HasColumnType("longtext");

                    b.Property<string>("Site")
                        .HasColumnType("longtext");

                    b.HasKey("PortfolioId");

                    b.ToTable("Portfolios");
                });

            modelBuilder.Entity("Deal.Models.Prestador", b =>
                {
                    b.Property<int>("PrestadorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AcordosCancelados")
                        .HasColumnType("int");

                    b.Property<string>("Cep")
                        .HasColumnType("longtext");

                    b.Property<string>("Cpf")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Endereco")
                        .HasColumnType("longtext");

                    b.Property<int?>("FkPortfolio")
                        .HasColumnType("int");

                    b.Property<string>("FotoPrestador")
                        .HasColumnType("longtext");

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.Property<double>("Pontuacao")
                        .HasColumnType("double");

                    b.Property<int>("QtdContaReportada")
                        .HasColumnType("int");

                    b.Property<int>("QtdServicoRealizados")
                        .HasColumnType("int");

                    b.Property<string>("Senha")
                        .HasColumnType("longtext");

                    b.Property<string>("Telefone")
                        .HasColumnType("longtext");

                    b.HasKey("PrestadorId");

                    b.HasIndex("FkPortfolio");

                    b.ToTable("Prestadores");
                });

            modelBuilder.Entity("Deal.Models.ReporteCliente", b =>
                {
                    b.Property<int>("ReporteClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("FkCliente")
                        .HasColumnType("int");

                    b.Property<int>("FkPrestador")
                        .HasColumnType("int");

                    b.Property<int>("FkServico")
                        .HasColumnType("int");

                    b.Property<string>("Motivo")
                        .HasColumnType("longtext");

                    b.HasKey("ReporteClienteId");

                    b.HasIndex("FkCliente");

                    b.HasIndex("FkPrestador");

                    b.HasIndex("FkServico");

                    b.ToTable("ReportesClientes");
                });

            modelBuilder.Entity("Deal.Models.ReportePrestador", b =>
                {
                    b.Property<int>("ReportePrestadorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("FkCliente")
                        .HasColumnType("int");

                    b.Property<int>("FkPrestador")
                        .HasColumnType("int");

                    b.Property<int>("FkServico")
                        .HasColumnType("int");

                    b.Property<string>("Motivo")
                        .HasColumnType("longtext");

                    b.Property<int?>("PrestadorId")
                        .HasColumnType("int");

                    b.HasKey("ReportePrestadorId");

                    b.HasIndex("FkCliente");

                    b.HasIndex("FkServico");

                    b.HasIndex("PrestadorId");

                    b.ToTable("ReportesPrestadores");
                });

            modelBuilder.Entity("Deal.Models.Servico", b =>
                {
                    b.Property<int>("ServicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cep")
                        .HasColumnType("longtext");

                    b.Property<string>("Cidade")
                        .HasColumnType("longtext");

                    b.Property<string>("Descricao")
                        .HasColumnType("longtext");

                    b.Property<string>("Endereco")
                        .HasColumnType("longtext");

                    b.Property<string>("Estado")
                        .HasColumnType("longtext");

                    b.Property<int?>("FkCategoria")
                        .HasColumnType("int");

                    b.Property<int?>("FkCliente")
                        .HasColumnType("int");

                    b.Property<int?>("FkPrestador")
                        .HasColumnType("int");

                    b.Property<bool>("IsAcordoFeito")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsDisponivel")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Latitude")
                        .HasColumnType("longtext");

                    b.Property<string>("Longitude")
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.Property<string>("Numero")
                        .HasColumnType("longtext");

                    b.Property<string>("Status")
                        .HasColumnType("longtext");

                    b.HasKey("ServicoId");

                    b.HasIndex("FkCategoria");

                    b.HasIndex("FkCliente");

                    b.HasIndex("FkPrestador");

                    b.ToTable("Servicos");
                });

            modelBuilder.Entity("Deal.Models.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Perfil")
                        .HasColumnType("int");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Deal.Models.Video", b =>
                {
                    b.Property<int>("VideoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("FkPortfolio")
                        .HasColumnType("int");

                    b.Property<string>("VideoPrestador")
                        .HasColumnType("longtext");

                    b.HasKey("VideoId");

                    b.HasIndex("FkPortfolio");

                    b.ToTable("Video");
                });

            modelBuilder.Entity("Deal.Models.Acordo", b =>
                {
                    b.HasOne("Deal.Models.Servico", "Servico")
                        .WithMany()
                        .HasForeignKey("FkServico");

                    b.Navigation("Servico");
                });

            modelBuilder.Entity("Deal.Models.AcordoCancelado", b =>
                {
                    b.HasOne("Deal.Models.Acordo", "Acordo")
                        .WithMany()
                        .HasForeignKey("AcordoFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Acordo");
                });

            modelBuilder.Entity("Deal.Models.AreaAtuacao", b =>
                {
                    b.HasOne("Deal.Models.Prestador", null)
                        .WithMany("AreasAtuacao")
                        .HasForeignKey("PrestadorId");
                });

            modelBuilder.Entity("Deal.Models.AreasDeAtuacaoDoPrestador", b =>
                {
                    b.HasOne("Deal.Models.AreaAtuacao", "AreaAtuacao")
                        .WithMany()
                        .HasForeignKey("FkAreaAtuacao");

                    b.HasOne("Deal.Models.Prestador", "Prestador")
                        .WithMany("AreasDeAtuacaoDoPrestador")
                        .HasForeignKey("FkPrestador");

                    b.Navigation("AreaAtuacao");

                    b.Navigation("Prestador");
                });

            modelBuilder.Entity("Deal.Models.Certificado", b =>
                {
                    b.HasOne("Deal.Models.Portfolio", "Portfolio")
                        .WithMany("Certificados")
                        .HasForeignKey("FkPortfolio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Portfolio");
                });

            modelBuilder.Entity("Deal.Models.Foto", b =>
                {
                    b.HasOne("Deal.Models.Portfolio", "Portfolio")
                        .WithMany("Fotos")
                        .HasForeignKey("FkPortfolio");

                    b.Navigation("Portfolio");
                });

            modelBuilder.Entity("Deal.Models.LocalDoPrestador", b =>
                {
                    b.HasOne("Deal.Models.Prestador", "Prestador")
                        .WithMany("LocaisDoPrestador")
                        .HasForeignKey("PrestadorFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prestador");
                });

            modelBuilder.Entity("Deal.Models.NotaCliente", b =>
                {
                    b.HasOne("Deal.Models.Acordo", "Acordo")
                        .WithMany()
                        .HasForeignKey("FkAcordo");

                    b.HasOne("Deal.Models.Cliente", "Cliente")
                        .WithMany("NotasDoCliente")
                        .HasForeignKey("FkCliente");

                    b.Navigation("Acordo");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Deal.Models.NotaPrestador", b =>
                {
                    b.HasOne("Deal.Models.Acordo", "Acordo")
                        .WithMany()
                        .HasForeignKey("FkAcordo");

                    b.HasOne("Deal.Models.Prestador", "Prestador")
                        .WithMany("NotasDoPrestador")
                        .HasForeignKey("FkPrestador");

                    b.Navigation("Acordo");

                    b.Navigation("Prestador");
                });

            modelBuilder.Entity("Deal.Models.Prestador", b =>
                {
                    b.HasOne("Deal.Models.Portfolio", "Portfolio")
                        .WithMany()
                        .HasForeignKey("FkPortfolio");

                    b.Navigation("Portfolio");
                });

            modelBuilder.Entity("Deal.Models.ReporteCliente", b =>
                {
                    b.HasOne("Deal.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("FkCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Deal.Models.Prestador", "Prestador")
                        .WithMany()
                        .HasForeignKey("FkPrestador")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Deal.Models.Servico", "Servico")
                        .WithMany()
                        .HasForeignKey("FkServico")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Prestador");

                    b.Navigation("Servico");
                });

            modelBuilder.Entity("Deal.Models.ReportePrestador", b =>
                {
                    b.HasOne("Deal.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("FkCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Deal.Models.Servico", "Servico")
                        .WithMany()
                        .HasForeignKey("FkServico")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Deal.Models.Prestador", "prestador")
                        .WithMany()
                        .HasForeignKey("PrestadorId");

                    b.Navigation("Cliente");

                    b.Navigation("Servico");

                    b.Navigation("prestador");
                });

            modelBuilder.Entity("Deal.Models.Servico", b =>
                {
                    b.HasOne("Deal.Models.AreaAtuacao", "Categoria")
                        .WithMany()
                        .HasForeignKey("FkCategoria");

                    b.HasOne("Deal.Models.Cliente", "Cliente")
                        .WithMany("Servicos")
                        .HasForeignKey("FkCliente");

                    b.HasOne("Deal.Models.Prestador", "Prestador")
                        .WithMany()
                        .HasForeignKey("FkPrestador");

                    b.Navigation("Categoria");

                    b.Navigation("Cliente");

                    b.Navigation("Prestador");
                });

            modelBuilder.Entity("Deal.Models.Video", b =>
                {
                    b.HasOne("Deal.Models.Portfolio", "Portfolio")
                        .WithMany("Videos")
                        .HasForeignKey("FkPortfolio");

                    b.Navigation("Portfolio");
                });

            modelBuilder.Entity("Deal.Models.Cliente", b =>
                {
                    b.Navigation("NotasDoCliente");

                    b.Navigation("Servicos");
                });

            modelBuilder.Entity("Deal.Models.Portfolio", b =>
                {
                    b.Navigation("Certificados");

                    b.Navigation("Fotos");

                    b.Navigation("Videos");
                });

            modelBuilder.Entity("Deal.Models.Prestador", b =>
                {
                    b.Navigation("AreasAtuacao");

                    b.Navigation("AreasDeAtuacaoDoPrestador");

                    b.Navigation("LocaisDoPrestador");

                    b.Navigation("NotasDoPrestador");
                });
#pragma warning restore 612, 618
        }
    }
}
