using System.ComponentModel.DataAnnotations;

namespace AlumniAPI.Models;

public class Group
{
    public int Id { get; set; }
    [MaxLength(200)] public string Name { get; set; }
    [MaxLength(1000)] public string? Description { get; set; }
    
    [MaxLength(300)] public string? Image { get; set; }
    
    public int CreatorId { get; set; }
    
    public bool Private { get; set; }
    
    public ICollection<User> Users { get; set; }
    public ICollection<Post> Posts { get; set; }
}