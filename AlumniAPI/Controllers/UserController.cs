using System.Net.Mime;
using AlumniAPI.DTOs.DirectMessage;
using AlumniAPI.DTOs.Group;
using AlumniAPI.DTOs.User;
using AlumniAPI.Extensions;
using AlumniAPI.Models;
using AlumniAPI.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace AlumniAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
[Consumes(MediaTypeNames.Application.Json)]
[ApiConventionType(typeof(DefaultApiConventions))]
public class UserController : ControllerBase
{
    private readonly IUserService _service;
    private readonly IMapper _mapper;

    public UserController(IUserService service, IMapper mapper)
    {
        _mapper = mapper;
        _service = service;
    }

    /// <summary>
    /// Get all Users
    /// </summary>
    /// <returns>A list of users</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReadUserDto>>> GetUser()
    {
        var users = await _service.GetAllAsync();
        var userDto = _mapper.Map<List<ReadUserDto>>(users);
        return Ok(userDto);
    }

    /// <summary>
    /// Get a specific user
    /// </summary>
    /// <param name="id">Id to the user you want to get</param>
    /// <returns>A single user</returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult<ReadUserDto>> GetUser(int id)
    {
        if (!await _service.ExistsWithIdAsync(id))
        {
            return NotFound();
        }

        var user = await _service.GetByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        var userDto = _mapper.Map<ReadUserDto>(user);
        return Ok(userDto);
    }

    /// <summary>
    /// Updates a user
    /// </summary>
    /// <param name="id">Id of the user to update</param>
    /// <param name="userDto">The new user details</param>
    /// <returns></returns>
    [HttpPut("{id:int}")]
    public async Task<ActionResult> PutUser(int id, UpdateUserDto userDto)
    {
        if (id != userDto.Id)
        {
            return BadRequest();
        }

        var user = _mapper.Map<User>(userDto);

        try
        {
            await _service.UpdateAsync(user);
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

        return NotFound();
    }

    /// <summary>
    /// Creates a new user
    /// </summary>
    /// <param name="userDto">The new user</param>
    /// <returns>The created user</returns>
    [HttpPost]
    public async Task<ActionResult<ReadUserDto>> PostUser(CreateUserDto userDto)
    {
        var user = _mapper.Map<User>(userDto);
        var userId = await _service.AddAsync(user);
        var dto = _mapper.Map<ReadUserDto>(user);
        return CreatedAtAction("GetUser", new { id = userId }, dto);
    }

    /// <summary>
    /// Deletes a user
    /// </summary>
    /// <param name="id">The is of the user to be deleted</param>
    /// <returns></returns>
    [HttpDelete]
    public async Task<ActionResult> DeleteUser(int id)
    {
        if (!await _service.ExistsWithIdAsync(id))
        {
            return NotFound();
        }

        var user = await _service.GetByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        await _service.DeleteAsync(user);
        return NoContent();
    }

    /// <summary>
    /// Get all messages between two users
    /// </summary>
    /// <param name="senderId">The sender</param>
    /// <param name="recipientId">The reciever</param>
    /// <returns>A list of direct messages</returns>
    [HttpGet("{senderId:int}/messages/{recipientId:int}")]
    public async Task<ActionResult<IEnumerable<ReadDirectMessageDto>>> GetUserMessages(int senderId, int recipientId)
    {
        if (senderId == recipientId)
        {
            return BadRequest();
        }

        if (!await _service.ExistsWithIdAsync(senderId) || !await _service.ExistsWithIdAsync(recipientId))
        {
            return NotFound();
        }


        var userWithMessages = await _service.GetUserIncludingMessages(senderId);
        List<DirectMessage> filteredSent = userWithMessages.SentMessages
            .Where(e => e.SenderId == senderId && e.RecipientId == recipientId).ToList();
        List<DirectMessage> filteredReceived = userWithMessages.ReceivedMessages
            .Where(e => e.SenderId == recipientId && e.RecipientId == senderId).ToList();
        List<DirectMessage> messages =
            new List<DirectMessage>(filteredSent.Concat(filteredReceived).OrderBy(e => e.SentTime));
        var dmDto = _mapper.Map<List<ReadDirectMessageDto>>(messages);
        return dmDto;
    }
    
    
    /// <summary>
    /// Get all groups a user is in
    /// </summary>
    /// <param name="id">The id of the user</param>
    /// <returns>A list of groups</returns>
    [HttpGet("{id:int}/groups")]
    public async Task<ActionResult<IEnumerable<ReadGroupDto>>> GetUserGroups(int id)
    {
        if (!await _service.ExistsWithIdAsync(id))
        {
            return NotFound();
        }

        var userWithGroups = await _service.GetUserIncludingGroups(id);
        List<Group> groups = userWithGroups.Groups.ToList();
        var groupsDto = _mapper.Map<List<ReadGroupDto>>(groups);
        return groupsDto;
    }
    
    
    /// <summary>
    /// Get all posts from a user
    /// </summary>
    /// <param name="id">The is of the user</param>
    /// <returns>A list of posts</returns>
    [HttpGet("{id:int}/posts")]
    public async Task<ActionResult<IEnumerable<ReadGroupDto>>> GetUserPosts(int id)
    {
        if (!await _service.ExistsWithIdAsync(id))
        {
            return NotFound();
        }

        var userWithPosts = await _service.GetUserIncludingPosts(id);
        List<Group> groups = userWithPosts.Groups.ToList();
        var groupsDto = _mapper.Map<List<ReadGroupDto>>(groups);
        return groupsDto;
    }
    

    [HttpPost("check")]
    [Authorize]
    public async Task<ActionResult> CheckUser()
    {
        var email = HttpContext.GetUserEmail();
        var user = await _service.GetUserByEmail(email);
        if (user is not null) return Ok();
        
        var name = HttpContext.GetUserName();
        var newUser = new User()
        {
            Email = email,
            Name = name
        };

        await _service.AddAsync(newUser);

        return Ok();
    }
    //Todo: Implement Get Groups & Get Posts
}