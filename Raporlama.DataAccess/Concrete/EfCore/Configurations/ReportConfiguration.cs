using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Raporlama.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raporlama.DataAccess.Concrete.EFramework.Configurations
{
    public class ReportConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.ToTable("Report");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ReportTypeId).IsRequired();

            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(512);

            builder.HasOne(x => x.ReportType)
                .WithMany(x => x.Reports)
                .HasForeignKey(x => x.ReportTypeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Company)
                .WithMany(x => x.Reports)
                .HasForeignKey(x => x.CompanyId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(new Report()
            {
                Id=1,
                Name="Rapor A",
                CompanyId=1,
                ReportTypeId=1
            });

            builder.HasData(new Report()
            {
                Id = 2,
                Name = "Rapor B",
                CompanyId = 2,
                ReportTypeId = 2
            });
        }
    }
}
