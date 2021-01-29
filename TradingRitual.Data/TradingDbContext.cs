using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TradingRitual.Entities.Models;

namespace TradingRitual.Data
{
    public class TradingDbContext : IdentityDbContext<ApplicationUser>
    {
        public TradingDbContext(DbContextOptions<TradingDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var roleId = Guid.NewGuid().ToString();
            var userId = Guid.NewGuid().ToString();

            builder.Entity<IdentityRole>().HasData(new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = roleId,
                    Name = "ADMIN",
                    NormalizedName = "ADMIN"
                }
            });

            var hasher = new PasswordHasher<ApplicationUser>();
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = userId,
                UserName = "admin@tradingritual.com",
                NormalizedUserName = "admin@tradingritual.com",
                Email = "admin@tradingritual.com",
                NormalizedEmail = "admin@tradingritual.com",
                FullName = "ADMIN",
                EmailConfirmed = true,
                LockoutEnabled = false,
                PasswordHash = hasher.HashPassword(null, "dejibus1_"),
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = roleId,
                UserId = userId
            });
        }
        DbSet<Profile> Profiles { get; set; }
        DbSet<Pair> Pairs { get; set; }
        DbSet<Strategy> Strategies { get; set; }
        DbSet<ExitStrategy> ExitStrategies { get; set; }
        DbSet<TradingHours> TradingHours { get; set; }
        DbSet<Form> Forms { get; set; }

    }
}
