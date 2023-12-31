﻿namespace ASP_DOTNET_CORE_WEB_API.Models.Dtos
{
    public class AddAccountDto
    {
        public string UserAccount { get; set; }
        public string Password { get; set; }

        public string Role { get; set; }

        public Guid PersonalDataID { get; set; }
        public Guid PlayerDataID { get; set; }
    }
}
