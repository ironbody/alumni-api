using System.Net.Mime;
using AlumniAPI.DTOs.DirectMessage;
using AlumniAPI.DTOs.Group;
using AlumniAPI.DTOs.User;
using AlumniAPI.Models;
using AlumniAPI.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    /// Get all conversations from a user
    /// </summary>
    /// <param name="id">The user</param>
    /// <returns>A list of direct messages</returns>
    [HttpGet("{id:int}/messages")]
    public async Task<ActionResult<IEnumerable<IEnumerable<ReadDirectMessageDto>>>> GetUserMessages(int id)
    {

        if (!await _service.ExistsWithIdAsync(id))
        {
            return NotFound();
        }

        var userWithMessages = await _service.GetUserIncludingMessages(id);
        List<List<DirectMessage>> messages =  GetUserConvos(id, userWithMessages);
        //Order by latest message in convo
        messages = messages.OrderByDescending(e => e[e.Count-1].SentTime).ToList();
        var dmDto = _mapper.Map<List<List<ReadDirectMessageDto>>>(messages);
        return dmDto;
    }
    
    /// <summary>
    /// Get specific conversation between two users
    /// </summary>
    /// <param name="id">The id of the first user</param>
    /// <param name="id2">The id of the other user</param>
    /// <returns>A list of direct messages</returns>
    [HttpGet("{id:int}/messages/{id2:int}")]
    public async Task<ActionResult<IEnumerable<ReadDirectMessageDto>>> GetUserMessagesForSpecificUser(int id, int id2)
    {

        if (!await _service.ExistsWithIdAsync(id))
        {
            return NotFound();
        }

        var userWithMessages = await _service.GetUserIncludingMessages(id);
        List<List<DirectMessage>> messages =  GetUserConvos(id, userWithMessages);
        //Order by latest message in convo
        messages = messages.OrderByDescending(e => e[e.Count-1].SentTime).ToList().Where(e => e[0].RecipientId == id2 || e[0].SenderId == id2).ToList();
        if (messages.Count <= 0)
        {
            return BadRequest();
        }
        var dmDto = _mapper.Map<List<ReadDirectMessageDto>>(messages[0]);
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
    
    [HttpPut("{id:int}/groups")]
    public async Task<ActionResult> UpdateUserGroups(int id, IEnumerable<int> groupIds)
    {
        if (!await _service.ExistsWithIdAsync(id))
        {
            return NotFound();
        }

        try
        {
            var userToUpdate = await _service.GetUserIncludingGroups(id);
            await _service.UpdateUserGroups(userToUpdate, groupIds);
        }
        catch(KeyNotFoundException ex)
        {
            return BadRequest(ex.Message);
        }

        return NoContent();
    }

    [HttpPut("{id:int}/posts")]
    public async Task<ActionResult> UpdateUserPosts(int id, IEnumerable<int> postIds)
    {
        if (!await _service.ExistsWithIdAsync(id))
        {
            return NotFound();
        }

        try
        {
            var userToUpdate = await _service.GetUserIncludingPosts(id);
            await _service.UpdateUserPosts(userToUpdate, postIds);
        }
        catch(KeyNotFoundException ex)
        {
            return BadRequest(ex.Message);
        }

        return NoContent();
    }
    
    [HttpPut("{id:int}/replies")]
    public async Task<ActionResult> UpdateUserReplies(int id, IEnumerable<int> repliesIds)
    {
        if (!await _service.ExistsWithIdAsync(id))
        {
            return NotFound();
        }

        try
        {
            var userToUpdate = await _service.GetUserIncludingReplies(id);
            await _service.UpdateUserReplies(userToUpdate, repliesIds);
        }
        catch(KeyNotFoundException ex)
        {
            return BadRequest(ex.Message);
        }

        return NoContent();
    }

    private  List<List<DirectMessage>> GetUserConvos(int id, User userWithMessages)
    {

        Dictionary<int, List<DirectMessage>> dmMap = new Dictionary<int, List<DirectMessage>>();
        foreach (var dm in userWithMessages.ReceivedMessages)
        {
            if (!dmMap.ContainsKey(dm.SenderId))
            {
                dmMap.Add(dm.SenderId, new List<DirectMessage>());
            }
            dmMap[dm.SenderId].Add(dm);
        }
        foreach (var dm in userWithMessages.SentMessages)
        {
            if (!dmMap.ContainsKey(dm.RecipientId))
            {
                dmMap.Add(dm.RecipientId, new List<DirectMessage>());
            }
            dmMap[dm.RecipientId].Add(dm);
        }

        List<List<DirectMessage>> messages = new List<List<DirectMessage>>();
        int i = 0;
        foreach (var dms in dmMap)
        {
            messages.Add(new List<DirectMessage>());
            foreach (var dm in dms.Value)
            {
                messages[i].Add(dm);
            }
            messages[i] = new List<DirectMessage>(messages[i].OrderByDescending(e => e.SentTime));
            if (messages[i].Count() > 1)
            {
                messages[i].RemoveRange(1,messages[i].Count-1);
            }
            i++;
        }

        return messages;
    }
    
}