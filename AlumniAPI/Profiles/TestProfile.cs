using AlumniAPI.DTOs.Test;
using AlumniAPI.Models;
using AutoMapper;

namespace AlumniAPI.Profiles;

public class TestProfile: Profile
{
    public TestProfile()
    {
        CreateMap<Test, TestDto>().ReverseMap();
    }
}