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

        public PlayerDataDto(Guid id, string name, int level, int exp, int money)
        {
            Id = id;
            Name = name;
            Level = level;
            Exp = exp;
            Money = money;
        }

        public PlayerDataDto(PlayerData item) {
            Id = item.Id;
            Name = item.Name;
            Level = item.Level;
            Exp = item.Exp;
            Money = item.Money;
        }
    }
}
