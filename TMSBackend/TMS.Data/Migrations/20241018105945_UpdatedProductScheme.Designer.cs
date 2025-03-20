﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TMS.Data.Context;

#nullable disable

namespace TMS.Data.Migrations
{
    [DbContext(typeof(TMSContext))]
    [Migration("20241018105945_UpdatedProductScheme")]
    partial class UpdatedProductScheme
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TMS.Data.Models.ProductionRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ActionTimestamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("MachineNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PerformedById")
                        .HasColumnType("int");

                    b.Property<DateTime>("ProductionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProductionShift")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("TyreCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PerformedById");

                    b.ToTable("ProductionRecords");
                });

            modelBuilder.Entity("TMS.Data.Models.TyreProduction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("MachineNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OperatorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ProductionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductionShift")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("TyreCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OperatorId");

                    b.ToTable("TyreProductions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MachineNumber = "M001",
                            OperatorId = 1,
                            ProductionDate = new DateTime(2024, 10, 18, 12, 59, 45, 199, DateTimeKind.Local).AddTicks(8786),
                            ProductionShift = 0,
                            Quantity = 100,
                            TyreCode = "T123"
                        },
                        new
                        {
                            Id = 2,
                            MachineNumber = "M002",
                            OperatorId = 1,
                            ProductionDate = new DateTime(2024, 10, 18, 12, 59, 45, 199, DateTimeKind.Local).AddTicks(8927),
                            ProductionShift = 2,
                            Quantity = 150,
                            TyreCode = "T124"
                        });
                });

            modelBuilder.Entity("TMS.Data.Models.TyreSales", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfSale")
                        .HasColumnType("datetime2");

                    b.Property<string>("DestinationMarket")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PurchasingCompany")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuantitySold")
                        .HasColumnType("int");

                    b.Property<int>("ReferenceProductionId")
                        .HasColumnType("int");

                    b.Property<string>("TyreName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnitOfMeasure")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ReferenceProductionId");

                    b.ToTable("TyreSales");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateOfSale = new DateTime(2024, 10, 18, 12, 59, 45, 199, DateTimeKind.Local).AddTicks(9036),
                            DestinationMarket = "Local",
                            Price = 100.00m,
                            PurchasingCompany = "ABC Ltd.",
                            QuantitySold = 50,
                            ReferenceProductionId = 1,
                            TyreName = "T123",
                            UnitOfMeasure = "pieces"
                        },
                        new
                        {
                            Id = 2,
                            DateOfSale = new DateTime(2024, 10, 18, 12, 59, 45, 199, DateTimeKind.Local).AddTicks(9047),
                            DestinationMarket = "International",
                            Price = 120.00m,
                            PurchasingCompany = "XYZ Corp.",
                            QuantitySold = 30,
                            ReferenceProductionId = 2,
                            TyreName = "T124",
                            UnitOfMeasure = "pieces"
                        });
                });

            modelBuilder.Entity("TMS.Data.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserRole")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = "$2a$11$rirLS7EPlEDj.AM4361TPebw6Wi8zxbNk7AL4ZpFXkklad66yspXy",
                            UserRole = 0,
                            Username = "operator1"
                        },
                        new
                        {
                            Id = 2,
                            Password = "$2a$11$0khjLVIxr0Galw5vCqrtweQwuzwTBIQmKyRW1I4oInlXVKJos7CV.",
                            UserRole = 1,
                            Username = "supervisor1"
                        },
                        new
                        {
                            Id = 3,
                            Password = "$2a$11$tV.HTZ.EcdigWtqWIJYHQuZ0upGxdJA9qkbcNCYJhmqDyRtonsDc2",
                            UserRole = 2,
                            Username = "leader1"
                        });
                });

            modelBuilder.Entity("TMS.Data.Models.ProductionRecord", b =>
                {
                    b.HasOne("TMS.Data.Models.User", "PerformedBy")
                        .WithMany()
                        .HasForeignKey("PerformedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PerformedBy");
                });

            modelBuilder.Entity("TMS.Data.Models.TyreProduction", b =>
                {
                    b.HasOne("TMS.Data.Models.User", "Operator")
                        .WithMany("TyreProductions")
                        .HasForeignKey("OperatorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Operator");
                });

            modelBuilder.Entity("TMS.Data.Models.TyreSales", b =>
                {
                    b.HasOne("TMS.Data.Models.TyreProduction", "ReferenceProduction")
                        .WithMany("TyreSales")
                        .HasForeignKey("ReferenceProductionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ReferenceProduction");
                });

            modelBuilder.Entity("TMS.Data.Models.TyreProduction", b =>
                {
                    b.Navigation("TyreSales");
                });

            modelBuilder.Entity("TMS.Data.Models.User", b =>
                {
                    b.Navigation("TyreProductions");
                });
#pragma warning restore 612, 618
        }
    }
}
