using BattleCats.Domains.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace BattleCats.DataAccess.Context
{
    /// <summary>
    /// Контекст БД для пользователей сайта Cat Base Shop.
    /// Управляет одной сущностью — UserData (учётная запись пользователя).
    /// 
    /// Намеренно отделён от ProductContext (как у препода в eUShop):
    /// это позволяет независимо управлять схемой пользователей
    /// и схемой товаров, что упрощает миграции и развёртывание.
    /// </summary>
    public class UserContext : DbContext
    {
        public DbSet<UserData> Users { get; set; }

        /// <summary>
        /// Конфигурация подключения к SQL Server для пользователей.
        /// Connection string хранится в DbSession.cs.
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbSession.ConnectionStrings);
        }
    }
}