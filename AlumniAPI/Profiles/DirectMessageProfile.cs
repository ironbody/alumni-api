using AlumniAPI.DTOs.DirectMessage;
using AlumniAPI.Models;
using AutoMapper;

namespace AlumniAPI.Profiles;

public class DirectMessageProfile: Profile
{
    public DirectMessageProfile()
    {
        CreateMap<DirectMessage, ReadDirectMessageDto>().ReverseMap();
    }
}