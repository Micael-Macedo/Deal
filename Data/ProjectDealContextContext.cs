using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Deal.Models;

    public class ProjectDealContextContext : DbContext
    {
        public ProjectDealContextContext (DbContextOptions<ProjectDealContextContext> options)
            : base(options)
        {
        }

        public DbSet<Deal.Models.Cliente> Cliente { get; set; } = default!;
    }
