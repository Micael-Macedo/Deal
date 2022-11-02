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
    [Migration("20221102000216_LatLongService")]
    partial class LatLongService
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

                    b.Property<int>("FkCliente")
                        .HasColumnType("int");

                    b.Property<int>("FkPrestador")
                        .HasColumnType("int");

                    b.Property<int>("FkServico")
                        .HasColumnType("int");

                    b.HasKey("AcordoId");

                    b.HasIndex("FkCliente");

                    b.HasIndex("FkPrestador");

                    b.HasIndex("FkServico");

                    b.ToTable("Acordos");
                });

            modelBuilder.Entity("Deal.Models.AreaAtuacao", b =>
                {
                    b.Property<int>("AreaAtuacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Atuacao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("AreaAtuacaoId");

                    b.ToTable("AreaAtuacao");
                });

            modelBuilder.Entity("Deal.Models.Certificado", b =>
                {
                    b.Property<int>("CertificadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CertificadoFotoPortfolio")
                        .IsRequired()
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

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("QtdAcordoRealizados")
                        .HasColumnType("int");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Deal.Models.Foto", b =>
                {
                    b.Property<int>("FotoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("FkPortfolio")
                        .HasColumnType("int");

                    b.Property<string>("FotoPortfolio")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("FotoId");

                    b.HasIndex("FkPortfolio");

                    b.ToTable("Foto");
                });

            modelBuilder.Entity("Deal.Models.Nota", b =>
                {
                    b.Property<int>("NotaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<float>("Avaliacao")
                        .HasColumnType("float");

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int?>("PrestadorId")
                        .HasColumnType("int");

                    b.HasKey("NotaId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("PrestadorId");

                    b.ToTable("Nota");
                });

            modelBuilder.Entity("Deal.Models.NovaAreaAtuacao", b =>
                {
                    b.Property<string>("NovaAreaAtuacaoId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("AreaAtuacao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("NovaAreaAtuacaoId");

                    b.ToTable("NovasAreasAtuacoes");
                });

            modelBuilder.Entity("Deal.Models.Portfolio", b =>
                {
                    b.Property<int>("PortfolioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ExperienciaProfissional")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("PortfolioId");

                    b.ToTable("Portfolios");
                });

            modelBuilder.Entity("Deal.Models.Prestador", b =>
                {
                    b.Property<int>("PrestadorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("PortfolioId")
                        .HasColumnType("int");

                    b.Property<int>("QtdServicoRealizados")
                        .HasColumnType("int");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("PrestadorId");

                    b.HasIndex("PortfolioId");

                    b.ToTable("Prestadores");
                });

            modelBuilder.Entity("Deal.Models.Servico", b =>
                {
                    b.Property<int>("ServicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("FkCliente")
                        .HasColumnType("int");

                    b.Property<double>("Latitude")
                        .HasColumnType("double");

                    b.Property<string>("Localizacao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Longitude")
                        .HasColumnType("double");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ServicoId");

                    b.HasIndex("FkCliente");

                    b.ToTable("Servicos");
                });

            modelBuilder.Entity("Deal.Models.Video", b =>
                {
                    b.Property<int>("VideoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("FkPortfolio")
                        .HasColumnType("int");

                    b.Property<string>("VideoPortfolio")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("VideoId");

                    b.HasIndex("FkPortfolio");

                    b.ToTable("Video");
                });

            modelBuilder.Entity("Deal.Models.Acordo", b =>
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
                        .HasForeignKey("FkPortfolio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Portfolio");
                });

            modelBuilder.Entity("Deal.Models.Nota", b =>
                {
                    b.HasOne("Deal.Models.Cliente", null)
                        .WithMany("Notas")
                        .HasForeignKey("ClienteId");

                    b.HasOne("Deal.Models.Prestador", null)
                        .WithMany("Notas")
                        .HasForeignKey("PrestadorId");
                });

            modelBuilder.Entity("Deal.Models.Prestador", b =>
                {
                    b.HasOne("Deal.Models.Portfolio", "Portfolio")
                        .WithMany()
                        .HasForeignKey("PortfolioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Portfolio");
                });

            modelBuilder.Entity("Deal.Models.Servico", b =>
                {
                    b.HasOne("Deal.Models.Cliente", "Cliente")
                        .WithMany("Servicos")
                        .HasForeignKey("FkCliente");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Deal.Models.Video", b =>
                {
                    b.HasOne("Deal.Models.Portfolio", "Portfolio")
                        .WithMany("Videos")
                        .HasForeignKey("FkPortfolio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Portfolio");
                });

            modelBuilder.Entity("Deal.Models.Cliente", b =>
                {
                    b.Navigation("Notas");

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
                    b.Navigation("Notas");
                });
#pragma warning restore 612, 618
        }
    }
}
