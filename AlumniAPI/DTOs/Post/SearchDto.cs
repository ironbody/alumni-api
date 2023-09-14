using AlumniAPI.DTOs.Post.Reply;

namespace AlumniAPI.DTOs.Post;

public class SearchDto
{
    public ReadPostDto Post { get; set; }
    public ReadReplyDto? Reply { get; set; }
}