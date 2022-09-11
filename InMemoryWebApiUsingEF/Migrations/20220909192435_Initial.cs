using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplianceAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Appliances",
                columns: table => new
                {
                    ApplianceID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FactoryNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appliances", x => x.ApplianceID);
                    table.ForeignKey(
                        name: "FK_Appliances_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplianceStatuses",
                columns: table => new
                {
                    ApplianceStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplianceID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateOfStatus = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplianceStatuses", x => x.ApplianceStatusID);
                    table.ForeignKey(
                        name: "FK_ApplianceStatuses_Appliances_ApplianceID",
                        column: x => x.ApplianceID,
                        principalTable: "Appliances",
                        principalColumn: "ApplianceID");
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "Name" },
                values: new object[] { 1L, "Kalles Grustransporter AB Cementvägen 8, 111 11 Södertälje" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "Name" },
                values: new object[] { 2L, "Johans Bulk AB Balkvägen 12, 222 22 Stockholm" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "Name" },
                values: new object[] { 3L, "Haralds Värdetransporter AB Budgetvägen 1, 333 33 Uppsala" });

            migrationBuilder.InsertData(
                table: "Appliances",
                columns: new[] { "ApplianceID", "CustomerID", "FactoryNo" },
                values: new object[,]
                {
                    { "VLUR4X20009048066", 1L, "GHI789" },
                    { "VLUR4X20009093588", 1L, "ABC123" },
                    { "YS2R4X20005387055", 3L, "STU901" },
                    { "YS2R4X20005387949", 2L, "MNO345" },
                    { "YS2R4X20005388011", 2L, "JKL012" },
                    { "YS2R4X20005399401", 1L, "ABC123" },
                    { "YS2R4X20009048066", 3L, "PQR678" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appliances_CustomerID",
                table: "Appliances",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_ApplianceStatuses_ApplianceID",
                table: "ApplianceStatuses",
                column: "ApplianceID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplianceStatuses");

            migrationBuilder.DropTable(
                name: "Appliances");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
