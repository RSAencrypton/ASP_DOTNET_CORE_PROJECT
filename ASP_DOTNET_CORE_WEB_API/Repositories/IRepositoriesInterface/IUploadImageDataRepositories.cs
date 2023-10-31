using ASP_DOTNET_CORE_WEB_API.Models.Domain;

namespace ASP_DOTNET_CORE_WEB_API.Repositories.IRepositoriesInterface
{
    public interface IUploadImageDataRepositories
    {
        public Task<ImageData> UploadImage(ImageData item);
    }
}
