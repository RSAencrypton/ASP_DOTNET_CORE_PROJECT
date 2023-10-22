using ASP_DOTNET_CORE_WEB_API.Models.Domain;
using ASP_DOTNET_CORE_WEB_API.Models.Dtos;
using AutoMapper;

namespace ASP_DOTNET_CORE_WEB_API.Automapper
{
    public class PlayerDataMapper : Profile
    {
        public PlayerDataMapper() {
            CreateMap<PlayerData, PlayerDataDto>().ReverseMap();
            CreateMap<AccountData, AccountDto>().ReverseMap();
            CreateMap<AddPLayerDataDto, PlayerData>().ReverseMap();
            CreateMap<PersonalData, PersonalDataDto>().ReverseMap();
            CreateMap<AddPersonalDataDto, PersonalData>().ReverseMap();
        }
    }
}
