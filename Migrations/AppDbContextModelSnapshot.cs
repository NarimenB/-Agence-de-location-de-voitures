
using System;
using Locatic.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Locatic.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CarId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CountryOfOrigin")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryOfOrigin = "France",
                            Name = "Renault"
                        },
                        new
                        {
                            Id = 2,
                            CountryOfOrigin = "France",
                            Name = "Peugeot"
                        },
                        new
                        {
                            Id = 3,
                            CountryOfOrigin = "Germany",
                            Name = "BMW"
                        });
                });

            modelBuilder.Entity("Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CarModelId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("DailyRate")
                        .HasColumnType("TEXT");

                    b.Property<string>("FuelType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("NumberOfSeats")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CarModelId");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CarModelId = 1,
                            DailyRate = 45m,
                            FuelType = "Petrol",
                            LicensePlate = "AB-123-CD",
                            NumberOfSeats = 5,
                            Year = 2021
                        },
                        new
                        {
                            Id = 2,
                            CarModelId = 2,
                            DailyRate = 50m,
                            FuelType = "Diesel",
                            LicensePlate = "EF-456-GH",
                            NumberOfSeats = 5,
                            Year = 2022
                        },
                        new
                        {
                            Id = 3,
                            CarModelId = 3,
                            DailyRate = 90m,
                            FuelType = "Electric",
                            LicensePlate = "IJ-789-KL",
                            NumberOfSeats = 5,
                            Year = 2023
                        });
                });

            modelBuilder.Entity("CarModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BrandId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("CarModels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandId = 1,
                            Name = "Clio"
                        },
                        new
                        {
                            Id = 2,
                            BrandId = 2,
                            Name = "208"
                        },
                        new
                        {
                            Id = 3,
                            BrandId = 3,
                            Name = "Series 3"
                        });
                });

            modelBuilder.Entity("Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "jean@dupont.fr",
                            FirstName = "Jean",
                            LastName = "Dupont",
                            Phone = "0601020304"
                        },
                        new
                        {
                            Id = 2,
                            Email = "sophie@martin.fr",
                            FirstName = "Sophie",
                            LastName = "Martin"
                        });
                });

            modelBuilder.Entity("Booking", b =>
                {
                    b.HasOne("Car", "Car")
                        .WithMany("Bookings")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Customer", "Customer")
                        .WithMany("Bookings")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Car", b =>
                {
                    b.HasOne("CarModel", "CarModel")
                        .WithMany("Cars")
                        .HasForeignKey("CarModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarModel");
                });

            modelBuilder.Entity("CarModel", b =>
                {
                    b.HasOne("Brand", "Brand")
                        .WithMany("CarModels")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("Brand", b =>
                {
                    b.Navigation("CarModels");
                });

            modelBuilder.Entity("Car", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("CarModel", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("Customer", b =>
                {
                    b.Navigation("Bookings");
                });

        }
    }
}
