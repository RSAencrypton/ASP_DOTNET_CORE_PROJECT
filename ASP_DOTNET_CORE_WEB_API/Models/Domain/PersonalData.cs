using System.ComponentModel.DataAnnotations;

namespace ASP_DOTNET_CORE_WEB_API.Models.Domain
{
    public class PersonalData
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string? phone { get; set; }

        [Required]
        public string? email { get; set; }
    }
}
