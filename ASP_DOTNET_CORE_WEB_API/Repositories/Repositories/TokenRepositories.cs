using ASP_DOTNET_CORE_WEB_API.Repositories.IRepositoriesInterface;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ASP_DOTNET_CORE_WEB_API.Repositories.Repositories
{
    public class TokenRepositories : ITokenRepositories
    {
        private readonly IConfiguration configuration;

        public TokenRepositories(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string CreateJWToken(IdentityUser identityUser, List<string> roles)
        {
            var claims = new List<Claim> {
                new Claim(ClaimTypes.Name,identityUser.UserName)
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
