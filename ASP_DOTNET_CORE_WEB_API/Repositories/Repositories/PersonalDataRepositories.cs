using ASP_DOTNET_CORE_WEB_API.Data;
using ASP_DOTNET_CORE_WEB_API.Models.Domain;
using ASP_DOTNET_CORE_WEB_API.Repositories.IRepositoriesInterface;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

        public Task<List<PersonalData>> GetPersonalDataByFilter(string? FilterOn, string? FilterQuery, string? Sortedby = null, bool? IsAscenting = false, int PageNumber = 1, int PageSize = 5)
        {
            var domain = dbContext.PersonalDatas.AsQueryable();

            if (!string.IsNullOrWhiteSpace(FilterOn) && !string.IsNullOrWhiteSpace(FilterQuery)) {
                if (FilterOn.Equals("phone", StringComparison.OrdinalIgnoreCase)) {
                    domain = domain.Where(x=>x.phone.Contains(FilterQuery));
                }
            }

            if (!string.IsNullOrWhiteSpace(Sortedby)) {
                if (Sortedby.Equals("phone", StringComparison.OrdinalIgnoreCase)) {
                    domain = IsAscenting.Value ? domain.OrderBy(x => x.phone) : domain.OrderByDescending(x => x.phone);
                }
            }

            int SkipNumber = (PageNumber - 1) * PageSize;

            return domain.Skip(SkipNumber).Take(PageSize).ToListAsync();
        }

        public async Task<PersonalData> GetPersonalDataByID(Guid id)
        {
            return await dbContext.PersonalDatas.FindAsync(id);
        }

        
    }
}
