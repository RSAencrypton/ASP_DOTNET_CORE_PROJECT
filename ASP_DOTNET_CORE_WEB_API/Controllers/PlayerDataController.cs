using ASP_DOTNET_CORE_WEB_API.Data;
using ASP_DOTNET_CORE_WEB_API.Models.Domain;
using ASP_DOTNET_CORE_WEB_API.Models.Dtos;
using ASP_DOTNET_CORE_WEB_API.Repositories.IRepositoriesInterface;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP_DOTNET_CORE_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PlayerDataController : ControllerBase
    {
        private readonly PlayerDBContext dbContext;
        private readonly IPLayerDataRepositories pLayerDataRepositories;
        private readonly IMapper mapper;

        public PlayerDataController(PlayerDBContext playerDBContext, IPLayerDataRepositories pLayerDataRepositories, IMapper mapper) {
            dbContext = playerDBContext;
            this.pLayerDataRepositories = pLayerDataRepositories;
            this.mapper = mapper;
        }

        //Get All Player Data
        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var PlayerDatas = await pLayerDataRepositories.GetAllPlayerDataAsync();

            var Dtos = mapper.Map<List<PlayerDataDto>>(PlayerDatas);

            return Ok(Dtos);
        }

        //Get Single Player Data
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetByID([FromRoute] Guid id) {
            var item = pLayerDataRepositories.GetSinglePlayerDataAsync(id);

            if (item == null) {
                return NotFound();
            }

            PlayerDataDto Dto = mapper.Map<PlayerDataDto>(item.Result);

            return Ok(Dto);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlayerData([FromBody] AddPLayerDataDto item) {
            PlayerData playerData = mapper.Map<PlayerData>(item);

            await pLayerDataRepositories.CreatePlayerDataAsync(playerData);

            PlayerDataDto Dto = mapper.Map<PlayerDataDto>(playerData);

            return CreatedAtAction(nameof(GetByID), new { id = Dto.Id}, Dto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdatePlayerData([FromRoute] Guid id, [FromBody] PlayerDataDto Dto) {
            PlayerData item = await pLayerDataRepositories.UpdatePlayerDataAsync(id, Dto);

            if (item == null) return NotFound();

            Dto = mapper.Map<PlayerDataDto>(item);

            return Ok(Dto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeletePlayerData([FromRoute] Guid id) {
            PlayerData item = await pLayerDataRepositories.DeletePlayerDataAsync(id);
            if (item == null) return NotFound();

            return item == null ? NotFound() : Ok();
        }

    }
}
