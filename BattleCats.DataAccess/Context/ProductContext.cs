using BattleCats.Domain.Entities.Product;
using BattleCats.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace BattleCats.DataAccess.Context
{
    /// <summary>
    /// Контекст БД для всего, что связано с товарами магазина Cat Base Shop.
    /// Управляет 5 связанными сущностями: BattleItem, ItemCategory, BattleItemLore,
    /// DescriptionAdvanced и ProductImgData.
    /// 
    /// Демонстрирует все основные типы связей в EF Core:
    ///   - One-to-One: BattleItem -> BattleItemLore -> DescriptionAdvanced
    ///   - One-to-Many: BattleItem -> List of ProductImgData
    ///   - Many-to-One: BattleItem -> ItemCategory
    /// </summary>
    public class ProductContext : DbContext
    {
        public DbSet<BattleItem> BattleItems { get; set; }
        public DbSet<ItemCategory> Categories { get; set; }
        public DbSet<BattleItemLore> Lores { get; set; }
        public DbSet<DescriptionAdvanced> Stats { get; set; }
        public DbSet<ProductImgData> Images { get; set; }

        /// <summary>
        /// Конфигурация подключения к SQL Server.
        /// Connection string хранится в DbSession.cs.
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbSession.ConnectionStrings.ProductDB);
        }

        /// <summary>
        /// Настройка связей между сущностями + seed-данные с реальными котами Battle Cats.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ============================================
            // 1) Категории — 4 фиксированные (как на фронте)
            // ============================================
            modelBuilder.Entity<ItemCategory>().HasData(
                new ItemCategory { Id = 1, Name = "Cat Units" },
                new ItemCategory { Id = 2, Name = "Base Upgrades" },
                new ItemCategory { Id = 3, Name = "Buffs" },
                new ItemCategory { Id = 4, Name = "Gacha" }
            );

            // ============================================
            // 2) Расширенные характеристики (только для Cat Units)
            //    DescriptionAdvanced — это статы юнита: HP, Attack, Range
            // ============================================
            modelBuilder.Entity<DescriptionAdvanced>().HasData(
                new DescriptionAdvanced { Id = 1, Health = 1500, Attack = 250, Range = 140 },
                new DescriptionAdvanced { Id = 2, Health = 4500, Attack = 600, Range = 100 },
                new DescriptionAdvanced { Id = 3, Health = 2200, Attack = 480, Range = 380 }
            );

            // ============================================
            // 3) Описания товаров (BattleItemLore)
            //    Часть из них ссылается на статы (для Cat Units)
            // ============================================
            modelBuilder.Entity<BattleItemLore>()
                .HasOne(l => l.DescriptionAdvanced)
                .WithMany()
                .HasForeignKey("DescriptionAdvancedId")
                .IsRequired(false);

            modelBuilder.Entity<BattleItemLore>().HasData(
                new { Id = 1, Description = "Базовый кот-новобранец. Дешёвый, быстро призывается, отлично прикрывает фронт.", DescriptionAdvancedId = (int?)1 },
                new { Id = 2, Description = "Танкокот с огромным запасом здоровья. Поглощает удары вместо лёгких юнитов.", DescriptionAdvancedId = (int?)2 },
                new { Id = 3, Description = "Снайпер-кот с длинной дальностью атаки. Бьёт врагов из глубокого тыла.", DescriptionAdvancedId = (int?)3 },
                new { Id = 4, Description = "Апгрейд скорости работы базы кошачьего штаба. Ускоряет выпуск юнитов.", DescriptionAdvancedId = (int?)null },
                new { Id = 5, Description = "Бафф усиленной атаки. Все юниты получают +50% к урону на 30 секунд.", DescriptionAdvancedId = (int?)null },
                new { Id = 6, Description = "Гача-капсула на редкого юнита. Шанс получить Uber Rare кота.", DescriptionAdvancedId = (int?)null }
            );

            // ============================================
            // 4) Сами товары (BattleItem)
            //    Связаны с категорией (M:1) и описанием (1:1)
            // ============================================
            modelBuilder.Entity<BattleItem>()
                .HasOne(b => b.Category)
                .WithMany()
                .IsRequired();

            modelBuilder.Entity<BattleItem>()
                .HasOne(b => b.Lore)
                .WithMany()
                .IsRequired(false);

            // Для seed нужны "плоские" данные с FK
            modelBuilder.Entity<BattleItem>().HasData(
                new
                {
                    Id = 1,
                    Name = "Cat (Basic Tier)",
                    PriceEuro = 0.99m,
                    Status = ItemAvailability.Active,
                    CategoryId = 1,
                    LoreId = (int?)1,
                    CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new
                {
                    Id = 2,
                    Name = "Tank Cat",
                    PriceEuro = 2.49m,
                    Status = ItemAvailability.Active,
                    CategoryId = 1,
                    LoreId = (int?)2,
                    CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new
                {
                    Id = 3,
                    Name = "Axe Cat",
                    PriceEuro = 3.99m,
                    Status = ItemAvailability.Active,
                    CategoryId = 1,
                    LoreId = (int?)3,
                    CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new
                {
                    Id = 4,
                    Name = "Worker Cat Speed Up",
                    PriceEuro = 4.99m,
                    Status = ItemAvailability.Active,
                    CategoryId = 2,
                    LoreId = (int?)4,
                    CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new
                {
                    Id = 5,
                    Name = "Attack Power Up Buff",
                    PriceEuro = 1.99m,
                    Status = ItemAvailability.Active,
                    CategoryId = 3,
                    LoreId = (int?)5,
                    CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new
                {
                    Id = 6,
                    Name = "Rare Cat Capsule",
                    PriceEuro = 7.99m,
                    Status = ItemAvailability.Active,
                    CategoryId = 4,
                    LoreId = (int?)6,
                    CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                }
            );

            // ============================================
            // 5) Изображения товаров (1:M)
            //    Один товар может иметь несколько картинок
            // ============================================
            modelBuilder.Entity<ProductImgData>().HasData(
                new ProductImgData { Id = 1, BattleItemId = 1, Url = "https://battlecats-db.com/img/unit/000/00/icon.png" },
                new ProductImgData { Id = 2, BattleItemId = 2, Url = "https://battlecats-db.com/img/unit/002/00/icon.png" },
                new ProductImgData { Id = 3, BattleItemId = 3, Url = "https://battlecats-db.com/img/unit/004/00/icon.png" },
                new ProductImgData { Id = 4, BattleItemId = 4, Url = "https://battlecats-db.com/img/items/speedup.png" },
                new ProductImgData { Id = 5, BattleItemId = 5, Url = "https://battlecats-db.com/img/items/buff.png" },
                new ProductImgData { Id = 6, BattleItemId = 6, Url = "https://battlecats-db.com/img/items/capsule.png" }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}