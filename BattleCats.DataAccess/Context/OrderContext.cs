using BattleCats.Domains.Entities.Order;
using Microsoft.EntityFrameworkCore;

namespace BattleCats.DataAccess.Context
{
    /// <summary>
    /// Контекст БД для заказов Cat Base Shop.
    /// Управляет двумя сущностями: OrderData (заказ) и OrderItemData (позиция в заказе).
    /// 
    /// Связь 1:N (Order → Items) настроена через Fluent API в OnModelCreating
    /// согласно презентации препода (Настройка отношений в EF Core).
    /// </summary>
    public class OrderContext : DbContext
    {
        public DbSet<OrderData> Orders { get; set; } = null!;
        public DbSet<OrderItemData> Items { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbSession.ConnectionStrings);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 1:N — у одного заказа много позиций
            modelBuilder.Entity<OrderData>()
                .HasMany(o => o.Items)
                .WithOne(i => i.Order)
                .HasForeignKey(i => i.OrderId);
        }
    }
}