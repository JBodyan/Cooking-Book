using Application.Dto;
using Application.Dto.User;
using AutoMapper;
using Data.Entities;

namespace Application.Configuration.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            
            CreateMap<UserUpdateDto, User>().ReverseMap();

            CreateMap<SignInDto, User>().ReverseMap();

            CreateMap<UserRegisterDto, User>().ReverseMap();

            CreateMap<UserDto, User> ().ReverseMap();
        }
    }
}
