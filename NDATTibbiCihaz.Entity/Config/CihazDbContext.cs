using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NDATTibbiCihaz.Common;

namespace NDATTibbiCihaz.Entity.Config
{
    public class CihazDbContext : DbContext
    {

        public DbSet<Hasta> Hastalar { get; set; }

        public DbSet<Rapor> Raporlar { get; set; }

        public DbSet<Makine> Makineler { get; set; }

        public DbSet<Gorsel> Gorseller { get; set; }

        public DbSet<Doktor> Doktorlar { get; set; }

        public DbSet<Cikti> Ciktilar { get; set; }

        public CihazDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=NDATTibbiCihaz;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
