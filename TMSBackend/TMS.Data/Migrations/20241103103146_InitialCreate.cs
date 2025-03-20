using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TyreProductions",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProductionDate",
                value: new DateTime(2024, 11, 3, 11, 31, 45, 989, DateTimeKind.Local).AddTicks(506));

            migrationBuilder.UpdateData(
                table: "TyreProductions",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProductionDate",
                value: new DateTime(2024, 11, 3, 11, 31, 45, 989, DateTimeKind.Local).AddTicks(617));

            migrationBuilder.UpdateData(
                table: "TyreSales",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfSale",
                value: new DateTime(2024, 11, 3, 11, 31, 45, 989, DateTimeKind.Local).AddTicks(690));

            migrationBuilder.UpdateData(
                table: "TyreSales",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateOfSale",
                value: new DateTime(2024, 11, 3, 11, 31, 45, 989, DateTimeKind.Local).AddTicks(695));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$fXKWb.dlEgpIzDuEQ6nXj.MSgWRnpafgOxYjxbuNPI4qhYXYSQEvu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$h6HUYxo0Bagpa4GNU7ZRHer6XIn6uO0B8Sf.JyaUQfj7QgikVqdAq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$Jlqc/Q6eoyQ64H2ebu29veM8FDMu8a00jwZpLRieMCzNmCRIu1wQa");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TyreProductions",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProductionDate",
                value: new DateTime(2024, 10, 25, 11, 25, 54, 795, DateTimeKind.Local).AddTicks(3106));

            migrationBuilder.UpdateData(
                table: "TyreProductions",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProductionDate",
                value: new DateTime(2024, 10, 25, 11, 25, 54, 795, DateTimeKind.Local).AddTicks(3246));

            migrationBuilder.UpdateData(
                table: "TyreSales",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfSale",
                value: new DateTime(2024, 10, 25, 11, 25, 54, 795, DateTimeKind.Local).AddTicks(3373));

            migrationBuilder.UpdateData(
                table: "TyreSales",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateOfSale",
                value: new DateTime(2024, 10, 25, 11, 25, 54, 795, DateTimeKind.Local).AddTicks(3383));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$jcLQ893jdIrtP6YskZ.bKuLe5QVK3nmKeEDpufYIsL1ZNDp3hf9wG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$BLmxU4Tiz8C/DIXHE7aTXe5XZchm9YozLAO5l3UL7y7s/NBCiAUGm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$RW5TObzItuFFB57Z4.9...KekD9VPfam51prOQXWl5ilS7SwGrTaG");
        }
    }
}
