using Application.Common.Models;
using Application.User.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Mappings
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<UserEntity, CreateUserDto>().ReverseMap();
            CreateMap<UserEntity, UpdateUserDto>().ReverseMap();
            CreateMap<UserEntity, UserModel>().ReverseMap();
        }
    }
}
