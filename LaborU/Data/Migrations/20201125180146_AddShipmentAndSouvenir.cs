using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborU.Data.Migrations
{
    public partial class AddShipmentAndSouvenir : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedUserId",
                table: "Peoples",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ShipmentId",
                table: "IncomeReceipt",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Shipment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PeopleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shipment_Peoples_PeopleId",
                        column: x => x.PeopleId,
                        principalTable: "Peoples",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Souvenir",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Total = table.Column<int>(type: "int", nullable: false),
                    Remain = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Souvenir", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShipmentSouvenir",
                columns: table => new
                {
                    ShipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SouvenirId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentSouvenir", x => new { x.ShipmentId, x.SouvenirId });
                    table.ForeignKey(
                        name: "FK_ShipmentSouvenir_Shipment_ShipmentId",
                        column: x => x.ShipmentId,
                        principalTable: "Shipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShipmentSouvenir_Souvenir_SouvenirId",
                        column: x => x.SouvenirId,
                        principalTable: "Souvenir",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IncomeReceipt_ShipmentId",
                table: "IncomeReceipt",
                column: "ShipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipment_PeopleId",
                table: "Shipment",
                column: "PeopleId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentSouvenir_SouvenirId",
                table: "ShipmentSouvenir",
                column: "SouvenirId");

            migrationBuilder.AddForeignKey(
                name: "FK_IncomeReceipt_Shipment_ShipmentId",
                table: "IncomeReceipt",
                column: "ShipmentId",
                principalTable: "Shipment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IncomeReceipt_Shipment_ShipmentId",
                table: "IncomeReceipt");

            migrationBuilder.DropTable(
                name: "ShipmentSouvenir");

            migrationBuilder.DropTable(
                name: "Shipment");

            migrationBuilder.DropTable(
                name: "Souvenir");

            migrationBuilder.DropIndex(
                name: "IX_IncomeReceipt_ShipmentId",
                table: "IncomeReceipt");

            migrationBuilder.DropColumn(
                name: "ShipmentId",
                table: "IncomeReceipt");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedUserId",
                table: "Peoples",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }
    }
}
