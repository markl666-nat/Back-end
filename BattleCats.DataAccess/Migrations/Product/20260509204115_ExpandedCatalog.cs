using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BattleCats.DataAccess.Migrations.Product
{
    /// <inheritdoc />
    public partial class ExpandedCatalog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Lores",
                columns: new[] { "Id", "Description", "DescriptionAdvancedId" },
                values: new object[,]
                {
                    { 18, "Желейный кот. Мягкий снаружи, крепкий внутри. Растворяет врагов кислотой.", 1 },
                    { 19, "Breakerblast Base — пушка-разрушитель на крыше базы. Бьёт по дальним целям.", null },
                    { 20, "Стандартное укрепление базы. Простое, дешёвое, эффективное против лёгких атак.", null },
                    { 21, "Громовая база. Электрическая турель, парализующая врагов на подступах.", null },
                    { 22, "Cat Combo Pewpewpew. Стартовая мощь Cat Cannon усилена. Бьёт чаще и больнее.", null },
                    { 23, "Cat Combo Dragon Slayer. Massive Damage против Red, Floating и Angel врагов.", null },
                    { 24, "Золотая капсула. Гарантирует юнита Super Rare или выше.", null },
                    { 25, "Обычная капсула. Случайный кот стандартного редкости. Шанс на Rare.", null }
                });

            migrationBuilder.InsertData(
                table: "Stats",
                columns: new[] { "Id", "Attack", "Health", "Range" },
                values: new object[,]
                {
                    { 4, 720, 3200, 290 },
                    { 5, 1100, 5800, 350 },
                    { 6, 950, 4100, 270 },
                    { 7, 880, 3800, 200 },
                    { 8, 540, 2700, 320 },
                    { 9, 1500, 9999, 480 },
                    { 10, 360, 1800, 220 },
                    { 11, 1300, 6500, 410 },
                    { 12, 420, 2400, 260 },
                    { 13, 660, 3300, 240 },
                    { 14, 280, 1600, 130 }
                });

            migrationBuilder.InsertData(
                table: "BattleItems",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "LoreId", "Name", "PriceEuro", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 18, 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 18, "Slime Cat", 1.49m, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 19, 2, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 19, "Breakerblast Base", 6.99m, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 20, 2, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 20, "Default Base", 0.99m, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 21, 2, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 21, "Thunderbolt Base", 8.99m, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 22, 3, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 22, "Cat Combo: Pewpewpew!", 2.49m, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 23, 3, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 23, "Cat Combo: Dragon Slayer", 3.99m, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 24, 4, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 24, "Gold Gacha Capsule", 14.99m, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 25, 4, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 25, "Normal Gacha Capsule", 2.99m, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "Lores",
                columns: new[] { "Id", "Description", "DescriptionAdvancedId" },
                values: new object[,]
                {
                    { 7, "Изящный фехтовальщик в плаще и шляпе. Стремителен и точен, словно D'Artagnan.", 4 },
                    { 8, "Тёмная эволюция D'artanyan'а. Облачён в чёрные доспехи с синим свечением, режет насквозь.", 5 },
                    { 9, "Каору Ханаяма — мастер боевых искусств с разрушительной силой кулака.", 6 },
                    { 10, "Касли — проклятие на двух лапах. Магический урон по площади.", 7 },
                    { 11, "Король Судьбы Phono. Громовая ярость, разрушающая всё на пути.", 8 },
                    { 12, "Бесстрашный курьер. Доставляет посылки прямо на поле боя.", 9 },
                    { 13, "Безумный пельмень-кот. Прыгает на врагов с пугающей радостью.", 10 },
                    { 14, "Гаматото — гигантский исследовательский кот. Откапывает ресурсы.", 11 },
                    { 15, "Легелуга. Фигуристка-кот с ледяной грацией и колкими атаками.", 12 },
                    { 16, "Pen-Pineapple-Apple-Pen Cat. Простая мелодия — мощное оружие.", 13 },
                    { 17, "Сквайр Луно — благородный молодой воин на службе ночи.", 14 }
                });

            migrationBuilder.InsertData(
                table: "BattleItems",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "LoreId", "Name", "PriceEuro", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 7, 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 7, "D'artanyan", 5.99m, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 8, 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 8, "D'arktanyan", 9.99m, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 9, 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 9, "Kaoru Hanayama", 8.49m, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 10, 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 10, "Kasli the Bane", 7.49m, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 11, 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 11, "King of Doom Phono", 12.99m, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 12, 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 12, "Courier Cat", 3.49m, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 13, 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 13, "Crazy Baozi Cat", 1.99m, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 14, 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 14, "Gamatoto", 6.99m, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 15, 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 15, "Legeluga", 4.49m, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 16, 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 16, "Pikotaro", 2.99m, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 17, 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 17, "Squire Luno", 5.49m, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "BattleItemId", "Url" },
                values: new object[,]
                {
                    { 18, 18, "/images/cats/slime_cat.jpg" },
                    { 19, 19, "/images/cats/breakerblast_base.jpg" },
                    { 20, 20, "/images/cats/default_base.jpg" },
                    { 21, 21, "/images/cats/thunderbolt_base.jpg" },
                    { 22, 22, "/images/cats/catcombo_buff_1.jpg" },
                    { 23, 23, "/images/cats/catcombo_buff_2.jpg" },
                    { 24, 24, "/images/cats/gold_gacha.jpg" },
                    { 25, 25, "/images/cats/normal_gacha.jpg" },
                    { 7, 7, "/images/cats/D_artanyan.jpg" },
                    { 8, 8, "/images/cats/D_arktanyan.jpg" },
                    { 9, 9, "/images/cats/Kaoru_Hanayama.jpg" },
                    { 10, 10, "/images/cats/Kasli_the_Bane.jpg" },
                    { 11, 11, "/images/cats/King_of_Doom_Phono.jpg" },
                    { 12, 12, "/images/cats/courier_cat.jpg" },
                    { 13, 13, "/images/cats/crazy_baozi_cat.jpg" },
                    { 14, 14, "/images/cats/gamatoto.jpg" },
                    { 15, 15, "/images/cats/legeluga.jpg" },
                    { 16, 16, "/images/cats/pikotaro.jpg" },
                    { 17, 17, "/images/cats/squire_luno.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "BattleItems",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "BattleItems",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "BattleItems",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "BattleItems",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "BattleItems",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "BattleItems",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "BattleItems",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "BattleItems",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "BattleItems",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "BattleItems",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "BattleItems",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "BattleItems",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "BattleItems",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "BattleItems",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "BattleItems",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "BattleItems",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "BattleItems",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "BattleItems",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "BattleItems",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Lores",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Lores",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Lores",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Lores",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Lores",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Lores",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Lores",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Lores",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Lores",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Lores",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Lores",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Lores",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Lores",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Lores",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Lores",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Lores",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Lores",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Lores",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Lores",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Stats",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Stats",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Stats",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Stats",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Stats",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Stats",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Stats",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Stats",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Stats",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Stats",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Stats",
                keyColumn: "Id",
                keyValue: 14);
        }
    }
}
