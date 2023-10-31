using System.ComponentModel.DataAnnotations;

namespace ASP_DOTNET_CORE_WEB_API.Models.Dtos
{
    public class ImageUploadDto
    {
        [Required]
        public IFormFile ImageFile { get; set; }
        [Required]
        public string ImageName { get; set; }
        public string? ImageDescription { get; set; }
    }
}
