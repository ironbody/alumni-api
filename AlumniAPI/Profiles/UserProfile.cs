using AlumniAPI.DTOs.User;
using AlumniAPI.Models;
using AutoMapper;

namespace AlumniAPI.Profiles;

public class UserProfile: Profile
{
    public UserProfile()
    {
        CreateMap<User, CreateUserDto>().ReverseMap();
        CreateMap<User, ReadUserDto>().ReverseMap();
        CreateMap<User, UpdateUserDto>().ReverseMap();
    }
}