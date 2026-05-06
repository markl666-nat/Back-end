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
                    { 4, "Апгрейд скорости работы базы кошачьего штаба. Ускоряет выпуск юнитов.", null },
                    { 5, "Бафф усиленной атаки. Все юниты получают +50% к урону на 30 секунд.", null },
                    { 6, "Гача-капсула на редкого юнита. Шанс получить Uber Rare кота.", null }
                });

            migrationBuilder.InsertData(
                table: "Stats",
                columns: new[] { "Id", "Attack", "Health", "Range" },
                values: new object[,]
                {
                    { 1, 250, 1500, 140 },
                    { 2, 600, 4500, 100 },
                    { 3, 480, 2200, 380 }
                });

            migrationBuilder.InsertData(
                table: "BattleItems",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "LoreId", "Name", "PriceEuro", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 4, 2, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4, "Worker Cat Speed Up", 4.99m, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 5, 3, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 5, "Attack Power Up Buff", 1.99m, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 6, 4, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 6, "Rare Cat Capsule", 7.99m, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "Lores",
                columns: new[] { "Id", "Description", "DescriptionAdvancedId" },
                values: new object[,]
                {
                    { 1, "Базовый кот-новобранец. Дешёвый, быстро призывается, отлично прикрывает фронт.", 1 },
                    { 2, "Танкокот с огромным запасом здоровья. Поглощает удары вместо лёгких юнитов.", 2 },
                    { 3, "Снайпер-кот с длинной дальностью атаки. Бьёт врагов из глубокого тыла.", 3 }
                });

            migrationBuilder.InsertData(
                table: "BattleItems",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "LoreId", "Name", "PriceEuro", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Cat (Basic Tier)", 0.99m, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 2, 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, "Tank Cat", 2.49m, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 3, 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3, "Axe Cat", 3.99m, 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "BattleItemId", "Url" },
                values: new object[,]
                {
                    { 4, 4, "https://battlecats-db.com/img/items/speedup.png" },
                    { 5, 5, "https://battlecats-db.com/img/items/buff.png" },
                    { 6, 6, "https://battlecats-db.com/img/items/capsule.png" },
                    { 1, 1, "https://battlecats-db.com/img/unit/000/00/icon.png" },
                    { 2, 2, "https://battlecats-db.com/img/unit/002/00/icon.png" },
                    { 3, 3, "https://battlecats-db.com/img/unit/004/00/icon.png" }
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
