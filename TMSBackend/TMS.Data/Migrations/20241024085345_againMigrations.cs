using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class againMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logs_TyreProductions_TyreProductionId",
                table: "Logs");

            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Users_UserId",
                table: "Logs");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_TyreProductions_TyreProductionId",
                table: "Logs",
                column: "TyreProductionId",
                principalTable: "TyreProductions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Users_UserId",
                table: "Logs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logs_TyreProductions_TyreProductionId",
                table: "Logs");

            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Users_UserId",
                table: "Logs");

            migrationBuilder.UpdateData(
                table: "TyreProductions",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProductionDate",
                value: new DateTime(2024, 10, 24, 10, 31, 50, 721, DateTimeKind.Local).AddTicks(6978));

            migrationBuilder.UpdateData(
                table: "TyreProductions",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProductionDate",
                value: new DateTime(2024, 10, 24, 10, 31, 50, 721, DateTimeKind.Local).AddTicks(7066));

            migrationBuilder.UpdateData(
                table: "TyreSales",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfSale",
                value: new DateTime(2024, 10, 24, 10, 31, 50, 721, DateTimeKind.Local).AddTicks(7176));

            migrationBuilder.UpdateData(
                table: "TyreSales",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateOfSale",
                value: new DateTime(2024, 10, 24, 10, 31, 50, 721, DateTimeKind.Local).AddTicks(7187));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$iPZocT3ViNKN5tLae4VbIup/YfPWEwCamQPHaO8lDCNSwBLMZL/QO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$X2Uq/lyXAK.13sE38j8IeuJ6oYlEhyt9gcH1hwe5O92C9Nj345/Xy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$M2GY.Xu7F692N6to/EhLu.h36fDMliken0L8OUpADSNRQIkb91cRO");

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_TyreProductions_TyreProductionId",
                table: "Logs",
                column: "TyreProductionId",
                principalTable: "TyreProductions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Users_UserId",
                table: "Logs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
