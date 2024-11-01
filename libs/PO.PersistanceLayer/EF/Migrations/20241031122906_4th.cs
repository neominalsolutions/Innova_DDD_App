using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PO.PersistanceLayer.EF.Migrations
{
    /// <inheritdoc />
    public partial class _4th : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cost_Currency1",
                table: "PurchaseQuotes");

            migrationBuilder.AlterColumn<string>(
                name: "Cost_Currency",
                table: "PurchaseQuotes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<decimal>(
                name: "Cost_Amount",
                table: "PurchaseQuotes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cost_Amount",
                table: "PurchaseQuotes");

            migrationBuilder.AlterColumn<decimal>(
                name: "Cost_Currency",
                table: "PurchaseQuotes",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Cost_Currency1",
                table: "PurchaseQuotes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
