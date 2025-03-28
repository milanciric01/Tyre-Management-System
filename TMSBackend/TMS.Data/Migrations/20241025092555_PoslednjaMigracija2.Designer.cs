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
    [Migration("20241025092555_PoslednjaMigracija2")]
    partial class PoslednjaMigracija2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TMS.Data.DTO.ProductionByDayDTO", b =>
                {
                    b.Property<DateTime>("ProductionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TotalProduction")
                        .HasColumnType("int");

                    b.ToTable("ProductionByDay");
                });

            modelBuilder.Entity("TMS.Data.DTO.ProductionByMachineDTO", b =>
                {
                    b.Property<string>("MachineNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalProduction")
                        .HasColumnType("int");

                    b.ToTable("ProductionByMachine");
                });

            modelBuilder.Entity("TMS.Data.DTO.ProductionByOperatorDTO", b =>
                {
                    b.Property<string>("OperatorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalProduction")
                        .HasColumnType("int");

                    b.ToTable("ProductionByOperator");
                });

            modelBuilder.Entity("TMS.Data.DTO.ProductionByShiftDTO", b =>
                {
                    b.Property<int>("ProductionShift")
                        .HasColumnType("int");

                    b.Property<int>("TotalProduction")
                        .HasColumnType("int");

                    b.ToTable("ProductionByShift");
                });

            modelBuilder.Entity("TMS.Data.DTO.StockBalanceDTO", b =>
                {
                    b.Property<int>("TotalStock")
                        .HasColumnType("int");

                    b.Property<string>("TyreCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("StockBalance");
                });

            modelBuilder.Entity("TMS.Data.Models.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ActionDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Logs");
                });

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
                            ProductionDate = new DateTime(2024, 10, 25, 11, 25, 54, 795, DateTimeKind.Local).AddTicks(3106),
                            ProductionShift = 0,
                            Quantity = 100,
                            TyreCode = "T123"
                        },
                        new
                        {
                            Id = 2,
                            MachineNumber = "M002",
                            OperatorId = 1,
                            ProductionDate = new DateTime(2024, 10, 25, 11, 25, 54, 795, DateTimeKind.Local).AddTicks(3246),
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
                            DateOfSale = new DateTime(2024, 10, 25, 11, 25, 54, 795, DateTimeKind.Local).AddTicks(3373),
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
                            DateOfSale = new DateTime(2024, 10, 25, 11, 25, 54, 795, DateTimeKind.Local).AddTicks(3383),
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
                            Password = "$2a$11$jcLQ893jdIrtP6YskZ.bKuLe5QVK3nmKeEDpufYIsL1ZNDp3hf9wG",
                            UserRole = 0,
                            Username = "operator1"
                        },
                        new
                        {
                            Id = 2,
                            Password = "$2a$11$BLmxU4Tiz8C/DIXHE7aTXe5XZchm9YozLAO5l3UL7y7s/NBCiAUGm",
                            UserRole = 1,
                            Username = "supervisor1"
                        },
                        new
                        {
                            Id = 3,
                            Password = "$2a$11$RW5TObzItuFFB57Z4.9...KekD9VPfam51prOQXWl5ilS7SwGrTaG",
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
