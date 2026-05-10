using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BattleCats.DataAccess.Migrations.Product
{
    /// <inheritdoc />
    public partial class InitialProductSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Health = table.Column<int>(type: "int", nullable: false),
                    Attack = table.Column<int>(type: "int", nullable: false),
                    Range = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DescriptionAdvancedId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lores_Stats_DescriptionAdvancedId",
                        column: x => x.DescriptionAdvancedId,
                        principalTable: "Stats",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BattleItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LoreId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    PriceEuro = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattleItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BattleItems_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BattleItems_Lores_LoreId",
                        column: x => x.LoreId,
                        principalTable: "Lores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    BattleItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_BattleItems_BattleItemId",
                        column: x => x.BattleItemId,
                        principalTable: "BattleItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Cat Units" },
                    { 2, "Base Upgrades" },
                    { 3, "Buffs" },
                    { 4, "Gacha" }
                });

            migrationBuilder.InsertData(
                table: "Lores",
                columns: new[] { "Id", "Description", "DescriptionAdvancedId" },
                values: new object[,]
                {
                    { 19, "Breakerblast Base — пушка-разрушитель на крыше базы. Бьёт по дальним целям мощным взрывом.", null },
                    { 20, "Стандартное укрепление базы. Простое, дешёвое, эффективное против лёгких атак противника.", null },
                    { 21, "Громовая база. Электрическая турель, парализующая врагов на подступах разрядами молний.", null },
                    { 22, "Cat Combo Pewpewpew. Стартовая мощь Cat Cannon усилена на старте боя — бьёт чаще и больнее.", null },
                    { 23, "Cat Combo Dragon Slayer. Massive Damage против Red, Floating и Angel врагов. Незаменимо в поздней игре.", null },
                    { 24, "Золотая капсула. Гарантирует юнита Super Rare или выше. Шанс на Uber Rare значительно повышен.", null },
                    { 25, "Обычная капсула. Случайный кот стандартной редкости. Шанс на Rare — небольшой, но реальный.", null }
                });

            migrationBuilder.InsertData(
                table: "Stats",
                columns: new[] { "Id", "Attack", "Health", "Range" },
                values: new object[,]
                {
                    { 1, 250, 1500, 140 },
                    { 2, 600, 4500, 100 },
                    { 3, 480, 2200, 380 },
                    { 4, 720, 3200, 290 },
                    { 5, 1100, 5800, 350 },
                    { 6, 950, 4100, 270 },
                    { 7, 1300, 6500, 410 },
                    { 8, 360, 1800, 220 },
                    { 9, 1500, 9999, 480 },
                    { 10, 420, 2400, 260 },
                    { 11, 660, 3300, 240 },
                    { 12, 280, 1600, 130 }
                });

            migrationBuilder.InsertData(
                table: "BattleItems",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "LoreId", "Name", "PriceEuro", "Status", "UpdatedAt" },
                values: new object[,]
                {
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
                    { 1, "Желейный кот-новобранец. Мягкий снаружи, крепкий внутри. Растворяет врагов кислотой и быстро регенерирует.", 1 },
                    { 2, "Бесстрашный курьер с танковой бронёй. Доставляет посылки прямо на поле боя и поглощает удары.", 2 },
                    { 3, "Касли — проклятие на двух лапах. Снайпер с магическим уроном по площади из глубокого тыла.", 3 },
                    { 7, "Изящный фехтовальщик в плаще и шляпе. Стремителен и точен, словно D'Artagnan из мушкетёров.", 4 },
                    { 8, "Тёмная эволюция D'artanyan'а. Облачён в чёрные доспехи с синим свечением, режет насквозь.", 5 },
                    { 9, "Каору Ханаяма — мастер боевых искусств. Один удар кулака способен сокрушить целые армии.", 6 },
                    { 11, "Король Судьбы Phono. Громовая ярость, разрушающая всё на пути. Электрический урон с большой дальностью.", 7 },
                    { 13, "Безумный пельмень-кот (Crazy Baozi). Прыгает на врагов с пугающей радостью. Дешёвый и быстрый.", 8 },
                    { 14, "Гаматото — гигантский исследовательский кот. Не атакует, но откапывает ресурсы и редкие предметы.", 9 },
                    { 15, "Легелуга. Фигуристка-кот с ледяной грацией и колкими атаками. Замораживает врагов.", 10 },
                    { 16, "Pen-Pineapple-Apple-Pen Cat. Простая мелодия — мощное оружие. Стильный, но смертельный.", 11 },
                    { 17, "Сквайр Луно — благородный молодой воин на службе ночи. Защищает базу от теней.", 12 }
                });

            migrationBuilder.InsertData(
                table: "BattleItems",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "LoreId", "Name", "PriceEuro", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Slime Cat", 1.49m, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 2, 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, "Courier Cat", 3.49m, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 3, 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3, "Kasli the Bane", 7.49m, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 7, 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 7, "D'artanyan", 5.99m, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 8, 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 8, "D'arktanyan", 9.99m, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 9, 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 9, "Kaoru Hanayama", 8.49m, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 11, 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 11, "King of Doom Phono", 12.99m, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
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
                    { 19, 19, "/images/cats/breakerblast_base.jpg" },
                    { 20, 20, "/images/cats/default_base.jpg" },
                    { 21, 21, "/images/cats/thunderbolt_base.jpg" },
                    { 22, 22, "/images/cats/catcombo_buff_1.jpg" },
                    { 23, 23, "/images/cats/catcombo_buff_2.jpg" },
                    { 24, 24, "/images/cats/gold_gacha.jpg" },
                    { 25, 25, "/images/cats/normal_gacha.jpg" },
                    { 1, 1, "/images/cats/slime_cat.jpg" },
                    { 2, 2, "/images/cats/courier_cat.jpg" },
                    { 3, 3, "/images/cats/Kasli_the_Bane.jpg" },
                    { 7, 7, "/images/cats/D_artanyan.jpg" },
                    { 8, 8, "/images/cats/D_arktanyan.jpg" },
                    { 9, 9, "/images/cats/Kaoru_Hanayama.jpg" },
                    { 11, 11, "/images/cats/King_of_Doom_Phono.jpg" },
                    { 13, 13, "/images/cats/crazy_baozi_cat.jpg" },
                    { 14, 14, "/images/cats/gamatoto.jpg" },
                    { 15, 15, "/images/cats/legeluga.jpg" },
                    { 16, 16, "/images/cats/pikotaro.jpg" },
                    { 17, 17, "/images/cats/squire_luno.jpg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BattleItems_CategoryId",
                table: "BattleItems",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleItems_LoreId",
                table: "BattleItems",
                column: "LoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_BattleItemId",
                table: "Images",
                column: "BattleItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Lores_DescriptionAdvancedId",
                table: "Lores",
                column: "DescriptionAdvancedId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "BattleItems");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Lores");

            migrationBuilder.DropTable(
                name: "Stats");
        }
    }
}
