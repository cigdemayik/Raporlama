﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Raporlama.DataAccess.Concrete.EFramework.Context;

namespace Raporlama.DataAccess.Migrations
{
    [DbContext(typeof(RaporlamaContext))]
    [Migration("20211022150635_last")]
    partial class last
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Raporlama.Entities.Concrete.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.HasKey("Id");

                    b.ToTable("Company");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "A Firması"
                        },
                        new
                        {
                            Id = 2,
                            Name = "B Firması"
                        });
                });

            modelBuilder.Entity("Raporlama.Entities.Concrete.Report", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<int>("ReportTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("ReportTypeId");

                    b.ToTable("Report");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CompanyId = 1,
                            Name = "Rapor A",
                            ReportTypeId = 1
                        },
                        new
                        {
                            Id = 2,
                            CompanyId = 2,
                            Name = "Rapor B",
                            ReportTypeId = 2
                        });
                });

            modelBuilder.Entity("Raporlama.Entities.Concrete.ReportType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.HasKey("Id");

                    b.ToTable("ReportType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Finans"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Muhasebe"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Satın Alma"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Satış"
                        });
                });

            modelBuilder.Entity("Raporlama.Entities.Concrete.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CompanyId = 1,
                            Name = "admin",
                            Password = "123",
                            UserName = "admin"
                        },
                        new
                        {
                            Id = 2,
                            CompanyId = 2,
                            Name = "user",
                            Password = "1234",
                            UserName = "user"
                        });
                });

            modelBuilder.Entity("Raporlama.Entities.Concrete.Report", b =>
                {
                    b.HasOne("Raporlama.Entities.Concrete.Company", "Company")
                        .WithMany("Reports")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Raporlama.Entities.Concrete.ReportType", "ReportType")
                        .WithMany("Reports")
                        .HasForeignKey("ReportTypeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("ReportType");
                });

            modelBuilder.Entity("Raporlama.Entities.Concrete.User", b =>
                {
                    b.HasOne("Raporlama.Entities.Concrete.Company", "Company")
                        .WithMany("Users")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Raporlama.Entities.Concrete.Company", b =>
                {
                    b.Navigation("Reports");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Raporlama.Entities.Concrete.ReportType", b =>
                {
                    b.Navigation("Reports");
                });
#pragma warning restore 612, 618
        }
    }
}
