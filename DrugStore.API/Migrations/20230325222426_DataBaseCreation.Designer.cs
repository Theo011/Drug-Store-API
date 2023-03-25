﻿// <auto-generated />
using System;
using DrugStore.API.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DrugStore.API.Migrations
{
    [DbContext(typeof(DrugStoreDbContext))]
    [Migration("20230325222426_DataBaseCreation")]
    partial class DataBaseCreation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DrugStore.API.Entities.Categories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Placeholder Category Description",
                            Name = "Placeholder Category Name"
                        });
                });

            modelBuilder.Entity("DrugStore.API.Entities.Customers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("InsurancesId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("SSN")
                        .HasColumnType("int");

                    b.Property<int>("ZipCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InsurancesId");

                    b.HasIndex("Name", "SSN");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Placeholder Customer Address",
                            Description = "Placeholder Customer Description",
                            Email = "PlaceholderCustomer@Email.com",
                            InsurancesId = 1,
                            Name = "Placeholder Customer Name",
                            Phone = "0000000000",
                            SSN = 0,
                            ZipCode = 0
                        });
                });

            modelBuilder.Entity("DrugStore.API.Entities.Insurances", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("Insurances");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Placeholder Insurance Description",
                            Name = "Placeholder Insurance Name"
                        });
                });

            modelBuilder.Entity("DrugStore.API.Entities.Invoices", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("SuppliersId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Date");

                    b.HasIndex("SuppliersId");

                    b.ToTable("Invoices");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = new DateTime(2023, 3, 26, 0, 24, 26, 167, DateTimeKind.Local).AddTicks(716),
                            Description = "Placeholder Invoices Description",
                            SuppliersId = 1
                        });
                });

            modelBuilder.Entity("DrugStore.API.Entities.Products", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoriesId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("PurchasePrice")
                        .HasColumnType("money");

                    b.Property<decimal>("SalePrice")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("CategoriesId");

                    b.HasIndex("Name");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoriesId = 1,
                            Description = "Placeholder Product Description",
                            Name = "Placeholder Product Name",
                            PurchasePrice = 10m,
                            SalePrice = 20m
                        });
                });

            modelBuilder.Entity("DrugStore.API.Entities.ProductsInvoice", b =>
                {
                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("InvoicesId")
                        .HasColumnType("int");

                    b.Property<int>("ProductsId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasIndex("InvoicesId");

                    b.HasIndex("ProductsId");

                    b.HasIndex("Quantity");

                    b.ToTable("ProductsInvoice");
                });

            modelBuilder.Entity("DrugStore.API.Entities.ProductsReceipt", b =>
                {
                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("ProductsId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("ReceiptsId")
                        .HasColumnType("int");

                    b.HasIndex("ProductsId");

                    b.HasIndex("Quantity");

                    b.HasIndex("ReceiptsId");

                    b.ToTable("ProductsReceipt");
                });

            modelBuilder.Entity("DrugStore.API.Entities.Receipts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CustomersId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("CustomersId");

                    b.HasIndex("Date");

                    b.ToTable("Receipts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomersId = 1,
                            Date = new DateTime(2023, 3, 26, 0, 24, 26, 167, DateTimeKind.Local).AddTicks(776),
                            Description = "Placeholder Invoices Description"
                        });
                });

            modelBuilder.Entity("DrugStore.API.Entities.Suppliers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("EIN")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("ZipCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Name", "EIN");

                    b.ToTable("Suppliers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Placeholder Supplier Address",
                            Description = "Placeholder Supplier Description",
                            EIN = 0,
                            Email = "PlaceholderSupplier@Email.com",
                            Name = "Placeholder Supplier Name",
                            Phone = "0000000000",
                            ZipCode = 0
                        });
                });

            modelBuilder.Entity("DrugStore.API.Entities.Customers", b =>
                {
                    b.HasOne("DrugStore.API.Entities.Insurances", "Insurances")
                        .WithMany()
                        .HasForeignKey("InsurancesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Insurances");
                });

            modelBuilder.Entity("DrugStore.API.Entities.Invoices", b =>
                {
                    b.HasOne("DrugStore.API.Entities.Suppliers", "Suppliers")
                        .WithMany()
                        .HasForeignKey("SuppliersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Suppliers");
                });

            modelBuilder.Entity("DrugStore.API.Entities.Products", b =>
                {
                    b.HasOne("DrugStore.API.Entities.Categories", "Categories")
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categories");
                });

            modelBuilder.Entity("DrugStore.API.Entities.ProductsInvoice", b =>
                {
                    b.HasOne("DrugStore.API.Entities.Invoices", "Invoices")
                        .WithMany()
                        .HasForeignKey("InvoicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DrugStore.API.Entities.Products", "Products")
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invoices");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("DrugStore.API.Entities.ProductsReceipt", b =>
                {
                    b.HasOne("DrugStore.API.Entities.Products", "Products")
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DrugStore.API.Entities.Invoices", "Receipts")
                        .WithMany()
                        .HasForeignKey("ReceiptsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Products");

                    b.Navigation("Receipts");
                });

            modelBuilder.Entity("DrugStore.API.Entities.Receipts", b =>
                {
                    b.HasOne("DrugStore.API.Entities.Customers", "Customers")
                        .WithMany()
                        .HasForeignKey("CustomersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customers");
                });
#pragma warning restore 612, 618
        }
    }
}