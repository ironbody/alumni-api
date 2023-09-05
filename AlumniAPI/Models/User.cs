using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlumniAPI.Models;

public class User
{
    public int Id { get; set; }
    [MaxLength(60)] public string Name { get; set; }
    [MaxLength(300)] public string? AvatarURL { get; set; }
    [MaxLength(300)] public string? Bio { get; set; }
    [MaxLength(100)] public string? FunFact { get; set; }
    [MaxLength(100)] public string? WorkStatus { get; set; }
    [MaxLength(320)] public string Email { get; set; }

    public ICollection<DirectMessage> SentMessages { get; set; }
    public ICollection<DirectMessage> ReceivedMessages { get; set; }

    public ICollection<Group> Groups { get; set; }
    public ICollection<Post> Posts { get; set; }
    public ICollection<Reply> Replies { get; set; }
}