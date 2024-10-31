using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PO.API.Migrations
{
    /// <inheritdoc />
    public partial class PoModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PurchaseOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PurchaseRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PurchaseQuoteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status_Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost_Value = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseQuotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PurchaseRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cost_Currency = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cost_Currency1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status_Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost_Value = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseQuotes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status_Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status_Value = table.Column<int>(type: "int", nullable: false),
                    Budget_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Budget_Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseRequests", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseOrders");

            migrationBuilder.DropTable(
                name: "PurchaseQuotes");

            migrationBuilder.DropTable(
                name: "PurchaseRequests");
        }
    }
}
