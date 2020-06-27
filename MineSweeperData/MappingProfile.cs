using AutoMapper;
using MineSweeperData.Models;
using MineSweeperData.ServiceModels;

namespace MineSweeperData
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ChatHubMessage, ChatHubMessageDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.ApplicationUser.UserName));
        }
    }
}
