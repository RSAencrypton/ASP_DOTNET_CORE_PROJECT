using ASP_DOTNET_CORE_WEB_API.Models.Domain;

namespace ASP_DOTNET_CORE_WEB_API.Repositories.IRepositoriesInterface
{
    public interface IPersonalDataRepositories
    {
        public Task<PersonalData> CreatePersonalData(PersonalData item);
        public Task<PersonalData> GetPersonalDataByID(Guid id);
        public Task<List<PersonalData>> GetPersonalDataByFilter(string? FilterOn, string? FilterQuery, string? Sortedby, bool? IsAscenting, int PageNumber, int PageSize);
    }
}
