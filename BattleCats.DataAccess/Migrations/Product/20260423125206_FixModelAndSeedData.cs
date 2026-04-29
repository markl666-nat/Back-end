using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BattleCats.DataAccess.Migrations.Product
{
    /// <inheritdoc />
    public partial class FixModelAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Phones" },
                    { 2, "Laptops" }
                });

            migrationBuilder.InsertData(
                table: "DescriptionAdvanced",
                columns: new[] { "Id", "H", "L", "W" },
                values: new object[,]
                {
                    { 1, 10, 2, 5 },
                    { 2, 20, 3, 10 }
                });

            migrationBuilder.InsertData(
                table: "ProductImgs",
                columns: new[] { "Id", "ProductDataId", "ProductId", "Url" },
                values: new object[,]
                {
                    { 1, null, 1, "iphone.jpg" },
                    { 2, null, 2, "asus.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Description",
                columns: new[] { "Id", "Description", "DescriptionAdvancedId" },
                values: new object[,]
                {
                    { 1, "iPhone 15 description", 1 },
                    { 2, "Gaming laptop description", 2 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "DescriptionId", "Name", "Price", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "iPhone 15", 999m, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ASUS ROG", 1999m, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Description",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Description",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductImgs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductImgs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DescriptionAdvanced",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DescriptionAdvanced",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
