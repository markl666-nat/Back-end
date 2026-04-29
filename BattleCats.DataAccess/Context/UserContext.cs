using BattleCats.Domains.Entities.Product;
using BattleCats.Domains.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace BattleCats.DataAccess.Context
{
    public class UserContext : DbContext
    {   
        public DbSet<UserData> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbSession.ConnectionStrings);
        }
    }
}
