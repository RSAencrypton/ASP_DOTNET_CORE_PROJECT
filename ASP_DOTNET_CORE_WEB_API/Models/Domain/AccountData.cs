using ASP_DOTNET_CORE_WEB_API.Models.Dtos;

namespace ASP_DOTNET_CORE_WEB_API.Models.Domain
{
    public class AccountData
    {
        public Guid Id { get; set; }
        public string UserAccount { get; set; }
        public string Password { get; set; }

        public string Role { get; set; }

        public Guid PersonalDataID { get; set; }
        public Guid PlayerDataID { get; set; }

        public PersonalData PersonalData { get; set; }
        public PlayerData PlayerData { get; set; }
    }
}
