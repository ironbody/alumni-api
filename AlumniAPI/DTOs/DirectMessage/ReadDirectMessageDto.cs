﻿namespace AlumniAPI.DTOs.DirectMessage;

public class ReadDirectMessageDto
{
    public string Body { get; set; }
    public DateTime SentTime { get; set; }
    public int SenderId { get; set; }
    public int RecipientId { get; set; }
}