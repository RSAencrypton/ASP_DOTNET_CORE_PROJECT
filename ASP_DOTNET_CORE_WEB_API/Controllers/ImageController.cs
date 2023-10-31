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
    public class ImageController : ControllerBase
    {
        private readonly IUploadImageDataRepositories dataRepositories;
        private readonly IMapper mapper;

        public ImageController(IUploadImageDataRepositories dataRepositories, IMapper mapper)
        {
            this.dataRepositories = dataRepositories;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("Upload_Image")]
        public async Task<IActionResult> UploadImage([FromForm] ImageUploadDto item) 
        {
            CanBeUpload(item);

            if (ModelState.IsValid) {
                var domain = mapper.Map<ImageData>(item);
                await dataRepositories.UploadImage(domain);

                return Ok(domain);
            }

            return BadRequest(ModelState);
        }

        private void CanBeUpload(ImageUploadDto item) {
            var uploadList = new string[] { ".jpg", ".jpeg", ".png" };

            if (!uploadList.Contains(Path.GetExtension(item.ImageFile.FileName)))
            {
                ModelState.AddModelError("file", "Unsupported file extension");
            }

            if (item.ImageFile.Length > 10485760) {
                ModelState.AddModelError("size", "File is too large");
            }
        }
    }
}
