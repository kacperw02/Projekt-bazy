﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projekt_bazy.Data;

#nullable disable

namespace Projekt_bazy.Migrations
{
    [DbContext(typeof(MagazynDbContext))]
    [Migration("20250114183750_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Projekt_bazy.Models.Magazyn", b =>
                {
                    b.Property<int>("IdMagazynu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMagazynu"));

                    b.Property<string>("Funkcjonalnosc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lokalizacja")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdMagazynu");

                    b.ToTable("Magazyny");
                });

            modelBuilder.Entity("Projekt_bazy.Models.Personel", b =>
                {
                    b.Property<int>("IdPersonelu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPersonelu"));

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MagazynIdMagazynu")
                        .HasColumnType("int");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PrzynaleznoscDoMagazynu")
                        .HasColumnType("int");

                    b.Property<string>("Stopien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPersonelu");

                    b.HasIndex("MagazynIdMagazynu");

                    b.ToTable("Personel");
                });

            modelBuilder.Entity("Projekt_bazy.Models.Sprzet", b =>
                {
                    b.Property<int>("IdSprzetu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSprzetu"));

                    b.Property<DateTime>("DataWstawienia")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MagazynId")
                        .HasColumnType("int");

                    b.Property<string>("NazwaSprzetu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdSprzetu");

                    b.HasIndex("MagazynId");

                    b.ToTable("Sprzety");
                });

            modelBuilder.Entity("Projekt_bazy.Models.Zamowienie", b =>
                {
                    b.Property<int>("IdZamowienia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdZamowienia"));

                    b.Property<DateTime>("DataZamowienia")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdZamawiajacego")
                        .HasColumnType("int");

                    b.Property<string>("NazwaSprzetu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ZamawiajacyIdPersonelu")
                        .HasColumnType("int");

                    b.HasKey("IdZamowienia");

                    b.HasIndex("ZamawiajacyIdPersonelu");

                    b.ToTable("Zamowienia");
                });

            modelBuilder.Entity("Projekt_bazy.Models.Personel", b =>
                {
                    b.HasOne("Projekt_bazy.Models.Magazyn", "Magazyn")
                        .WithMany("Personel")
                        .HasForeignKey("MagazynIdMagazynu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Magazyn");
                });

            modelBuilder.Entity("Projekt_bazy.Models.Sprzet", b =>
                {
                    b.HasOne("Projekt_bazy.Models.Magazyn", "Magazyn")
                        .WithMany("Sprzety")
                        .HasForeignKey("MagazynId");

                    b.Navigation("Magazyn");
                });

            modelBuilder.Entity("Projekt_bazy.Models.Zamowienie", b =>
                {
                    b.HasOne("Projekt_bazy.Models.Personel", "Zamawiajacy")
                        .WithMany()
                        .HasForeignKey("ZamawiajacyIdPersonelu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Zamawiajacy");
                });

            modelBuilder.Entity("Projekt_bazy.Models.Magazyn", b =>
                {
                    b.Navigation("Personel");

                    b.Navigation("Sprzety");
                });
#pragma warning restore 612, 618
        }
    }
}
