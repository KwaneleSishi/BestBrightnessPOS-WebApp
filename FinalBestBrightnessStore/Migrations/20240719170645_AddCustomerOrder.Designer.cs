﻿// <auto-generated />
using System;
using FinalBestBrightnessStore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FinalBestBrightnessStore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240719170645_AddCustomerOrder")]
    partial class AddCustomerOrder
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("FinalBestBrightnessStore.Models.Admin", b =>
                {
                    b.Property<int>("adminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("adminId"));

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("dateOfbirth")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("surname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("adminId");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("FinalBestBrightnessStore.Models.Category", b =>
                {
                    b.Property<int>("catId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("catId"));

                    b.Property<string>("catName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("catId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("FinalBestBrightnessStore.Models.CustomerOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfOrder")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("SalePersonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CustomerOrders");
                });

            modelBuilder.Entity("FinalBestBrightnessStore.Models.Finance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("amount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("dateOfSale")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("salePersonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Finances");
                });

            modelBuilder.Entity("FinalBestBrightnessStore.Models.Product", b =>
                {
                    b.Property<int>("prodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("prodId"));

                    b.Property<string>("expDate")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("price")
                        .HasColumnType("double");

                    b.Property<string>("productName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("quantinty")
                        .HasColumnType("int");

                    b.HasKey("prodId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("FinalBestBrightnessStore.Models.Role", b =>
                {
                    b.Property<int>("roleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("roleId"));

                    b.Property<string>("roleName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("roleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("FinalBestBrightnessStore.Models.SalesPerson", b =>
                {
                    b.Property<int>("salePersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("salePersonId"));

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("dateOfbirth")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("surname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("salePersonId");

                    b.ToTable("SalesPersons");
                });

            modelBuilder.Entity("FinalBestBrightnessStore.Models.SalesTracking", b =>
                {
                    b.Property<int>("salesTrackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("salesTrackId"));

                    b.Property<DateTime>("dateOfSale")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("salePersonId")
                        .HasColumnType("int");

                    b.HasKey("salesTrackId");

                    b.ToTable("SaleTrack");
                });

            modelBuilder.Entity("FinalBestBrightnessStore.Models.SalesTrackingProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("prodId")
                        .HasColumnType("int");

                    b.Property<int>("salesTrackId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("salesTrackId");

                    b.ToTable("SalesTrackingProducts");
                });

            modelBuilder.Entity("FinalBestBrightnessStore.Models.StockMananger", b =>
                {
                    b.Property<int>("stockManId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("stockManId"));

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("dateOfbirth")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("surname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("stockManId");

                    b.ToTable("StockManangers");
                });

            modelBuilder.Entity("FinalBestBrightnessStore.Models.StockTracking", b =>
                {
                    b.Property<int>("stockTrackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("stockTrackId"));

                    b.Property<string>("dateOfstock")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("prodId")
                        .HasColumnType("int");

                    b.Property<int>("stockManId")
                        .HasColumnType("int");

                    b.HasKey("stockTrackId");

                    b.ToTable("StockTrack");
                });

            modelBuilder.Entity("FinalBestBrightnessStore.Models.SalesTrackingProduct", b =>
                {
                    b.HasOne("FinalBestBrightnessStore.Models.SalesTracking", "SalesTracking")
                        .WithMany("ProductsSold")
                        .HasForeignKey("salesTrackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SalesTracking");
                });

            modelBuilder.Entity("FinalBestBrightnessStore.Models.SalesTracking", b =>
                {
                    b.Navigation("ProductsSold");
                });
#pragma warning restore 612, 618
        }
    }
}
