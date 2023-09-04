using System.ComponentModel.DataAnnotations;

namespace AlumniAPI.Models;

public class EventInfo
{
    public int Id { get; set; }
    public int PostId { get; set; }
    public Post Post { get; set; }

    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    [MaxLength(100)] public string Location { get; set; }
}