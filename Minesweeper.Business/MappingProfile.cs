using AutoMapper;
using Minesweeper.Business.Dto;
using Minesweeper.Data.Entities;

namespace Minesweeper.Business
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, ApplicationUserDto>().ReverseMap();
            CreateMap<ChatHubMessage, ChatHubMessageDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.ApplicationUser.UserName));
        }
    }
}
