using System.ComponentModel.DataAnnotations;

namespace ASP_DOTNET_CORE_WEB_API.Models.Dtos
{
    public class LoginDto
    {
        [Required]
        public string LoginName { get; set; }
        [Required]
        public string LoginPassword { get; set; }
    }
}
