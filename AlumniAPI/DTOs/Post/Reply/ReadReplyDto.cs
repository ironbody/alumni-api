using AlumniAPI.DTOs.User;

namespace AlumniAPI.DTOs.Post.Reply;

public class ReadReplyDto
{
    public int Id { get; set; }
    public UserPostInfo Creator { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Body { get; set; }
}