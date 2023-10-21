using ASP_DOTNET_CORE_WEB_API.Data;
using ASP_DOTNET_CORE_WEB_API.Models.Domain;
using ASP_DOTNET_CORE_WEB_API.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP_DOTNET_CORE_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerDataController : ControllerBase
    {
        public readonly PlayerDBContext dbContext;

        public PlayerDataController(PlayerDBContext playerDBContext) {
            dbContext = playerDBContext;
        }

        //Get All Player Data
        [HttpGet]
        public IActionResult GetAll() {
            var PlayerDatas = dbContext.playerDatas.ToList();
            List<PlayerDataDto> Dtos = new();

            foreach (var item in PlayerDatas)
            {
                Dtos.Add(new PlayerDataDto(item));
            }

            return Ok(Dtos);
        }

        //Get Single Player Data
        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetByID([FromRoute] Guid id) {
            var item = dbContext.playerDatas.Find(id);

            if (item == null) {
                return NotFound();
            }

            PlayerDataDto Dto = new PlayerDataDto(item);

            return Ok(Dto);
        }

        [HttpPost]
        public IActionResult CreatePlayerData([FromBody] PlayerDataDto item) {
            PlayerData playerData = new PlayerData(item);

            dbContext.playerDatas.Add(playerData);
            dbContext.SaveChanges();

            PlayerDataDto Dto = new PlayerDataDto(playerData);

            return CreatedAtAction(nameof(GetByID), new { id = Dto.Id}, Dto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult UpdatePlayerData([FromRoute] Guid id, [FromBody] PlayerDataDto Dto) {
            PlayerData item = null;

            if (!CanFindPlayerDataById(id, out item)) return NotFound();

            item.UpdateData(Dto);
            dbContext.SaveChanges();

            Dto = new PlayerDataDto(item);

            return Ok(Dto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult DeletePlayerData([FromRoute] Guid id) {
            PlayerData item = null;
            if (!CanFindPlayerDataById(id, out item)) return NotFound();

            dbContext.playerDatas.Remove(item);
            dbContext.SaveChanges();

            return Ok();
        }

        private bool CanFindPlayerDataById(Guid id, out PlayerData item) {
            item = dbContext.playerDatas.Find(id);
            return item != null;
        }
    }
}
