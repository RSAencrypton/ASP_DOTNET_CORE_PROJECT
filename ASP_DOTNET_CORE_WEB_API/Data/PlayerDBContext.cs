using ASP_DOTNET_CORE_WEB_API.Models.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASP_DOTNET_CORE_WEB_API.Data
{
    public class PlayerDBContext : DbContext
    {
        public PlayerDBContext(DbContextOptions<PlayerDBContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<AccountData> AccountDatas { get; set; }
        public DbSet<PlayerData> PlayerDatas { get; set; }
        public DbSet<PersonalData> PersonalDatas { get; set; }
        public DbSet<ImageData> imageDatas { get; set; }
    }
}
