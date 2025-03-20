using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedProductScheme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductionRecords_TyreProductions_TyreProductionId",
                table: "ProductionRecords");

            migrationBuilder.DropIndex(
                name: "IX_ProductionRecords_TyreProductionId",
                table: "ProductionRecords");

            migrationBuilder.RenameColumn(
                name: "TyreProductionId",
                table: "ProductionRecords",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "Action",
                table: "ProductionRecords",
                newName: "TyreCode");

            migrationBuilder.AddColumn<string>(
                name: "MachineNumber",
                table: "ProductionRecords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ProductionDate",
                table: "ProductionRecords",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ProductionShift",
                table: "ProductionRecords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MachineNumber",
                table: "ProductionRecords");

            migrationBuilder.DropColumn(
                name: "ProductionDate",
                table: "ProductionRecords");

            migrationBuilder.DropColumn(
                name: "ProductionShift",
                table: "ProductionRecords");

            migrationBuilder.RenameColumn(
                name: "TyreCode",
                table: "ProductionRecords",
                newName: "Action");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "ProductionRecords",
                newName: "TyreProductionId");

            migrationBuilder.UpdateData(
                table: "TyreProductions",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProductionDate",
                value: new DateTime(2024, 10, 18, 10, 35, 34, 39, DateTimeKind.Local).AddTicks(8726));

            migrationBuilder.UpdateData(
                table: "TyreProductions",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProductionDate",
                value: new DateTime(2024, 10, 18, 10, 35, 34, 39, DateTimeKind.Local).AddTicks(8893));

            migrationBuilder.UpdateData(
                table: "TyreSales",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfSale",
                value: new DateTime(2024, 10, 18, 10, 35, 34, 39, DateTimeKind.Local).AddTicks(9063));

            migrationBuilder.UpdateData(
                table: "TyreSales",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateOfSale",
                value: new DateTime(2024, 10, 18, 10, 35, 34, 39, DateTimeKind.Local).AddTicks(9084));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$q9DiZgn5XNj/.rEK6oklWer8JYGKtZIDFYH6Fk6i2VqNv9VDrhXBu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$sdZS81IWrpZ8.1/FJScm0.Y4z8nSSDyrFyZVs9JX74MryxOCQ/Xx2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$aJdhRZu6jvS0t.1miya.becFFWbTQnWATVquoYaROCU4NqmiBKfu6");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionRecords_TyreProductionId",
                table: "ProductionRecords",
                column: "TyreProductionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionRecords_TyreProductions_TyreProductionId",
                table: "ProductionRecords",
                column: "TyreProductionId",
                principalTable: "TyreProductions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
