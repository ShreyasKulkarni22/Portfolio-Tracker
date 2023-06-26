﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(FlightDetailsDBContext))]
    partial class FlightDetailsDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entities.Flight", b =>
                {
                    b.Property<int>("FlightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FlightId"), 1L, 1);

                    b.Property<DateTime>("FlightDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Flightdestination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Flightsource")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("StatusIsOperational")
                        .HasColumnType("bit");

                    b.HasKey("FlightId");

                    b.ToTable("flights");
                });
#pragma warning restore 612, 618
        }
    }
}
