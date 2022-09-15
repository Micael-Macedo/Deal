using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Deal.Models
{
    public class ProjectDealContext: DbContext
    {
        public ProjectDealContext(DbContextOptions<ProjectDealContext> options) : base(options){}

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Acordo> Acordos { get; set; }
        public DbSet<NovaAreaAtuacao> NovasAreasAtuacoes { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Prestador> Prestadores { get; set; }
        public DbSet<Servico> Servicos { get; set; }
    }
}