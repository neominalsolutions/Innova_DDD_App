using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PO.PersistanceLayer.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddRequestItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PurchaseRequestItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    PurchaseRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseRequestItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseRequestItem_PurchaseRequests_PurchaseRequestId",
                        column: x => x.PurchaseRequestId,
                        principalTable: "PurchaseRequests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseQuotes_PurchaseRequestId",
                table: "PurchaseQuotes",
                column: "PurchaseRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequestItem_PurchaseRequestId",
                table: "PurchaseRequestItem",
                column: "PurchaseRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseQuotes_PurchaseRequests_PurchaseRequestId",
                table: "PurchaseQuotes",
                column: "PurchaseRequestId",
                principalTable: "PurchaseRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseQuotes_PurchaseRequests_PurchaseRequestId",
                table: "PurchaseQuotes");

            migrationBuilder.DropTable(
                name: "PurchaseRequestItem");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseQuotes_PurchaseRequestId",
                table: "PurchaseQuotes");
        }
    }
}
