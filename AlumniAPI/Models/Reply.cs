using System.ComponentModel.DataAnnotations;

namespace AlumniAPI.Models;

public class Reply
{
    public int Id { get; set; }
    public int CreatorId { get; set; }
    public User Creator { get; set; }
    public int ReplyToId { get; set; }
    public Post ReplyTo { get; set; }

    [MaxLength(2000)] public string Body { get; set; }
}