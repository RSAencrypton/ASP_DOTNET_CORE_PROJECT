using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_DOTNET_CORE_WEB_API.Models.Domain
{
    public class ImageData
    {

        public Guid Id { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }

        public string ImageName { get; set; }
        public string? ImageDescription { get; set; }
        public string ImageExtension { get; set; }
        public long ImageSize { get; set; }
        public string FilePath { get; set; }
    }
}
