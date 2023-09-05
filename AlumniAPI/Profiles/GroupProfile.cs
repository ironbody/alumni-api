using AlumniAPI.DTOs.Group;
using AlumniAPI.Models;
using AutoMapper;

namespace AlumniAPI.Profiles;

public class GroupProfile: Profile
{
    public GroupProfile()
    {
        CreateMap<Group, CreateGroupDto>().ReverseMap();
        CreateMap<Group, ReadGroupDto>().ReverseMap();
        CreateMap<Group, UpdateGroupDto>().ReverseMap();
    }
}