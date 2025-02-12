﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;


#nullable disable

namespace PO.PersistanceLayer.EF.Migrations
{
    [DbContext(typeof(PoDbContext))]
    [Migration("20241031122736_3rd")]
    partial class _3rd
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PO.DomainLayer.Aggregates.PO.PurchaseOrder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PurchaseQuoteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PurchaseRequestId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("PurchaseOrders");
                });

            modelBuilder.Entity("PO.DomainLayer.Aggregates.PQ.PurchaseQuote", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PurchaseRequestId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("PurchaseQuotes");
                });

            modelBuilder.Entity("PO.DomainLayer.Aggregates.PR.PurchaseRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PurchaseRequests");
                });

            modelBuilder.Entity("PO.DomainLayer.Aggregates.PO.PurchaseOrder", b =>
                {
                    b.OwnsOne("PO.DomainLayer.Aggregates.PO.PurchaseOrderStatus", "Status", b1 =>
                        {
                            b1.Property<Guid>("PurchaseOrderId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Text")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Status_Text");

                            b1.Property<int>("Value")
                                .HasColumnType("int")
                                .HasColumnName("Status_Value");

                            b1.HasKey("PurchaseOrderId");

                            b1.ToTable("PurchaseOrders");

                            b1.WithOwner()
                                .HasForeignKey("PurchaseOrderId");
                        });

                    b.Navigation("Status")
                        .IsRequired();
                });

            modelBuilder.Entity("PO.DomainLayer.Aggregates.PQ.PurchaseQuote", b =>
                {
                    b.OwnsOne("PO.DomainLayer.Aggregates.Shared.Money", "Cost", b1 =>
                        {
                            b1.Property<Guid>("PurchaseQuoteId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("Cost_Currency");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("PurchaseQuoteId");

                            b1.ToTable("PurchaseQuotes", t =>
                                {
                                    t.Property("Currency")
                                        .HasColumnName("Cost_Currency1");
                                });

                            b1.WithOwner()
                                .HasForeignKey("PurchaseQuoteId");
                        });

                    b.OwnsOne("PO.DomainLayer.Aggregates.PQ.PurchaseQuoteStatus", "Status", b1 =>
                        {
                            b1.Property<Guid>("PurchaseQuoteId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Text")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Status_Text");

                            b1.Property<int>("Value")
                                .HasColumnType("int")
                                .HasColumnName("Status_Value");

                            b1.HasKey("PurchaseQuoteId");

                            b1.ToTable("PurchaseQuotes");

                            b1.WithOwner()
                                .HasForeignKey("PurchaseQuoteId");
                        });

                    b.Navigation("Cost")
                        .IsRequired();

                    b.Navigation("Status")
                        .IsRequired();
                });

            modelBuilder.Entity("PO.DomainLayer.Aggregates.PR.PurchaseRequest", b =>
                {
                    b.OwnsOne("PO.DomainLayer.Aggregates.Shared.Money", "Budget", b1 =>
                        {
                            b1.Property<Guid>("PurchaseRequestId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("Budget_Amount");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Budget_Currency");

                            b1.HasKey("PurchaseRequestId");

                            b1.ToTable("PurchaseRequests");

                            b1.WithOwner()
                                .HasForeignKey("PurchaseRequestId");
                        });

                    b.OwnsOne("PO.DomainLayer.Aggregates.PR.PurchaseRequestStatus", "Status", b1 =>
                        {
                            b1.Property<Guid>("PurchaseRequestId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Text")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Status_Text");

                            b1.Property<int>("Value")
                                .HasColumnType("int")
                                .HasColumnName("Status_Value");

                            b1.HasKey("PurchaseRequestId");

                            b1.ToTable("PurchaseRequests");

                            b1.WithOwner()
                                .HasForeignKey("PurchaseRequestId");
                        });

                    b.Navigation("Budget")
                        .IsRequired();

                    b.Navigation("Status")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
