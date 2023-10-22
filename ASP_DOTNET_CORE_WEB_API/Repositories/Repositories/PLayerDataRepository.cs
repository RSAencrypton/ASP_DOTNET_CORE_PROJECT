using ASP_DOTNET_CORE_WEB_API.Data;
using ASP_DOTNET_CORE_WEB_API.Models.Domain;
using ASP_DOTNET_CORE_WEB_API.Models.Dtos;
using ASP_DOTNET_CORE_WEB_API.Repositories.IRepositoriesInterface;
using Microsoft.EntityFrameworkCore;

namespace ASP_DOTNET_CORE_WEB_API.Repositories.Repositories
{
    public class PLayerDataRepository : IPLayerDataRepositories
    {
        public readonly PlayerDBContext dbContext;
        public PLayerDataRepository(PlayerDBContext dBContext)
        {
            dbContext = dBContext;
        }

        public async Task<PlayerData> CreatePlayerDataAsync(PlayerData playerData)
        {
            await dbContext.PlayerDatas.AddAsync(playerData);
            await dbContext.SaveChangesAsync();

            return playerData;
        }

        public async Task<PlayerData> DeletePlayerDataAsync(Guid id)
        {
            var item = await GetSinglePlayerDataAsync(id);

            if (item == null) return null;

            dbContext.PlayerDatas.Remove(item);
            await dbContext.SaveChangesAsync();

            return item;
        }

        public async Task<List<PlayerData>> GetAllPlayerDataAsync()
        {
            return await dbContext.PlayerDatas.ToListAsync();
        }

        public async Task<PlayerData?> GetSinglePlayerDataAsync(Guid id)
        {
            return await dbContext.PlayerDatas.FindAsync(id);
        }

        public async Task<PlayerData> UpdatePlayerDataAsync(Guid id, PlayerDataDto playerData)
        {
            PlayerData item = await GetSinglePlayerDataAsync(id);

            if (item == null) return null;
            item.Name = playerData.Name;
            item.Exp = playerData.Exp;
            item.Level = playerData.Level;
            item.Money = playerData.Money;
            await dbContext.SaveChangesAsync();

            return item;
        }
    }
}
