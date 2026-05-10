using BattleCats.Domains.Entities.Product;
using BattleCats.Domains.Enums;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbSession.ConnectionStrings);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ============================================
            // 1) Категории — 4 фиксированные
            // ============================================
            modelBuilder.Entity<ItemCategory>().HasData(
                new ItemCategory { Id = 1, Name = "Cat Units" },
                new ItemCategory { Id = 2, Name = "Base Upgrades" },
                new ItemCategory { Id = 3, Name = "Buffs" },
                new ItemCategory { Id = 4, Name = "Gacha" }
            );

            // ============================================
            // 2) Расширенные характеристики — для каждого Cat Unit свои статы
            // ============================================
            modelBuilder.Entity<DescriptionAdvanced>().HasData(
                new DescriptionAdvanced { Id = 1, Health = 1500, Attack = 250, Range = 140 },     // Slime Cat
                new DescriptionAdvanced { Id = 2, Health = 4500, Attack = 600, Range = 100 },     // Courier
                new DescriptionAdvanced { Id = 3, Health = 2200, Attack = 480, Range = 380 },     // Kasli
                new DescriptionAdvanced { Id = 4, Health = 3200, Attack = 720, Range = 290 },     // D'artanyan
                new DescriptionAdvanced { Id = 5, Health = 5800, Attack = 1100, Range = 350 },    // D'arktanyan
                new DescriptionAdvanced { Id = 6, Health = 4100, Attack = 950, Range = 270 },     // Kaoru
                new DescriptionAdvanced { Id = 7, Health = 6500, Attack = 1300, Range = 410 },    // Phono
                new DescriptionAdvanced { Id = 8, Health = 1800, Attack = 360, Range = 220 },     // Crazy Baozi
                new DescriptionAdvanced { Id = 9, Health = 9999, Attack = 1500, Range = 480 },    // Gamatoto
                new DescriptionAdvanced { Id = 10, Health = 2400, Attack = 420, Range = 260 },    // Legeluga
                new DescriptionAdvanced { Id = 11, Health = 3300, Attack = 660, Range = 240 },    // Pikotaro
                new DescriptionAdvanced { Id = 12, Health = 1600, Attack = 280, Range = 130 }     // Squire Luno
            );

            // ============================================
            // 3) Lore — описания всех товаров
            // ============================================
            modelBuilder.Entity<BattleItemLore>()
                .HasOne(l => l.DescriptionAdvanced)
                .WithMany()
                .HasForeignKey("DescriptionAdvancedId")
                .IsRequired(false);

            modelBuilder.Entity<BattleItemLore>().HasData(
                // ===== Cat Units =====
                new { Id = 1, Description = "Желейный кот-новобранец. Мягкий снаружи, крепкий внутри. Растворяет врагов кислотой и быстро регенерирует.", DescriptionAdvancedId = (int?)1 },
                new { Id = 2, Description = "Бесстрашный курьер с танковой бронёй. Доставляет посылки прямо на поле боя и поглощает удары.", DescriptionAdvancedId = (int?)2 },
                new { Id = 3, Description = "Касли — проклятие на двух лапах. Снайпер с магическим уроном по площади из глубокого тыла.", DescriptionAdvancedId = (int?)3 },
                new { Id = 7, Description = "Изящный фехтовальщик в плаще и шляпе. Стремителен и точен, словно D'Artagnan из мушкетёров.", DescriptionAdvancedId = (int?)4 },
                new { Id = 8, Description = "Тёмная эволюция D'artanyan'а. Облачён в чёрные доспехи с синим свечением, режет насквозь.", DescriptionAdvancedId = (int?)5 },
                new { Id = 9, Description = "Каору Ханаяма — мастер боевых искусств. Один удар кулака способен сокрушить целые армии.", DescriptionAdvancedId = (int?)6 },
                new { Id = 11, Description = "Король Судьбы Phono. Громовая ярость, разрушающая всё на пути. Электрический урон с большой дальностью.", DescriptionAdvancedId = (int?)7 },
                new { Id = 13, Description = "Безумный пельмень-кот (Crazy Baozi). Прыгает на врагов с пугающей радостью. Дешёвый и быстрый.", DescriptionAdvancedId = (int?)8 },
                new { Id = 14, Description = "Гаматото — гигантский исследовательский кот. Не атакует, но откапывает ресурсы и редкие предметы.", DescriptionAdvancedId = (int?)9 },
                new { Id = 15, Description = "Легелуга. Фигуристка-кот с ледяной грацией и колкими атаками. Замораживает врагов.", DescriptionAdvancedId = (int?)10 },
                new { Id = 16, Description = "Pen-Pineapple-Apple-Pen Cat. Простая мелодия — мощное оружие. Стильный, но смертельный.", DescriptionAdvancedId = (int?)11 },
                new { Id = 17, Description = "Сквайр Луно — благородный молодой воин на службе ночи. Защищает базу от теней.", DescriptionAdvancedId = (int?)12 },
                // ===== Base Upgrades =====
                new { Id = 19, Description = "Breakerblast Base — пушка-разрушитель на крыше базы. Бьёт по дальним целям мощным взрывом.", DescriptionAdvancedId = (int?)null },
                new { Id = 20, Description = "Стандартное укрепление базы. Простое, дешёвое, эффективное против лёгких атак противника.", DescriptionAdvancedId = (int?)null },
                new { Id = 21, Description = "Громовая база. Электрическая турель, парализующая врагов на подступах разрядами молний.", DescriptionAdvancedId = (int?)null },
                // ===== Buffs =====
                new { Id = 22, Description = "Cat Combo Pewpewpew. Стартовая мощь Cat Cannon усилена на старте боя — бьёт чаще и больнее.", DescriptionAdvancedId = (int?)null },
                new { Id = 23, Description = "Cat Combo Dragon Slayer. Massive Damage против Red, Floating и Angel врагов. Незаменимо в поздней игре.", DescriptionAdvancedId = (int?)null },
                // ===== Gacha =====
                new { Id = 24, Description = "Золотая капсула. Гарантирует юнита Super Rare или выше. Шанс на Uber Rare значительно повышен.", DescriptionAdvancedId = (int?)null },
                new { Id = 25, Description = "Обычная капсула. Случайный кот стандартной редкости. Шанс на Rare — небольшой, но реальный.", DescriptionAdvancedId = (int?)null }
            );

            // ============================================
            // 4) Сами товары — 19 уникальных штук
            // ============================================
            modelBuilder.Entity<BattleItem>()
                .HasOne(b => b.Category)
                .WithMany()
                .IsRequired();

            modelBuilder.Entity<BattleItem>()
                .HasOne(b => b.Lore)
                .WithMany()
                .IsRequired(false);

            var seedDate = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            modelBuilder.Entity<BattleItem>().HasData(
                // ===== Cat Units (12 штук) =====
                new { Id = 1, Name = "Slime Cat", PriceEuro = 1.49m, Status = ItemAvailability.Active, CategoryId = 1, LoreId = (int?)1, CreatedAt = seedDate, UpdatedAt = seedDate },
                new { Id = 2, Name = "Courier Cat", PriceEuro = 3.49m, Status = ItemAvailability.Active, CategoryId = 1, LoreId = (int?)2, CreatedAt = seedDate, UpdatedAt = seedDate },
                new { Id = 3, Name = "Kasli the Bane", PriceEuro = 7.49m, Status = ItemAvailability.Active, CategoryId = 1, LoreId = (int?)3, CreatedAt = seedDate, UpdatedAt = seedDate },
                new { Id = 7, Name = "D'artanyan", PriceEuro = 5.99m, Status = ItemAvailability.Active, CategoryId = 1, LoreId = (int?)7, CreatedAt = seedDate, UpdatedAt = seedDate },
                new { Id = 8, Name = "D'arktanyan", PriceEuro = 9.99m, Status = ItemAvailability.Active, CategoryId = 1, LoreId = (int?)8, CreatedAt = seedDate, UpdatedAt = seedDate },
                new { Id = 9, Name = "Kaoru Hanayama", PriceEuro = 8.49m, Status = ItemAvailability.Active, CategoryId = 1, LoreId = (int?)9, CreatedAt = seedDate, UpdatedAt = seedDate },
                new { Id = 11, Name = "King of Doom Phono", PriceEuro = 12.99m, Status = ItemAvailability.Active, CategoryId = 1, LoreId = (int?)11, CreatedAt = seedDate, UpdatedAt = seedDate },
                new { Id = 13, Name = "Crazy Baozi Cat", PriceEuro = 1.99m, Status = ItemAvailability.Active, CategoryId = 1, LoreId = (int?)13, CreatedAt = seedDate, UpdatedAt = seedDate },
                new { Id = 14, Name = "Gamatoto", PriceEuro = 6.99m, Status = ItemAvailability.Active, CategoryId = 1, LoreId = (int?)14, CreatedAt = seedDate, UpdatedAt = seedDate },
                new { Id = 15, Name = "Legeluga", PriceEuro = 4.49m, Status = ItemAvailability.Active, CategoryId = 1, LoreId = (int?)15, CreatedAt = seedDate, UpdatedAt = seedDate },
                new { Id = 16, Name = "Pikotaro", PriceEuro = 2.99m, Status = ItemAvailability.Active, CategoryId = 1, LoreId = (int?)16, CreatedAt = seedDate, UpdatedAt = seedDate },
                new { Id = 17, Name = "Squire Luno", PriceEuro = 5.49m, Status = ItemAvailability.Active, CategoryId = 1, LoreId = (int?)17, CreatedAt = seedDate, UpdatedAt = seedDate },
                // ===== Base Upgrades (3 штуки) =====
                new { Id = 19, Name = "Breakerblast Base", PriceEuro = 6.99m, Status = ItemAvailability.Active, CategoryId = 2, LoreId = (int?)19, CreatedAt = seedDate, UpdatedAt = seedDate },
                new { Id = 20, Name = "Default Base", PriceEuro = 0.99m, Status = ItemAvailability.Active, CategoryId = 2, LoreId = (int?)20, CreatedAt = seedDate, UpdatedAt = seedDate },
                new { Id = 21, Name = "Thunderbolt Base", PriceEuro = 8.99m, Status = ItemAvailability.Active, CategoryId = 2, LoreId = (int?)21, CreatedAt = seedDate, UpdatedAt = seedDate },
                // ===== Buffs (2 штуки) =====
                new { Id = 22, Name = "Cat Combo: Pewpewpew!", PriceEuro = 2.49m, Status = ItemAvailability.Active, CategoryId = 3, LoreId = (int?)22, CreatedAt = seedDate, UpdatedAt = seedDate },
                new { Id = 23, Name = "Cat Combo: Dragon Slayer", PriceEuro = 3.99m, Status = ItemAvailability.Active, CategoryId = 3, LoreId = (int?)23, CreatedAt = seedDate, UpdatedAt = seedDate },
                // ===== Gacha (2 штуки) =====
                new { Id = 24, Name = "Gold Gacha Capsule", PriceEuro = 14.99m, Status = ItemAvailability.Active, CategoryId = 4, LoreId = (int?)24, CreatedAt = seedDate, UpdatedAt = seedDate },
                new { Id = 25, Name = "Normal Gacha Capsule", PriceEuro = 2.99m, Status = ItemAvailability.Active, CategoryId = 4, LoreId = (int?)25, CreatedAt = seedDate, UpdatedAt = seedDate }
            );

            // ============================================
            // 5) Изображения — все локальные, лежат в public/images/cats/ фронтенда
            // ============================================
            modelBuilder.Entity<ProductImgData>().HasData(
                // Cat Units
                new ProductImgData { Id = 1, BattleItemId = 1, Url = "/images/cats/slime_cat.jpg" },
                new ProductImgData { Id = 2, BattleItemId = 2, Url = "/images/cats/courier_cat.jpg" },
                new ProductImgData { Id = 3, BattleItemId = 3, Url = "/images/cats/Kasli_the_Bane.jpg" },
                new ProductImgData { Id = 7, BattleItemId = 7, Url = "/images/cats/D_artanyan.jpg" },
                new ProductImgData { Id = 8, BattleItemId = 8, Url = "/images/cats/D_arktanyan.jpg" },
                new ProductImgData { Id = 9, BattleItemId = 9, Url = "/images/cats/Kaoru_Hanayama.jpg" },
                new ProductImgData { Id = 11, BattleItemId = 11, Url = "/images/cats/King_of_Doom_Phono.jpg" },
                new ProductImgData { Id = 13, BattleItemId = 13, Url = "/images/cats/crazy_baozi_cat.jpg" },
                new ProductImgData { Id = 14, BattleItemId = 14, Url = "/images/cats/gamatoto.jpg" },
                new ProductImgData { Id = 15, BattleItemId = 15, Url = "/images/cats/legeluga.jpg" },
                new ProductImgData { Id = 16, BattleItemId = 16, Url = "/images/cats/pikotaro.jpg" },
                new ProductImgData { Id = 17, BattleItemId = 17, Url = "/images/cats/squire_luno.jpg" },
                // Base Upgrades
                new ProductImgData { Id = 19, BattleItemId = 19, Url = "/images/cats/breakerblast_base.jpg" },
                new ProductImgData { Id = 20, BattleItemId = 20, Url = "/images/cats/default_base.jpg" },
                new ProductImgData { Id = 21, BattleItemId = 21, Url = "/images/cats/thunderbolt_base.jpg" },
                // Buffs
                new ProductImgData { Id = 22, BattleItemId = 22, Url = "/images/cats/catcombo_buff_1.jpg" },
                new ProductImgData { Id = 23, BattleItemId = 23, Url = "/images/cats/catcombo_buff_2.jpg" },
                // Gacha
                new ProductImgData { Id = 24, BattleItemId = 24, Url = "/images/cats/gold_gacha.jpg" },
                new ProductImgData { Id = 25, BattleItemId = 25, Url = "/images/cats/normal_gacha.jpg" }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}