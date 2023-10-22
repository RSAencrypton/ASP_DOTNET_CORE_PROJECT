using ASP_DOTNET_CORE_WEB_API.Models.Domain;
using ASP_DOTNET_CORE_WEB_API.Models.Dtos;

namespace ASP_DOTNET_CORE_WEB_API.Repositories.IRepositoriesInterface
{
    public interface IPLayerDataRepositories
    {
        public Task<List<PlayerData>> GetAllPlayerDataAsync();
        public Task<PlayerData> GetSinglePlayerDataAsync(Guid id);
        public Task<PlayerData> CreatePlayerDataAsync(PlayerData playerData);
        public Task<PlayerData> UpdatePlayerDataAsync(Guid id, PlayerDataDto playerData);
        public Task<PlayerData> DeletePlayerDataAsync(Guid id);
    }
}
