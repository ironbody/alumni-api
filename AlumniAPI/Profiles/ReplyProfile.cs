
using AlumniAPI.DTOs.Post.Reply;
using AlumniAPI.Models;
using AutoMapper;

public class ReplyProfile: Profile
{
    public ReplyProfile()
    {
        CreateMap<Reply, ReadReplyDto>();
    }
}