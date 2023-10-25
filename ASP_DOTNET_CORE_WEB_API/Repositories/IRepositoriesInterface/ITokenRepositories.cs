using Microsoft.AspNetCore.Identity;

namespace ASP_DOTNET_CORE_WEB_API.Repositories.IRepositoriesInterface
{
    public interface ITokenRepositories
    {
        public string CreateJWToken(IdentityUser identityUser, List<string> roles);
    }
}
