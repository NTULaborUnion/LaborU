using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborU.Data.Migrations
{
    public partial class AddIncomeReceipt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Peoples",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peoples", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IncomeReceipt",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToPeopleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    All = table.Column<double>(type: "float", nullable: false),
                    ManagerNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PeopleNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeReceipt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncomeReceipt_AspNetUsers_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IncomeReceipt_Peoples_ToPeopleId",
                        column: x => x.ToPeopleId,
                        principalTable: "Peoples",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IncomeReceiptItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceiptId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeReceiptItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncomeReceiptItem_IncomeReceipt_ReceiptId",
                        column: x => x.ReceiptId,
                        principalTable: "IncomeReceipt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IncomeReceipt_CreatedUserId",
                table: "IncomeReceipt",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeReceipt_ToPeopleId",
                table: "IncomeReceipt",
                column: "ToPeopleId");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeReceiptItem_ReceiptId",
                table: "IncomeReceiptItem",
                column: "ReceiptId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IncomeReceiptItem");

            migrationBuilder.DropTable(
                name: "IncomeReceipt");

            migrationBuilder.DropTable(
                name: "Peoples");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
