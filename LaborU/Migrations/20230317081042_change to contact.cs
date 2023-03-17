using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborU.Migrations
{
    public partial class changetocontact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IncomeReceipt_Peoples_ToPeopleId",
                table: "IncomeReceipt");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipment_Peoples_PeopleId",
                table: "Shipment");

            migrationBuilder.DropTable(
                name: "Peoples");

            migrationBuilder.DropIndex(
                name: "IX_Shipment_PeopleId",
                table: "Shipment");

            migrationBuilder.AddColumn<Guid>(
                name: "ContactId",
                table: "Shipment",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IDNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedUserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contact_AspNetUsers_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contact_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ContactType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ContactContactType",
                columns: table => new
                {
                    ContactId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactContactType", x => new { x.ContactId, x.TypeId });
                    table.ForeignKey(
                        name: "FK_ContactContactType_Contact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactContactType_ContactType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "ContactType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "ContactType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "捐款者" });

            migrationBuilder.InsertData(
                table: "ContactType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "一般會員" });

            migrationBuilder.InsertData(
                table: "ContactType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "贊助會員" });

            migrationBuilder.CreateIndex(
                name: "IX_Shipment_ContactId",
                table: "Shipment",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_CreatedUserId",
                table: "Contact",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_Email",
                table: "Contact",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contact_UserId",
                table: "Contact",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactContactType_TypeId",
                table: "ContactContactType",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_IncomeReceipt_Contact_ToPeopleId",
                table: "IncomeReceipt",
                column: "ToPeopleId",
                principalTable: "Contact",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shipment_Contact_ContactId",
                table: "Shipment",
                column: "ContactId",
                principalTable: "Contact",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IncomeReceipt_Contact_ToPeopleId",
                table: "IncomeReceipt");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipment_Contact_ContactId",
                table: "Shipment");

            migrationBuilder.DropTable(
                name: "ContactContactType");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "ContactType");

            migrationBuilder.DropIndex(
                name: "IX_Shipment_ContactId",
                table: "Shipment");

            migrationBuilder.DropColumn(
                name: "ContactId",
                table: "Shipment");

            migrationBuilder.CreateTable(
                name: "Peoples",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Address = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    CreatedUserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Email = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IDNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peoples", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Peoples_AspNetUsers_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Shipment_PeopleId",
                table: "Shipment",
                column: "PeopleId");

            migrationBuilder.CreateIndex(
                name: "IX_Peoples_CreatedUserId",
                table: "Peoples",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Peoples_Email",
                table: "Peoples",
                column: "Email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_IncomeReceipt_Peoples_ToPeopleId",
                table: "IncomeReceipt",
                column: "ToPeopleId",
                principalTable: "Peoples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shipment_Peoples_PeopleId",
                table: "Shipment",
                column: "PeopleId",
                principalTable: "Peoples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
