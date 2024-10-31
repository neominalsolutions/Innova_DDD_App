using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PO.API.Migrations
{
    /// <inheritdoc />
    public partial class _3rd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cost_Value",
                table: "PurchaseQuotes",
                newName: "Status_Value");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status_Value",
                table: "PurchaseQuotes",
                newName: "Cost_Value");
        }
    }
}
