using ContactBookModel.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ContactBookData.DbContext
{
    public class GemDbContext : IdentityDbContext<User>
    {
        public GemDbContext(DbContextOptions<GemDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedRoles(builder);
        }
        public static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData
                (
                  new IdentityRole() { Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                  new IdentityRole() { Name = "Regular", ConcurrencyStamp = "2", NormalizedName = "Regular" }
                );
        }
    }
}