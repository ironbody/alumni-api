namespace AlumniAPI.DTOs.User;

public class UserPostInfo
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string AvatarURL { get; set; }
    public string Self => $"/user/{Id}";
}