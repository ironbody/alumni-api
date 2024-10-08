﻿using System.Net.Mime;
using AlumniAPI.DTOs.Group;
using AlumniAPI.DTOs.Post;
using AlumniAPI.DTOs.User;
using AlumniAPI.Extensions;
using AlumniAPI.Models;
using AlumniAPI.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Group = AlumniAPI.Models.Group;

namespace AlumniAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
[Consumes(MediaTypeNames.Application.Json)]
[ApiConventionType(typeof(DefaultApiConventions))]
[Authorize]
public class GroupController : ControllerBase
{
    private readonly IGroupService _service;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;


    public GroupController(IGroupService service, IUserService userService, IMapper mapper)
    {
        _mapper = mapper;
        _service = service;
        _userService = userService;
    }

    /// <summary>
    /// Get all groups
    /// </summary>
    /// <returns>A list of groups</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReadGroupDto>>> GetGroup()
    {
        var group = await _service.GetAllAsync();
        var groupDto = _mapper.Map<List<ReadGroupDto>>(group);
        return Ok(groupDto);
    }

    /// <summary>
    /// Get a specific group
    /// </summary>
    /// <param name="id">Id to the group you want to get</param>
    /// <returns>A single group</returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult<ReadGroupDto>> GetGroup(int id)
    {
        if (!await _service.ExistsWithIdAsync(id))
        {
            return NotFound();
        }
        
        var group = await _service.GetByIdAsync(id);

        if (group == null)
        {
            return NotFound();
        }

        var groupDto = _mapper.Map<ReadGroupDto>(group);
        return Ok(groupDto);
    }

    [HttpGet("{id:int}/check")]
    public async Task<ActionResult<bool>> GetIfUserInGroup(int id)
    {
        if (!await _service.ExistsWithIdAsync(id))
        {
            return NotFound();
        }

        string email = HttpContext.GetUserEmail();
        var user = await _userService.GetUserByEmail(email);
        if (user is null) return NotFound();

        return Ok(await _service.GetIfUserInGroup(id, user.Id));
    }

    /// <summary>
    /// Updates a group
    /// </summary>
    /// <param name="id">Id of the group to update</param>
    /// <param name="groupDto">The new group details</param>
    /// <returns></returns>
    [HttpPut("{id:int}")]
    public async Task<ActionResult> PutGroup(int id, UpdateGroupDto groupDto)
    {
        if (id != groupDto.Id)
        {
            return BadRequest();
        }

        var group = _mapper.Map<Group>(groupDto);

        try
        {
            await _service.UpdateAsync(group);
        }
        catch (DbUpdateException)
        {
            if (!await _service.ExistsWithIdAsync(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    /// <summary>
    /// Creates a new group
    /// </summary>
    /// <param name="groupDto">The new group</param>
    /// <returns>The created group</returns>
    [HttpPost]
    public async Task<ActionResult<ReadGroupDto>> PostGroup(CreateGroupDto groupDto)
    {
        var group = _mapper.Map<Group>(groupDto);
        var groupId = await _service.AddAsync(group);
        var dto = _mapper.Map<ReadGroupDto>(group);
        return CreatedAtAction("GetGroup", new { id = groupId }, dto);
    }

    /// <summary>
    /// Deletes a group
    /// </summary>
    /// <param name="id">The id of the group to be deleted</param>
    /// <returns></returns>
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteGroup(int id)
    {
        if (!await _service.ExistsWithIdAsync(id))
        {
            return NotFound();
        }

        var group = await _service.GetByIdAsync(id);
        if (group == null)
        {
            return NotFound();
        }

        await _service.DeleteAsync(group);
        return NoContent();
    }

    [HttpGet("{id:int}/Users")]
    public async Task<ActionResult<IEnumerable<ReadUserDto>>> GetGroupUsers(int id)
    {
        if (!await _service.ExistsWithIdAsync(id))
        {
            return NotFound();
        }

        var groupWithUsers = await _service.GetGroupIncludingUsers(id);
        List<User> users = groupWithUsers.Users.ToList();
        var userDto = _mapper.Map<List<ReadUserDto>>(users);
        return userDto;
    }

    [HttpGet("{id:int}/Posts")]
    public async Task<ActionResult<IEnumerable<ReadPostDto>>> GetGroupPosts(int id)
    {
        if (!await _service.ExistsWithIdAsync(id))
        {
            return NotFound();
        }

        var groupWithPosts = await _service.GetGroupIncludingPosts(id);
        List<Post> posts = groupWithPosts.Posts.OrderByDescending(p =>
                p.CreatedDateTime < p.EditedDateTime ? p.EditedDateTime : p.CreatedDateTime)
            .ToList();
        var postDto = _mapper.Map<List<ReadPostDto>>(posts);
        return postDto;
    }

    [HttpPut("{id:int}/Users")]
    public async Task<ActionResult> UpdateUserGroups(int id, IEnumerable<int> userIds)
    {
        if (!await _service.ExistsWithIdAsync(id))
        {
            return NotFound();
        }

        try
        {
            var groupToUpdate = await _service.GetGroupIncludingUsers(id);
            await _service.UpdateGroupUsers(groupToUpdate, userIds);
        }
        catch (KeyNotFoundException ex)
        {
            return BadRequest(ex.Message);
        }

        return NoContent();
    }
}