using System.Net.Mime;
using AlumniAPI.DTOs.DirectMessage;
using AlumniAPI.Models;
using AlumniAPI.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlumniAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
[Consumes(MediaTypeNames.Application.Json)]
[ApiConventionType(typeof(DefaultApiConventions))]
[Authorize]
public class DirectMessageController: ControllerBase
{
    private readonly IDirectMessageService _service;
    private readonly IMapper _mapper;

    public DirectMessageController(IDirectMessageService service, IMapper mapper)
    {
        _mapper = mapper;
        _service = service;
    }

    /// <summary>
    /// Get all direct messages
    /// </summary>
    /// <returns>A list of direct messages</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReadDirectMessageDto>>> GetDM()
    {
        var messages = await _service.GetAllAsync();
        var messageDto = _mapper.Map<List<ReadDirectMessageDto>>(messages);
        return Ok(messageDto);
    }

    /// <summary>
    /// Get a specific direct message
    /// </summary>
    /// <param name="id">Id to the direct message you want to get</param>
    /// <returns>A single direct message</returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult<ReadDirectMessageDto>> GetDM(int id)
    {
        if (!await _service.ExistsWithIdAsync(id))
        {
            return NotFound();
        }

        var message = await _service.GetByIdAsync(id);
        if (message == null)
        {
            return NotFound();
        }

        var messageDto = _mapper.Map<ReadDirectMessageDto>(message);
        return Ok(messageDto);
    }

    /// <summary>
    /// Updates a direct message
    /// </summary>
    /// <param name="id">Id of the direct message to update</param>
    /// <param name="userDto">The new direct message details</param>
    /// <returns></returns>
    [HttpPut("{id:int}")]
    public async Task<ActionResult> PutDM(int id, UpdateDirectMessageDto messageDto)
    {
        if (id != messageDto.Id)
        {
            return BadRequest();
        }

        var message = _mapper.Map<DirectMessage>(messageDto);

        try
        {
            await _service.UpdateAsync(message);
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
    /// Creates a new direct message
    /// </summary>
    /// <param name="messageDto">The new direct message</param>
    /// <returns>The created direct message</returns>
    [HttpPost]
    public async Task<ActionResult<ReadDirectMessageDto>> PostDM(CreateDirectMessageDto messageDto)
    {
        var message = _mapper.Map<DirectMessage>(messageDto);
        message.SentTime = DateTime.UtcNow;
        var messageId = await _service.AddAsync(message);
        var dto = _mapper.Map<ReadDirectMessageDto>(message);
        return CreatedAtAction("GetDM", new { id = messageId }, dto);
    }

    /// <summary>
    /// Deletes a direct message
    /// </summary>
    /// <param name="id">The id of the direct message to be deleted</param>
    /// <returns></returns>
    [HttpDelete]
    public async Task<ActionResult> DeleteDM(int id)
    {
        if (!await _service.ExistsWithIdAsync(id))
        {
            return NotFound();
        }
        var message = await _service.GetByIdAsync(id);
        if (message == null)
        {
            return NotFound();
        }
        await _service.DeleteAsync(message);
        return NoContent();
    }
}