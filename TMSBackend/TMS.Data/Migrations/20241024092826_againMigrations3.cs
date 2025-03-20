using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class againMigrations3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logs_TyreProductions_TyreProductionId",
                table: "Logs");

            migrationBuilder.DropIndex(
                name: "IX_Logs_TyreProductionId",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "TyreProductionId",
                table: "Logs");

            migrationBuilder.UpdateData(
                table: "TyreProductions",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProductionDate",
                value: new DateTime(2024, 10, 24, 11, 28, 25, 932, DateTimeKind.Local).AddTicks(9806));

            migrationBuilder.UpdateData(
                table: "TyreProductions",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProductionDate",
                value: new DateTime(2024, 10, 24, 11, 28, 25, 932, DateTimeKind.Local).AddTicks(9988));

            migrationBuilder.UpdateData(
                table: "TyreSales",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfSale",
                value: new DateTime(2024, 10, 24, 11, 28, 25, 933, DateTimeKind.Local).AddTicks(171));

            migrationBuilder.UpdateData(
                table: "TyreSales",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateOfSale",
                value: new DateTime(2024, 10, 24, 11, 28, 25, 933, DateTimeKind.Local).AddTicks(192));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$PM72nrAJ0XNEoa4/X5RKYOEqGtBBgbaxnMomSq3j6va4SK7wjYU.m");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$DH59WsE0lU6OjKztFMovnOssnywB7f5H6Qe6dGt3z9X8Cgt9CyDdu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$1IWVgUoW0ylkYBpkTbCOTO35GJl.JXmwuLBLMUi/RwtlZPrgYsCD6");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TyreProductionId",
                table: "Logs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "TyreProductions",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProductionDate",
                value: new DateTime(2024, 10, 24, 10, 53, 44, 968, DateTimeKind.Local).AddTicks(6217));

            migrationBuilder.UpdateData(
                table: "TyreProductions",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProductionDate",
                value: new DateTime(2024, 10, 24, 10, 53, 44, 968, DateTimeKind.Local).AddTicks(6315));

            migrationBuilder.UpdateData(
                table: "TyreSales",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfSale",
                value: new DateTime(2024, 10, 24, 10, 53, 44, 968, DateTimeKind.Local).AddTicks(6439));

            migrationBuilder.UpdateData(
                table: "TyreSales",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateOfSale",
                value: new DateTime(2024, 10, 24, 10, 53, 44, 968, DateTimeKind.Local).AddTicks(6450));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$oW4ek1RGE41paRroR5FN6enk3eGMv6.W93jWil1PU4pq.nk.m5c3a");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$O8QjBXI0jL8o2vu9/DZuH.IYe3rLnR.GK.NH8oO6k1cI7aLAujgTm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$FoE/wfmK5QZNfp0pc2rn5OA5Rgowi9Nm5LE0eb7OwUPVNWUpYXnmW");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_TyreProductionId",
                table: "Logs",
                column: "TyreProductionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_TyreProductions_TyreProductionId",
                table: "Logs",
                column: "TyreProductionId",
                principalTable: "TyreProductions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
