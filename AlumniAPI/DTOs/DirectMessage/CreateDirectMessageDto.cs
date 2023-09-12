namespace AlumniAPI.DTOs.DirectMessage;

public class CreateDirectMessageDto
{
    public string Body { get; set; }
    public int SenderId { get; set; }
    public int RecipientId { get; set; }
}