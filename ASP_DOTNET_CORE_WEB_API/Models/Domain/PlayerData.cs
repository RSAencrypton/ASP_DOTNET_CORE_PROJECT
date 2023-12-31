﻿using ASP_DOTNET_CORE_WEB_API.Models.Dtos;

namespace ASP_DOTNET_CORE_WEB_API.Models.Domain
{
    public class PlayerData
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int Exp { get; set; }
        public int Money { get; set; }
    }
}
