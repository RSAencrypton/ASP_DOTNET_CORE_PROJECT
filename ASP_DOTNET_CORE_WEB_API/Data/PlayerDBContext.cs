using ASP_DOTNET_CORE_WEB_API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace ASP_DOTNET_CORE_WEB_API.Data
{
    public class PlayerDBContext : DbContext
    {
        public PlayerDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<AccountData> AccountDatas { get; set; }
        public DbSet<PlayerData> PlayerDatas { get; set; }
        public DbSet<PersonalData> PersonalDatas { get; set; }
    }
}
