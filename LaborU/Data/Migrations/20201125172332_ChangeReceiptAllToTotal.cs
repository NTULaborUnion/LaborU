using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborU.Data.Migrations
{
    public partial class ChangeReceiptAllToTotal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "All",
                table: "IncomeReceipt",
                newName: "Total");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Total",
                table: "IncomeReceipt",
                newName: "All");
        }
    }
}
