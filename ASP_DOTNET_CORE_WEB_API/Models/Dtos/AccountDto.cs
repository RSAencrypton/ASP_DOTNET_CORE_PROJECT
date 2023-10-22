namespace ASP_DOTNET_CORE_WEB_API.Models.Dtos
{
    public class AccountDto
    {
        public Guid Id { get; set; }
        public string UserAccount { get; set; }
        public string Password { get; set; }

        public Guid PersonalDataID { get; set; }
        public Guid PlayerDataID { get; set; }
    }
}
