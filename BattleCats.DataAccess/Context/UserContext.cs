using BattleCats.Domains.Entities.User;
using BattleCats.Domains.Enums;
using Microsoft.EntityFrameworkCore;

namespace BattleCats.DataAccess.Context
{
   
    public class UserContext : DbContext
    {
        public DbSet<UserData> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbSession.ConnectionStrings);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserData>().HasData(
                new UserData
                {
                    Id = 1,
                    UserName = "admin",
                    Password = "de2bbe3336efa2083a96e58558cd2137",   
                    Email = "admin@catbase.shop",
                    Contacts = "+373 22 000001",
                    DOB = new DateTime(1995, 1, 1),
                    Gender = GenderTypes.NotSpecified,
                    Role = UserRole.Admin
                },
                new UserData
                {
                    Id = 2,
                    UserName = "manager",
                    Password = "b975e0ef031a57d65816b20dab4baca8",   
                    Email = "manager@catbase.shop",
                    Contacts = "+373 22 000002",
                    DOB = new DateTime(1996, 6, 15),
                    Gender = GenderTypes.NotSpecified,
                    Role = UserRole.Manager
                },
                new UserData
                {
                    Id = 3,
                    UserName = "user",
                    Password = "3bc5f1df7c15c68d62b1afcde8d30918",   
                    Email = "user@catbase.shop",
                    Contacts = "+373 22 000003",
                    DOB = new DateTime(2000, 12, 25),
                    Gender = GenderTypes.NotSpecified,
                    Role = UserRole.User
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}