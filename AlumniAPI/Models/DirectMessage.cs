using System.ComponentModel.DataAnnotations;

namespace AlumniAPI.Models;

public class DirectMessage
{
    public int Id { get; set; }
    [MaxLength(100)] public string Body { get; set; }
    public DateTime SentTime { get; set; }
    
    public int SenderId { get; set; }
    public User Sender { get; set; }
    public int RecipientId { get; set; }
    public User Recipient { get; set; }
}