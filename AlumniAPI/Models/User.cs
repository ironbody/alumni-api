namespace AlumniAPI.Models;

public class User
{
    public int Id { get; set; }
    public ICollection<Post> Posts { get; set; }
}