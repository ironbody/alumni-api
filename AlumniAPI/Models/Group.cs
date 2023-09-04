using System.ComponentModel.DataAnnotations;

namespace AlumniAPI.Models;

public class Group
{
    public int Id { get; set; }
    [MaxLength(200)] public string Name { get; set; }
    [MaxLength(1000)] public string? Description { get; set; }
    
    public ICollection<User> Users { get; set; }
}