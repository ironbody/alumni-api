namespace AlumniAPI.DTOs.Group;

public class CreateGroupDto
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Image { get; set; }
    public int CreatorId { get; set; }
    public bool Private { get; set; }
}