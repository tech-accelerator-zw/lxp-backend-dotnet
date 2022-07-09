using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagement.API.Migrations
{
    public partial class LecturerUserAccountToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Lecturers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Lecturers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Lecturers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Lecturers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Lecturers_UserId",
                table: "Lecturers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lecturers_Accounts_UserId",
                table: "Lecturers",
                column: "UserId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lecturers_Accounts_UserId",
                table: "Lecturers");

            migrationBuilder.DropIndex(
                name: "IX_Lecturers_UserId",
                table: "Lecturers");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Lecturers");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Lecturers");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Lecturers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Lecturers");
        }
    }
}
