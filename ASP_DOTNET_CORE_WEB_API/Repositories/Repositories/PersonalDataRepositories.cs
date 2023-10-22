using ASP_DOTNET_CORE_WEB_API.Data;
using ASP_DOTNET_CORE_WEB_API.Models.Domain;
using ASP_DOTNET_CORE_WEB_API.Repositories.IRepositoriesInterface;

namespace ASP_DOTNET_CORE_WEB_API.Repositories.Repositories
{
    public class PersonalDataRepositories : IPersonalDataRepositories
    {
        private readonly PlayerDBContext dbContext;

        public PersonalDataRepositories(PlayerDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<PersonalData> CreatePersonalData(PersonalData item)
        {
            await dbContext.PersonalDatas.AddAsync(item);
            await dbContext.SaveChangesAsync();

            return item;
        }

        public async Task<PersonalData> GetPersonalDataByID(Guid id)
        {
            return await dbContext.PersonalDatas.FindAsync(id);
        }
    }
}
