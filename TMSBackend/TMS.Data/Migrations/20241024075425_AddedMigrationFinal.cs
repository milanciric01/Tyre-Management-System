using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedMigrationFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TyreProductionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logs_TyreProductions_TyreProductionId",
                        column: x => x.TyreProductionId,
                        principalTable: "TyreProductions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Logs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Logs_TyreProductionId",
                table: "Logs",
                column: "TyreProductionId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_UserId",
                table: "Logs",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");

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
    }
}
