using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP_DOTNET_CORE_WEB_API.Controllers
{

    //http://localhost:port/api/students
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        //GET: http://localhost:port/api/students
        [HttpGet]
        public IActionResult GetAllSutedents() {
            string[] strings = {"Alice", "Bob", "Jerry" };

            return Ok(strings);
        }
    }
}
