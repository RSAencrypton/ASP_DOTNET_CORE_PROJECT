namespace ASP_DOTNET_CORE_WEB_API.Models.Domain
{
    public class AccountData
    {
        public Guid Id { get; set; }
        public string UserAccount { get; set; }
        public string Password { get; set; }

        public Guid PersonalDataID { get; set; }
        public Guid PlayerDataIDs { get; set; }

        public PersonalData PersonalData { get; set; }
        public PlayerData PlayerDatas { get; set; }
    }
}
