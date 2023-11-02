using ASP_DOTNET_CORE_WEB_API.CustomActionFilters;
using ASP_DOTNET_CORE_WEB_API.Models.Domain;
using ASP_DOTNET_CORE_WEB_API.Models.Dtos;
using ASP_DOTNET_CORE_WEB_API.Repositories.IRepositoriesInterface;

using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace ASP_DOTNET_CORE_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalDataController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IPersonalDataRepositories dataRepositories;
        private readonly ILogger<PersonalDataController> logger;

        public PersonalDataController(IMapper mapper, IPersonalDataRepositories dataRepositories, ILogger<PersonalDataController> logger)
        {
            this.mapper = mapper;
            this.dataRepositories = dataRepositories;
            this.logger = logger;
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

        [HttpGet]
        [ValidationActionAttributes]
        public async Task<IActionResult> GetDatabyFilter([FromQuery] string? FilterOn = null, [FromQuery] string? FilterQuery = null, [FromQuery] string? Sortedby = null, [FromQuery] bool? IsAscenting = false,
            [FromQuery] int PageNumber = 1, [FromQuery] int PageSize = 5) {
        
            var domain = dataRepositories.GetPersonalDataByFilter(FilterOn, FilterQuery, Sortedby, IsAscenting, PageNumber, PageSize);
            return Ok(mapper.Map<List<PersonalDataDto>>(domain.Result));
        }

        [HttpPost]
        [ValidationActionAttributes]
        public async Task<IActionResult> CreatePlayerData([FromBody] AddPersonalDataDto item)
        {

            PersonalData playerData = mapper.Map<PersonalData>(item);
            await dataRepositories.CreatePersonalData(playerData);
            PersonalData Dto = mapper.Map<PersonalData>(playerData);
            return CreatedAtAction(nameof(GetByID), new { id = Dto.Id }, Dto);

        }

    }
}
