namespace AlumniAPI.Models;

public class Group
{
    public int Id { get; set; }
    public ICollection<Post> Posts { get; set; }
}