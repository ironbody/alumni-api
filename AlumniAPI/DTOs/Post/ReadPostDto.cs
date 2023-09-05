using AlumniAPI.DTOs.Group;
using AlumniAPI.DTOs.User;
using AlumniAPI.Models;

namespace AlumniAPI.DTOs.Post;

public class ReadPostDto
{
    public int Id { get; set; }
    public UserPostInfo Creator { get; set; }
    public GroupPostInfo Group { get; set; }

    public string Title { get; set; }
    public string Body { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime? EditedDateTime { get; set; }
    public ReadEventInfoDto? EventInfo { get; set; }
}