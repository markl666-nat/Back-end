using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BattleCats.DataAccess.Migrations.User
{
    /// <inheritdoc />
    public partial class AddUserRoleAndSeedUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Contacts", "DOB", "Email", "Gender", "Password", "Role", "UserName" },
                values: new object[,]
                {
                    { 1, "+373 22 000001", new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@catbase.shop", 0, "de2bbe3336efa2083a96e58558cd2137", 30, "admin" },
                    { 2, "+373 22 000002", new DateTime(1996, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "manager@catbase.shop", 0, "b975e0ef031a57d65816b20dab4baca8", 20, "manager" },
                    { 3, "+373 22 000003", new DateTime(2000, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@catbase.shop", 0, "3bc5f1df7c15c68d62b1afcde8d30918", 1, "user" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");
        }
    }
}
