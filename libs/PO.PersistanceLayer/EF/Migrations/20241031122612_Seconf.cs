using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PO.PersistanceLayer.EF.Migrations
{
    /// <inheritdoc />
    public partial class Seconf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cost_Value",
                table: "PurchaseOrders",
                newName: "Status_Value");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status_Value",
                table: "PurchaseOrders",
                newName: "Cost_Value");
        }
    }
}
