using System.ComponentModel.DataAnnotations;

namespace AlumniAPI.Models;

public class Test
{
    public int Id { get; set; }

    [MaxLength(50)] public string Name { get; set; }
}