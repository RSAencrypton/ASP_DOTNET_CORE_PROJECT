using ASP_DOTNET_CORE_WEB_API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace ASP_DOTNET_CORE_WEB_API.Data
{
    public class PlayerDBContext : DbContext
    {
        public PlayerDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<AccountData> accountDatas { get; set; }
        public DbSet<PlayerData> playerDatas { get; set; }
        public DbSet<PersonalData> personalDatas { get; set; }
    }
}
