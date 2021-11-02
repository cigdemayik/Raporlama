using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Raporlama.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raporlama.DataAccess.Concrete.EfCore.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Company");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(512);

            builder.HasData(new Company()
            {
                Id=1,
                Name="A Firması"
            });

            builder.HasData(new Company()
            {
                Id=2,
                Name="B Firması"
            });
        }
    }
}
