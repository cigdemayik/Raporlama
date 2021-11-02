using Microsoft.EntityFrameworkCore;
using Raporlama.DataAccess.Concrete.EfCore.Configurations;
using Raporlama.DataAccess.Concrete.EFramework.Configurations;
using Raporlama.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raporlama.DataAccess.Concrete.EFramework.Context
{
    public class RaporlamaContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-BBKEID4;Initial Catalog=RaporDb;Persist Security Info=True;User ID=sa;Password=12811281;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ReportConfiguration());
            modelBuilder.ApplyConfiguration(new ReportTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<ReportType> ReportTypes { get; set; }
        public virtual DbSet<Company> Companies { get; set; }

    }
}
