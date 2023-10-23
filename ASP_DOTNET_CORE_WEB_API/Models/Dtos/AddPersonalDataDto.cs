using System.ComponentModel.DataAnnotations;

namespace ASP_DOTNET_CORE_WEB_API.Models.Dtos
{
    public class AddPersonalDataDto
    {

        [Required]
        public string? phone { get; set; }
        [Required]
        public string? email { get; set; }
    }
}
