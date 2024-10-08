﻿namespace AlumniAPI.DTOs.Group;

public class GroupPostInfo
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CreatorId { get; set; }
    public bool Private { get; set; }
    public string Self => $"/group/{Id}";
}