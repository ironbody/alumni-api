namespace AlumniAPI.DTOs.User;

public class ReadUserDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? AvatarURL { get; set; }
    public string? Bio { get; set; }
    public string? FunFact { get; set; }
    public string? WorkStatus { get; set; }
}