﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using video_rental;

namespace video_rental.Migrations
{
    [DbContext(typeof(video_rentalsContext))]
    [Migration("20170901180311_RentalRecordsModel_mig")]
    partial class RentalRecordsModel_mig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("video_rental.Models.CustomersModel", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CustomerEmail");

                    b.Property<string>("CustomerName");

                    b.Property<string>("CustomerPhoneNumber");

                    b.HasKey("CustomerID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("video_rental.Models.GenresModel", b =>
                {
                    b.Property<int>("GenreID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GenreName");

                    b.HasKey("GenreID");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("video_rental.Models.MoviesModel", b =>
                {
                    b.Property<int>("MovieID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Director");

                    b.Property<int>("GenresModelID");

                    b.Property<string>("MovieTitle");

                    b.Property<int>("YearReleased");

                    b.HasKey("MovieID");

                    b.HasIndex("GenresModelID");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("video_rental.Models.RentalRecordsModel", b =>
                {
                    b.Property<int>("RentalID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CustomerID");

                    b.Property<string>("CustomerName");

                    b.Property<DateTime>("DueDate");

                    b.Property<bool>("IsOverdue");

                    b.Property<int>("MovieID");

                    b.Property<string>("MovieTitle");

                    b.HasKey("RentalID");

                    b.ToTable("RentalRecords");
                });

            modelBuilder.Entity("video_rental.Models.MoviesModel", b =>
                {
                    b.HasOne("video_rental.Models.GenresModel", "GenresModel")
                        .WithMany()
                        .HasForeignKey("GenresModelID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
