using ASP_DOTNET_CORE_WEB_API.Models.Domain;
using ASP_DOTNET_CORE_WEB_API.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ASP_DOTNET_CORE_WEB_API.Repositories.IRepositoriesInterface
{
    public interface IAccountDataRepositories
    {
        public Task<AccountData> CreateAccountAsync(AccountData item);
        public Task<List<AccountData>> SearchAllAccountDataAsync();
        public Task<AccountData> SearchAccountAsync(Guid id);
        public Task<AccountData> UpdateAccountAsync(Guid id,  AccountData item);
        public Task<AccountData> DeleteAccountAsync(Guid id);
    }
}
