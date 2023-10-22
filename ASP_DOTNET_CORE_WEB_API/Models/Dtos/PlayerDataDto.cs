using ASP_DOTNET_CORE_WEB_API.Models.Domain;

namespace ASP_DOTNET_CORE_WEB_API.Models.Dtos
{
    public class PlayerDataDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int Exp { get; set; }
        public int Money { get; set; }

        public PlayerDataDto() { }
    }
}
