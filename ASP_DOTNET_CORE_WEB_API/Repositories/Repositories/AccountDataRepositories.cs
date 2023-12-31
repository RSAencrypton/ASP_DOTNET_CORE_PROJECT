﻿using ASP_DOTNET_CORE_WEB_API.Data;
using ASP_DOTNET_CORE_WEB_API.Models.Domain;
using ASP_DOTNET_CORE_WEB_API.Models.Dtos;
using ASP_DOTNET_CORE_WEB_API.Repositories.IRepositoriesInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP_DOTNET_CORE_WEB_API.Repositories.Repositories
{
    public class AccountDataRepositories : IAccountDataRepositories
    {
        private readonly PlayerDBContext dBContext;

        public AccountDataRepositories(PlayerDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public async Task<AccountData> CreateAccountAsync(AccountData item)
        {
            await dBContext.AccountDatas.AddAsync(item);
            await dBContext.SaveChangesAsync();

            return item;
        }

        public async Task<List<AccountData>> SearchAllAccountDataAsync() {
            return await dBContext.AccountDatas.Include(x=>x.PlayerData).Include(x=>x.PersonalData).ToListAsync();
        }

        public Task<AccountData> DeleteAccountAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<AccountData> SearchAccountAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<AccountData> UpdateAccountAsync(Guid id, AccountData item)
        {
            throw new NotImplementedException();
        }
    }
}
