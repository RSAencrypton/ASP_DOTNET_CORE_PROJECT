namespace ASP_DOTNET_CORE_WEB_API.Models.Dtos
{
    public class AccountDto
    {
        public Guid Id { get; set; }
        public string UserAccount { get; set; }
        public string Password { get; set; }

        public PersonalDataDto PersonalData { get; set; }
        public PlayerDataDto PlayerData { get; set; }
    }
}
