﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StockAPI.Data;

#nullable disable

namespace StockAPI.Migrations
{
    [DbContext(typeof(StockAPIDbContext))]
    partial class StockAPIDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PortfolioAPI.Models.Stock", b =>
                {
                    b.Property<int>("Stockid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Stockid"), 1L, 1);

                    b.Property<int>("PortfolioId")
                        .HasColumnType("int");

                    b.Property<string>("StockName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("StockPrice")
                        .HasColumnType("float");

                    b.Property<int>("StockQuantity")
                        .HasColumnType("int");

                    b.HasKey("Stockid");

                    b.ToTable("Stocks");
                });
#pragma warning restore 612, 618
        }
    }
}
