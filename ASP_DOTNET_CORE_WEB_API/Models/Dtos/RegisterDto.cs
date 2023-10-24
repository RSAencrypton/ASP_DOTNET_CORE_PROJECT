using System.ComponentModel.DataAnnotations;

namespace ASP_DOTNET_CORE_WEB_API.Models.Dtos
{
    public class RegisterDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
