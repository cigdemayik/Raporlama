using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Raporlama.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raporlama.DataAccess.Concrete.EFramework.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(256);

            builder.Property(x => x.UserName).IsRequired();
            builder.Property(x => x.UserName).HasMaxLength(512);

            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.Password).HasMaxLength(512);

            builder.HasOne(x => x.Company)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.CompanyId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(new User()
            {
                Id = 1,
                Name="admin",
                UserName = "admin",
                Password = "123",
                CompanyId = 1
            });

            builder.HasData(new User()
            {
                Id = 2,
                Name = "user",
                UserName = "user",
                Password = "1234",
                CompanyId = 2
            });
        }
    }
}
