using System.ComponentModel.DataAnnotations;

namespace ASP_DOTNET_CORE_WEB_API.Models.Dtos
{
    public class PersonalDataDto
    {
        [Required]
        public Guid id { get; set; }
        [Required]
        public string? phone { get; set; }
        [Required]
        public string? email { get; set; }
    }
}
