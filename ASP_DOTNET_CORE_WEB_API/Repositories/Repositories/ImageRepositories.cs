using ASP_DOTNET_CORE_WEB_API.Data;
using ASP_DOTNET_CORE_WEB_API.Models.Domain;
using ASP_DOTNET_CORE_WEB_API.Repositories.IRepositoriesInterface;

namespace ASP_DOTNET_CORE_WEB_API.Repositories.Repositories
{
    public class ImageRepositories : IUploadImageDataRepositories
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly PlayerDBContext playerDBContext;

        public ImageRepositories(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor,
            PlayerDBContext playerDBContext)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
            this.playerDBContext = playerDBContext;
        }
        public async Task<ImageData> UploadImage(ImageData item)
        {
            var localPath = Path.Combine(webHostEnvironment.ContentRootPath, "Image",
                $"{item.ImageName}{item.ImageExtension}");

            using var stream = new FileStream(localPath, FileMode.Create);
            await item.ImageFile.CopyToAsync(stream);

            var imageUrl = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{httpContextAccessor.HttpContext.Request.PathBase}/Image/{item.ImageName}{item.ImageExtension}";

            item.FilePath = imageUrl;

            await playerDBContext.imageDatas.AddAsync(item);
            await playerDBContext.SaveChangesAsync();

            return item;
        }
    }
}
