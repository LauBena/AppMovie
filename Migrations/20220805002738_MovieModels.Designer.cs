﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppMovie.Migrations
{
    [DbContext(typeof(AppMovieContext))]
    [Migration("20220805002738_MovieModels")]
    partial class MovieModels
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AppMovie.Models.Country", b =>
                {
                    b.Property<int>("CountryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CountryID"), 1L, 1);

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CountryID");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("AppMovie.Models.Gender", b =>
                {
                    b.Property<int>("GenderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenderID"), 1L, 1);

                    b.Property<string>("GenderName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("GenderID");

                    b.ToTable("Gender");
                });

            modelBuilder.Entity("AppMovie.Models.Location", b =>
                {
                    b.Property<int>("LocationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LocationID"), 1L, 1);

                    b.Property<int>("CountryID")
                        .HasColumnType("int");

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("LocationID");

                    b.HasIndex("CountryID");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("AppMovie.Models.Movie", b =>
                {
                    b.Property<int>("MovieID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovieID"), 1L, 1);

                    b.Property<bool>("EstaAlquilada")
                        .HasColumnType("bit");

                    b.Property<int>("GenderID")
                        .HasColumnType("int");

                    b.Property<DateTime>("MovieData")
                        .HasColumnType("datetime2");

                    b.Property<string>("MovieDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ProducerID")
                        .HasColumnType("int");

                    b.Property<int>("SectionID")
                        .HasColumnType("int");

                    b.HasKey("MovieID");

                    b.HasIndex("GenderID");

                    b.HasIndex("ProducerID");

                    b.HasIndex("SectionID");

                    b.ToTable("Movie");
                });

            modelBuilder.Entity("AppMovie.Models.Partner", b =>
                {
                    b.Property<int>("PartnerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PartnerID"), 1L, 1);

                    b.Property<int>("LocationID")
                        .HasColumnType("int");

                    b.Property<DateTime>("PartnerBirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PartnerDirection")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PartnerName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("PartnerPhone")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("PartnerID");

                    b.HasIndex("LocationID");

                    b.ToTable("Partner");
                });

            modelBuilder.Entity("AppMovie.Models.Producer", b =>
                {
                    b.Property<int>("ProducerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProducerID"), 1L, 1);

                    b.Property<string>("ProducerName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ProducerID");

                    b.ToTable("Producer");
                });

            modelBuilder.Entity("AppMovie.Models.Rental", b =>
                {
                    b.Property<int>("RentalID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RentalID"), 1L, 1);

                    b.Property<int>("PartnerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("RentalDate")
                        .HasColumnType("datetime2");

                    b.HasKey("RentalID");

                    b.HasIndex("PartnerID");

                    b.ToTable("Rental");
                });

            modelBuilder.Entity("AppMovie.Models.RentalDetail", b =>
                {
                    b.Property<int>("RentalDetailID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RentalDetailID"), 1L, 1);

                    b.Property<int>("MovieID")
                        .HasColumnType("int");

                    b.Property<string>("MovieName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RentalID")
                        .HasColumnType("int");

                    b.HasKey("RentalDetailID");

                    b.HasIndex("MovieID");

                    b.HasIndex("RentalID");

                    b.ToTable("RentalDetail");
                });

            modelBuilder.Entity("AppMovie.Models.RentalDetailTemp", b =>
                {
                    b.Property<int>("RentalDetailTempID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RentalDetailTempID"), 1L, 1);

                    b.Property<int>("MovieID")
                        .HasColumnType("int");

                    b.Property<string>("MovieName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RentalDetailTempID");

                    b.ToTable("RentalDetailTemp");
                });

            modelBuilder.Entity("AppMovie.Models.Section", b =>
                {
                    b.Property<int>("SectionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SectionID"), 1L, 1);

                    b.Property<string>("SectionName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("SectionID");

                    b.ToTable("Section");
                });

            modelBuilder.Entity("AppMovie.Models.Location", b =>
                {
                    b.HasOne("AppMovie.Models.Country", "Countries")
                        .WithMany("Locations")
                        .HasForeignKey("CountryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Countries");
                });

            modelBuilder.Entity("AppMovie.Models.Movie", b =>
                {
                    b.HasOne("AppMovie.Models.Gender", "Gender")
                        .WithMany("Movies")
                        .HasForeignKey("GenderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppMovie.Models.Producer", "Producer")
                        .WithMany("Movies")
                        .HasForeignKey("ProducerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppMovie.Models.Section", "Section")
                        .WithMany("Movies")
                        .HasForeignKey("SectionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gender");

                    b.Navigation("Producer");

                    b.Navigation("Section");
                });

            modelBuilder.Entity("AppMovie.Models.Partner", b =>
                {
                    b.HasOne("AppMovie.Models.Location", "Locations")
                        .WithMany("Partners")
                        .HasForeignKey("LocationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Locations");
                });

            modelBuilder.Entity("AppMovie.Models.Rental", b =>
                {
                    b.HasOne("AppMovie.Models.Partner", "Partner")
                        .WithMany("Rentals")
                        .HasForeignKey("PartnerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Partner");
                });

            modelBuilder.Entity("AppMovie.Models.RentalDetail", b =>
                {
                    b.HasOne("AppMovie.Models.Movie", "Movie")
                        .WithMany("RentalDetails")
                        .HasForeignKey("MovieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppMovie.Models.Rental", "Rental")
                        .WithMany("RentalDetails")
                        .HasForeignKey("RentalID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("Rental");
                });

            modelBuilder.Entity("AppMovie.Models.Country", b =>
                {
                    b.Navigation("Locations");
                });

            modelBuilder.Entity("AppMovie.Models.Gender", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("AppMovie.Models.Location", b =>
                {
                    b.Navigation("Partners");
                });

            modelBuilder.Entity("AppMovie.Models.Movie", b =>
                {
                    b.Navigation("RentalDetails");
                });

            modelBuilder.Entity("AppMovie.Models.Partner", b =>
                {
                    b.Navigation("Rentals");
                });

            modelBuilder.Entity("AppMovie.Models.Producer", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("AppMovie.Models.Rental", b =>
                {
                    b.Navigation("RentalDetails");
                });

            modelBuilder.Entity("AppMovie.Models.Section", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
