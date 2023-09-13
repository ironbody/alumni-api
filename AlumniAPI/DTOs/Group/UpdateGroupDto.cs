namespace AlumniAPI.DTOs.Group;

public class UpdateGroupDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Image { get; set; }
    public int CreatorId { get; set; }
}