using System.ComponentModel.DataAnnotations;

namespace AlumniAPI.Models;

public class Post
{
    public int Id { get; set; }
    public int CreatorId { get; set; }
    public User Creator { get; set; }
    public int GroupId { get; set; }
    public Group Group { get; set; }

    [MaxLength(80)] public string Title { get; set; }
    [MaxLength(2000)] public string Body { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime? EditedDateTime { get; set; }
    public EventInfo? EventInfo { get; set; }
}