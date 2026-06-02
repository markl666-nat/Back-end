using BattleCats.Domains.Entities.Order;
using Microsoft.EntityFrameworkCore;

namespace BattleCats.DataAccess.Context
{
    
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
            
            modelBuilder.Entity<OrderData>()
                .HasMany(o => o.Items)
                .WithOne(i => i.Order)
                .HasForeignKey(i => i.OrderId);
        }
    }
}