using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LaborU.Data.Migrations
{
    public partial class AddNullablePeopleCreatedUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Peoples",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedUserId",
                table: "Peoples",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserId1",
                table: "Peoples",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Peoples_CreatedUserId1",
                table: "Peoples",
                column: "CreatedUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Peoples_AspNetUsers_CreatedUserId1",
                table: "Peoples",
                column: "CreatedUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Peoples_AspNetUsers_CreatedUserId1",
                table: "Peoples");

            migrationBuilder.DropIndex(
                name: "IX_Peoples_CreatedUserId1",
                table: "Peoples");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Peoples");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "Peoples");

            migrationBuilder.DropColumn(
                name: "CreatedUserId1",
                table: "Peoples");
        }
    }
}
