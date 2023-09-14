using AlumniAPI.DTOs.Post.Reply;
using AlumniAPI.Models;
using AutoMapper;

namespace AlumniAPI.Profiles;

public class ReplyProfile: Profile
{
    public ReplyProfile()
    {
        CreateMap<Reply, ReadReplyDto>();
    }
}