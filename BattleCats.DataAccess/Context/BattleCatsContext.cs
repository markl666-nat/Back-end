using BattleCatsStore.Domains.Entities.Products;
using BattleCatsStore.Domains.Enums;
using BattleCats.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace BattleCatsStore.DataAccess.Context
{
    public class BattleCatsContext : DbContext
    {
        // Переименовали таблицы под игровую тематику
        public DbSet<BattleItem> Inventory { get; set; }
        public DbSet<ItemAsset> Assets { get; set; }
        public DbSet<ItemCategory> Groups { get; set; }
        public DbSet<BattleItemLore> Lore { get; set; }
        public DbSet<CombatStats> UnitStats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Ссылка на строку подключения остается прежней
            optionsBuilder.UseSqlServer(DbSession.ConnectionStrings);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1. Сеем Категории (Группы товаров)
            modelBuilder.Entity<ItemCategory>().HasData(
                new ItemCategory { CategoryId = 1, Title = "Battle Cats (Units)" },
                new ItemCategory { CategoryId = 2, Title = "Power-Ups & Buffs" },
                new ItemCategory { CategoryId = 3, Title = "Official Merchandise" }
            );

            // 2. Сеем Характеристики (HP, Attack, Range)
            modelBuilder.Entity<CombatStats>().HasData(
                new CombatStats { Id = 1, HP = 100, Attack = 8, Range = 140 }, // Для Basic Cat
                new CombatStats { Id = 2, HP = 4000, Attack = 1500, Range = 450 } // Для Uber Rare
            );

            // 3. Сеем Лор (Описания из игры)
            modelBuilder.Entity<BattleItemLore>().HasData(
                new BattleItemLore { LoreId = 1, FlavorText = "A low-cost unit that's easy to produce. Not very strong, but has a lot of heart.", CombatStatsId = 1 },
                new BattleItemLore { LoreId = 2, FlavorText = "A legendary warrior from a distant land. His heavy artillery wipes out everything.", CombatStatsId = 2 }
            );

            // 4. Сеем самих Котов и товары
            modelBuilder.Entity<BattleItem>().HasData(
                new BattleItem
                {
                    InternalId = 1,
                    ItemName = "Basic Cat",
                    CatFoodPrice = 50,
                    CategoryId = 1,
                    RarityTier = "Normal",
                    StockStatus = ItemAvailability.Available
                },
                new BattleItem
                {
                    InternalId = 2,
                    ItemName = "Kasa Jizo",
                    CatFoodPrice = 750,
                    CategoryId = 1,
                    RarityTier = "Uber Super Rare",
                    StockStatus = ItemAvailability.EventExclusive
                }
            );

            // 5. Сеем Ассеты (Изображения)
            modelBuilder.Entity<ItemAsset>().HasData(
                new ItemAsset { Id = 1, Url = "basic_cat_sprite.png", ProductId = 1 },
                new ItemAsset { Id = 2, Url = "jizo_moving_form.png", ProductId = 2 }
            );
        }
    }
}