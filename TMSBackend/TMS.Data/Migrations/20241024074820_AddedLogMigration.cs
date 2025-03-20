using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedLogMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductionByDay",
                columns: table => new
                {
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalProduction = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ProductionByMachine",
                columns: table => new
                {
                    MachineNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalProduction = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ProductionByOperator",
                columns: table => new
                {
                    OperatorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalProduction = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ProductionByShift",
                columns: table => new
                {
                    ProductionShift = table.Column<int>(type: "int", nullable: false),
                    TotalProduction = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "StockBalance",
                columns: table => new
                {
                    TyreCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalStock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.UpdateData(
                table: "TyreProductions",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProductionDate",
                value: new DateTime(2024, 10, 24, 9, 48, 19, 769, DateTimeKind.Local).AddTicks(9493));

            migrationBuilder.UpdateData(
                table: "TyreProductions",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProductionDate",
                value: new DateTime(2024, 10, 24, 9, 48, 19, 769, DateTimeKind.Local).AddTicks(9637));

            migrationBuilder.UpdateData(
                table: "TyreSales",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfSale",
                value: new DateTime(2024, 10, 24, 9, 48, 19, 769, DateTimeKind.Local).AddTicks(9747));

            migrationBuilder.UpdateData(
                table: "TyreSales",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateOfSale",
                value: new DateTime(2024, 10, 24, 9, 48, 19, 769, DateTimeKind.Local).AddTicks(9759));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$AimxjZ6anlQNj/OYL9HLreWIW4YRyCfDVMMAxwp41XcbxWdhQelzy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$76rg4v2AF1q0RWsgoTGVwOMUdLzg0QP/fcTmEaDSoAvgpyeZdbMAO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$6jANQdiIYze5OS/zRZGE8.WO8xqnJv4zOZWrRESOsfy2/TrbhmknW");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductionByDay");

            migrationBuilder.DropTable(
                name: "ProductionByMachine");

            migrationBuilder.DropTable(
                name: "ProductionByOperator");

            migrationBuilder.DropTable(
                name: "ProductionByShift");

            migrationBuilder.DropTable(
                name: "StockBalance");

            migrationBuilder.UpdateData(
                table: "TyreProductions",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProductionDate",
                value: new DateTime(2024, 10, 18, 12, 59, 45, 199, DateTimeKind.Local).AddTicks(8786));

            migrationBuilder.UpdateData(
                table: "TyreProductions",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProductionDate",
                value: new DateTime(2024, 10, 18, 12, 59, 45, 199, DateTimeKind.Local).AddTicks(8927));

            migrationBuilder.UpdateData(
                table: "TyreSales",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfSale",
                value: new DateTime(2024, 10, 18, 12, 59, 45, 199, DateTimeKind.Local).AddTicks(9036));

            migrationBuilder.UpdateData(
                table: "TyreSales",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateOfSale",
                value: new DateTime(2024, 10, 18, 12, 59, 45, 199, DateTimeKind.Local).AddTicks(9047));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$rirLS7EPlEDj.AM4361TPebw6Wi8zxbNk7AL4ZpFXkklad66yspXy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$0khjLVIxr0Galw5vCqrtweQwuzwTBIQmKyRW1I4oInlXVKJos7CV.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$tV.HTZ.EcdigWtqWIJYHQuZ0upGxdJA9qkbcNCYJhmqDyRtonsDc2");
        }
    }
}
