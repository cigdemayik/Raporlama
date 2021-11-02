using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Raporlama.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raporlama.DataAccess.Concrete.EFramework.Configurations
{
    public class ReportTypeConfiguration : IEntityTypeConfiguration<ReportType>
    {
        public void Configure(EntityTypeBuilder<ReportType> builder)
        {
            builder.ToTable("ReportType");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(512);

            builder.HasData(new ReportType()
            {
                Id = 1,
                Name = "Finans"
            });

            builder.HasData(new ReportType()
            {
                Id = 2,
                Name = "Muhasebe"
            });

            builder.HasData(new ReportType()
            {
                Id = 3,
                Name = "Satın Alma"
            });

            builder.HasData(new ReportType()
            {
                Id = 4,
                Name = "Satış"
            });
        }
    }
}
