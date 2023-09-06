namespace AlumniAPI.DTOs.Post;

public class EditPostDto
{
    public string Title { get; set; }
    public string Body { get; set; }
    public EditEventInfoDto? EventInfo { get; set; }
}