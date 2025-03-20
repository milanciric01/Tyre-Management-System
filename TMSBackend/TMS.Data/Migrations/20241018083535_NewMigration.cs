using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserRole = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TyreProductions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TyreCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OperatorId = table.Column<int>(type: "int", nullable: false),
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductionShift = table.Column<int>(type: "int", nullable: false),
                    MachineNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TyreProductions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TyreProductions_Users_OperatorId",
                        column: x => x.OperatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductionRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PerformedById = table.Column<int>(type: "int", nullable: false),
                    TyreProductionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductionRecords_TyreProductions_TyreProductionId",
                        column: x => x.TyreProductionId,
                        principalTable: "TyreProductions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductionRecords_Users_PerformedById",
                        column: x => x.PerformedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TyreSales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TyreName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuantitySold = table.Column<int>(type: "int", nullable: false),
                    UnitOfMeasure = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateOfSale = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReferenceProductionId = table.Column<int>(type: "int", nullable: false),
                    DestinationMarket = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PurchasingCompany = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TyreSales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TyreSales_TyreProductions_ReferenceProductionId",
                        column: x => x.ReferenceProductionId,
                        principalTable: "TyreProductions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "UserRole", "Username" },
                values: new object[,]
                {
                    { 1, "$2a$11$q9DiZgn5XNj/.rEK6oklWer8JYGKtZIDFYH6Fk6i2VqNv9VDrhXBu", 0, "operator1" },
                    { 2, "$2a$11$sdZS81IWrpZ8.1/FJScm0.Y4z8nSSDyrFyZVs9JX74MryxOCQ/Xx2", 1, "supervisor1" },
                    { 3, "$2a$11$aJdhRZu6jvS0t.1miya.becFFWbTQnWATVquoYaROCU4NqmiBKfu6", 2, "leader1" }
                });

            migrationBuilder.InsertData(
                table: "TyreProductions",
                columns: new[] { "Id", "MachineNumber", "OperatorId", "ProductionDate", "ProductionShift", "Quantity", "TyreCode" },
                values: new object[,]
                {
                    { 1, "M001", 1, new DateTime(2024, 10, 18, 10, 35, 34, 39, DateTimeKind.Local).AddTicks(8726), 0, 100, "T123" },
                    { 2, "M002", 1, new DateTime(2024, 10, 18, 10, 35, 34, 39, DateTimeKind.Local).AddTicks(8893), 2, 150, "T124" }
                });

            migrationBuilder.InsertData(
                table: "TyreSales",
                columns: new[] { "Id", "DateOfSale", "DestinationMarket", "Price", "PurchasingCompany", "QuantitySold", "ReferenceProductionId", "TyreName", "UnitOfMeasure" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 18, 10, 35, 34, 39, DateTimeKind.Local).AddTicks(9063), "Local", 100.00m, "ABC Ltd.", 50, 1, "T123", "pieces" },
                    { 2, new DateTime(2024, 10, 18, 10, 35, 34, 39, DateTimeKind.Local).AddTicks(9084), "International", 120.00m, "XYZ Corp.", 30, 2, "T124", "pieces" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductionRecords_PerformedById",
                table: "ProductionRecords",
                column: "PerformedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionRecords_TyreProductionId",
                table: "ProductionRecords",
                column: "TyreProductionId");

            migrationBuilder.CreateIndex(
                name: "IX_TyreProductions_OperatorId",
                table: "TyreProductions",
                column: "OperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_TyreSales_ReferenceProductionId",
                table: "TyreSales",
                column: "ReferenceProductionId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductionRecords");

            migrationBuilder.DropTable(
                name: "TyreSales");

            migrationBuilder.DropTable(
                name: "TyreProductions");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
