﻿// <auto-generated />
using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Domain.Migrations
{
    [DbContext(typeof(PurchaseContext))]
    partial class PurchaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entity.ItemInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Items", (string)null);
                });

            modelBuilder.Entity("Domain.Entity.PaymentInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("PurchasingDocumentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PurchasingDocumentId");

                    b.ToTable("Payments", (string)null);
                });

            modelBuilder.Entity("Domain.Entity.PurchasingDocument", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("ConfirmedByCustomer")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeliveredAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("OperationStatus")
                        .HasColumnType("int");

                    b.Property<Guid?>("OrderLetterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PaymentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("RatingDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PurchasingDocuments", (string)null);
                });

            modelBuilder.Entity("Domain.Entity.PurchasingDocumentItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("ItemInfoId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int?>("PurchasingDocumentId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ItemInfoId");

                    b.HasIndex("PurchasingDocumentId");

                    b.ToTable("PurchasingDocumentItems", (string)null);
                });

            modelBuilder.Entity("Domain.Entity.WarehouseState", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemId"), 1L, 1);

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ItemId");

                    b.ToTable("WarehouseState", (string)null);
                });

            modelBuilder.Entity("Domain.Entity.PaymentInfo", b =>
                {
                    b.HasOne("Domain.Entity.PurchasingDocument", "PurchasingDocument")
                        .WithMany("Payments")
                        .HasForeignKey("PurchasingDocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PurchasingDocument");
                });

            modelBuilder.Entity("Domain.Entity.PurchasingDocumentItem", b =>
                {
                    b.HasOne("Domain.Entity.ItemInfo", "ItemInfo")
                        .WithMany("PurchasePositions")
                        .HasForeignKey("ItemInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entity.PurchasingDocument", null)
                        .WithMany("OrderItems")
                        .HasForeignKey("PurchasingDocumentId");

                    b.Navigation("ItemInfo");
                });

            modelBuilder.Entity("Domain.Entity.ItemInfo", b =>
                {
                    b.Navigation("PurchasePositions");
                });

            modelBuilder.Entity("Domain.Entity.PurchasingDocument", b =>
                {
                    b.Navigation("OrderItems");

                    b.Navigation("Payments");
                });
#pragma warning restore 612, 618
        }
    }
}
