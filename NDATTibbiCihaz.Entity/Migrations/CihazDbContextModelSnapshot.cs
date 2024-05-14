﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NDATTibbiCihaz.Entity.Config;

#nullable disable

namespace NDATTibbiCihaz.Entity.Migrations
{
    [DbContext(typeof(CihazDbContext))]
    partial class CihazDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NDATTibbiCihaz.Common.Cikti", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CiktiTarihi")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("DonulenDerece")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("HastaTCKimlikNo")
                        .HasColumnType("bigint");

                    b.Property<string>("Path3D")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RaporId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HastaTCKimlikNo");

                    b.ToTable("Ciktilar");
                });

            modelBuilder.Entity("NDATTibbiCihaz.Common.Doktor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AdSoyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Parola")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Doktorlar");
                });

            modelBuilder.Entity("NDATTibbiCihaz.Common.Gorsel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Aci")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("CiktiId")
                        .HasColumnType("int");

                    b.Property<string>("PathGorsel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CiktiId");

                    b.ToTable("Gorseller");
                });

            modelBuilder.Entity("NDATTibbiCihaz.Common.Hasta", b =>
                {
                    b.Property<long>("TCKimlikNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("TCKimlikNo"));

                    b.Property<string>("AdSoyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Cinsiyet")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DogumTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int>("DoktorId")
                        .HasColumnType("int");

                    b.Property<bool>("MedeniDurum")
                        .HasColumnType("bit");

                    b.HasKey("TCKimlikNo");

                    b.ToTable("Hastalar");
                });

            modelBuilder.Entity("NDATTibbiCihaz.Common.Makine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Calisiyor")
                        .HasColumnType("bit");

                    b.Property<bool>("KapakDurumu")
                        .HasColumnType("bit");

                    b.Property<bool>("Kullanilabilirlik")
                        .HasColumnType("bit");

                    b.Property<bool>("PlatformDonusDurumu")
                        .HasColumnType("bit");

                    b.Property<bool>("TaramaDurumu")
                        .HasColumnType("bit");

                    b.Property<bool>("XRayDurumu")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Makineler");
                });

            modelBuilder.Entity("NDATTibbiCihaz.Common.Rapor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CiktiId")
                        .HasColumnType("int");

                    b.Property<int>("DoktorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RaporTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("Yorum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Raporlar");
                });

            modelBuilder.Entity("NDATTibbiCihaz.Common.Cikti", b =>
                {
                    b.HasOne("NDATTibbiCihaz.Common.Hasta", null)
                        .WithMany("Ciktilar")
                        .HasForeignKey("HastaTCKimlikNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NDATTibbiCihaz.Common.Gorsel", b =>
                {
                    b.HasOne("NDATTibbiCihaz.Common.Cikti", null)
                        .WithMany("Gorseller")
                        .HasForeignKey("CiktiId");
                });

            modelBuilder.Entity("NDATTibbiCihaz.Common.Cikti", b =>
                {
                    b.Navigation("Gorseller");
                });

            modelBuilder.Entity("NDATTibbiCihaz.Common.Hasta", b =>
                {
                    b.Navigation("Ciktilar");
                });
#pragma warning restore 612, 618
        }
    }
}
