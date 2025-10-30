using AutoMapper;
using SOneWeb.Domain.Entities;
using SOneWeb.Api.DTOs;

namespace SOneWeb.Api.Utils
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserEntity, UserCreateDto>().ReverseMap();
        }
    }
}
