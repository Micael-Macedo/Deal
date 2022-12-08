using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Deal.Models;

namespace Deal.Models
{
    public class ProjectDealContext: DbContext
    {
        public ProjectDealContext(DbContextOptions<ProjectDealContext> options) : base(options){}

        public DbSet<Cliente>? Clientes { get; set; }
        public DbSet<Acordo>? Acordos { get; set; }
        public DbSet<NovaAreaAtuacao>? NovasAreasAtuacoes { get; set; }
        public DbSet<Portfolio>? Portfolios { get; set; }
        public DbSet<Prestador>? Prestadores { get; set; }
        public DbSet<Servico>? Servicos { get; set; }
        public DbSet<Video>? Video { get; set; }
        public DbSet<AreaAtuacao>? AreaAtuacao { get; set; }
        public DbSet<Certificado>? Certificado { get; set; }
        public DbSet<Foto>? Fotos { get; set; }
        public DbSet<NotaCliente>? NotaClientes { get; set; }
        public DbSet<NotaPrestador>? NotaPrestadores { get; set; }
        public DbSet<AreasDeAtuacaoDoPrestador>? AreasDeAtuacaoDoPrestador { get; set; }
        public DbSet<AcordoCancelado>? AcordosCancelados { get; set; }
        public DbSet<LocalDoPrestador>? LocaisDoPrestador { get; set; }
        public DbSet<ReporteCliente>? ReportesClientes { get; set; }
        public DbSet<ReportePrestador>? ReportesPrestadores { get; set; }
        public DbSet<Usuario>? Usuarios { get; set; }
    }
}