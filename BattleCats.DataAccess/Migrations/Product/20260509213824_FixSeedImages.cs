using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BattleCats.DataAccess.Migrations.Product
{
    /// <inheritdoc />
    public partial class FixSeedImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1,
                column: "Url",
                value: "/images/cats/slime_cat.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2,
                column: "Url",
                value: "/images/cats/courier_cat.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3,
                column: "Url",
                value: "/images/cats/Kasli_the_Bane.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4,
                column: "Url",
                value: "/images/cats/default_base.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 5,
                column: "Url",
                value: "/images/cats/catcombo_buff_1.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 6,
                column: "Url",
                value: "/images/cats/normal_gacha.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1,
                column: "Url",
                value: "https://battlecats-db.com/img/unit/000/00/icon.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2,
                column: "Url",
                value: "https://battlecats-db.com/img/unit/002/00/icon.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3,
                column: "Url",
                value: "https://battlecats-db.com/img/unit/004/00/icon.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4,
                column: "Url",
                value: "https://battlecats-db.com/img/items/speedup.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 5,
                column: "Url",
                value: "https://battlecats-db.com/img/items/buff.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 6,
                column: "Url",
                value: "https://battlecats-db.com/img/items/capsule.png");
        }
    }
}
