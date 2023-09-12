namespace AlumniAPI.DTOs.Post;

public class CreatePostDto
{
    public int GroupId { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public CreateEventInfoDto? EventInfo { get; set; }
}