using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASP_DOTNET_CORE_WEB_API.Models.Dtos;
using AutoMapper;
using ASP_DOTNET_CORE_WEB_API.Repositories.IRepositoriesInterface;
using ASP_DOTNET_CORE_WEB_API.Models.Domain;

namespace ASP_DOTNET_CORE_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IAccountDataRepositories dataRepositories;

        public AccountController(IMapper mapper, IAccountDataRepositories dataRepositories) {
            this.mapper = mapper;
            this.dataRepositories = dataRepositories;
        }



        [HttpPost]
        public async Task<IActionResult> CreateAccountAsync([FromBody] AccountDto item) {
            var data = mapper.Map<AccountData>(item);

            await dataRepositories.CreateAccountAsync(data);

            return Ok(mapper.Map<AccountDto>(data));
        }
    }
}
