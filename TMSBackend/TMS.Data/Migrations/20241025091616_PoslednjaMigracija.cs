using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class PoslednjaMigracija : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TyreProductions",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProductionDate",
                value: new DateTime(2024, 10, 25, 11, 16, 15, 267, DateTimeKind.Local).AddTicks(366));

            migrationBuilder.UpdateData(
                table: "TyreProductions",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProductionDate",
                value: new DateTime(2024, 10, 25, 11, 16, 15, 267, DateTimeKind.Local).AddTicks(505));

            migrationBuilder.UpdateData(
                table: "TyreSales",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfSale",
                value: new DateTime(2024, 10, 25, 11, 16, 15, 267, DateTimeKind.Local).AddTicks(623));

            migrationBuilder.UpdateData(
                table: "TyreSales",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateOfSale",
                value: new DateTime(2024, 10, 25, 11, 16, 15, 267, DateTimeKind.Local).AddTicks(637));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$4qYJIPcRXEniahQgvbqQ4uRjXIO4KKfkYUi3yn7D/aMCktQwxfk4m");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$7NulZNeFtocpkZwfk63jIePwup6es75OQ26rQAIEzu52KfqvZTy3K");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$PCOD8an6zskXnjaebHpf6ecQt/ECzbCmM2jF0fPXucNZW/LQZeoam");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TyreProductions",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProductionDate",
                value: new DateTime(2024, 10, 24, 12, 13, 29, 312, DateTimeKind.Local).AddTicks(5794));

            migrationBuilder.UpdateData(
                table: "TyreProductions",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProductionDate",
                value: new DateTime(2024, 10, 24, 12, 13, 29, 312, DateTimeKind.Local).AddTicks(5933));

            migrationBuilder.UpdateData(
                table: "TyreSales",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfSale",
                value: new DateTime(2024, 10, 24, 12, 13, 29, 312, DateTimeKind.Local).AddTicks(6043));

            migrationBuilder.UpdateData(
                table: "TyreSales",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateOfSale",
                value: new DateTime(2024, 10, 24, 12, 13, 29, 312, DateTimeKind.Local).AddTicks(6055));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$v8spPnSLcr/ZOLpx3UhiperUGwCix2CcjMtNPW89rspE4ofhK0mMu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$G6ji9zB4q5q0CerqNq0RtOrc4YZj.J0hQp/obom/zLSmPXCCSnVlO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$Z0TXVdBIvYLQv/qRtXomWegwhOesl5bdCSQbg2O54au1HX9tqJTzq");
        }
    }
}
