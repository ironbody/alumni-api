using AlumniAPI.DTOs.Group;
using AlumniAPI.DTOs.Post;
using AlumniAPI.DTOs.User;
using AlumniAPI.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AlumniAPI.Profiles;

public class PostProfile : Profile
{
    public PostProfile()
    {
        CreateMap<EventInfo, ReadEventInfoDto>();
        CreateMap<User, UserPostInfo>();
        CreateMap<Group, GroupPostInfo>();
        CreateMap<Post, ReadPostDto>();

        CreateMap<CreateEventInfoDto, EventInfo>();
        CreateMap<CreatePostDto, Post>();
    }
}