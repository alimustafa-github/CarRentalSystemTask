﻿// <auto-generated />
using System;
using CarRental.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarRental.Infrastructure.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231129051315_AddCustomersTable")]
    partial class AddCustomersTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarRental.Core.Entities.Car", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<int>("Color")
                        .HasColumnType("int");

                    b.Property<decimal>("DailyFaire")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("EngineCapacity")
                        .HasMaxLength(25)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SerialNumber")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("WithDriver")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.HasIndex("SerialNumber")
                        .IsUnique();

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CarRental.Core.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("CarRental.Core.Entities.Driver", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("IsBusy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("CarRental.Core.Entities.RentedCar", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DriverId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CarId")
                        .IsUnique();

                    b.HasIndex("CustomerId");

                    b.HasIndex("DriverId");

                    b.ToTable("RentedCars");
                });

            modelBuilder.Entity("CarRental.Core.Entities.RentedCar", b =>
                {
                    b.HasOne("CarRental.Core.Entities.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarRental.Core.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarRental.Core.Entities.Driver", "Driver")
                        .WithMany()
                        .HasForeignKey("DriverId");

                    b.Navigation("Car");

                    b.Navigation("Customer");

                    b.Navigation("Driver");
                });
#pragma warning restore 612, 618
        }
    }
}
