using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedMigrationFinal2 : Migration
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
                value: new DateTime(2024, 10, 24, 9, 54, 24, 567, DateTimeKind.Local).AddTicks(6161));

            migrationBuilder.UpdateData(
                table: "TyreProductions",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProductionDate",
                value: new DateTime(2024, 10, 24, 9, 54, 24, 567, DateTimeKind.Local).AddTicks(6250));

            migrationBuilder.UpdateData(
                table: "TyreSales",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfSale",
                value: new DateTime(2024, 10, 24, 9, 54, 24, 567, DateTimeKind.Local).AddTicks(6376));

            migrationBuilder.UpdateData(
                table: "TyreSales",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateOfSale",
                value: new DateTime(2024, 10, 24, 9, 54, 24, 567, DateTimeKind.Local).AddTicks(6390));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$oZBzzJ.TyEwKS0z1Lj4AxOmmXZeJpkv4AhuiH70C3tf/.Nu3hVtbO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$lnyDjKjI/BD9Kw11tFEQmeKPu/QnwUKitivGRDj3kYVDg1oisxHjO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$4Aifmyj3DCOty/7KfU8Ox.7WrJEN9vtSxxYX4asZCoRaL0xf0T/su");

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
    }
}
