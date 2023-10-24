using ASP_DOTNET_CORE_WEB_API.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ASP_DOTNET_CORE_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;

        public AuthController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> RegisterAccount([FromBody] RegisterDto registerInfo) {
            var identityUser = new IdentityUser {
                UserName = registerInfo.Username
            };

            var identityResult = await userManager.CreateAsync(identityUser, registerInfo.Password);

            if (identityResult.Succeeded) {
                identityResult = await userManager.AddToRoleAsync(identityUser, registerInfo.Role);

                if (identityResult.Succeeded) return Ok("Create User Successfully!!!");
            }

            return BadRequest("Create User Failed");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginAccount([FromBody] LoginDto loginInfo) {
            var user = await userManager.FindByNameAsync(loginInfo.LoginName);

            if (user != null) {
                bool res = await userManager.CheckPasswordAsync(user,loginInfo.LoginPassword);

                if (res) return Ok("successfully log in");
            }

            return BadRequest("Wrong account name or password");
        }
    }
}
