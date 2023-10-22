using ASP_DOTNET_CORE_WEB_API.Models.Domain;
using ASP_DOTNET_CORE_WEB_API.Models.Dtos;
using ASP_DOTNET_CORE_WEB_API.Repositories.IRepositoriesInterface;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP_DOTNET_CORE_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalDataController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IPersonalDataRepositories dataRepositories;

        public PersonalDataController(IMapper mapper, IPersonalDataRepositories dataRepositories)
        {
            this.mapper = mapper;
            this.dataRepositories = dataRepositories;
        }

        //Get Single Player Data
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetByID([FromRoute] Guid id)
        {
            var item = dataRepositories.GetPersonalDataByID(id);

            if (item == null)
            {
                return NotFound();
            }

            PersonalDataDto Dto = mapper.Map<PersonalDataDto>(item.Result);
            return Ok(Dto);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlayerData([FromBody] AddPersonalDataDto item)
        {
            PersonalData playerData = mapper.Map<PersonalData>(item);

            await dataRepositories.CreatePersonalData(playerData);

            PersonalData Dto = mapper.Map<PersonalData>(playerData);

            return CreatedAtAction(nameof(GetByID), new { id = Dto.Id }, Dto);
        }

    }
}
