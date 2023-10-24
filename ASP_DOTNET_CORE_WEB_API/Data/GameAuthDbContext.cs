using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASP_DOTNET_CORE_WEB_API.Data
{
    public class GameAuthDbContext : IdentityDbContext
    {
        public GameAuthDbContext(DbContextOptions<GameAuthDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var roles = new List<IdentityRole> {
                new IdentityRole {
                    Id = "1ff69728-7893-4db1-b46a-a2b39e9f31d2",
                    ConcurrencyStamp = "1ff69728-7893-4db1-b46a-a2b39e9f31d2",
                    Name = "Jame",
                    NormalizedName = "Reader".ToUpper()

                },
                new IdentityRole {
                    Id = "12fffa66-9e3f-4725-81db-b0bfb80675bd",
                    ConcurrencyStamp = "12fffa66-9e3f-4725-81db-b0bfb80675bd",
                    Name = "Sam",
                    NormalizedName = "Writer".ToUpper()
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
