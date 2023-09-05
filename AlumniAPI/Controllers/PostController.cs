using System.Runtime.InteropServices.ComTypes;
using System.Security.Claims;
using AlumniAPI.DTOs.Post;
using AlumniAPI.Extensions;
using AlumniAPI.Models;
using AlumniAPI.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AlumniAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class PostController : ControllerBase
{
    private IPostService _postService;
    private IUserService _userService;
    private IMapper _mapper;

    public PostController(IPostService postService, IUserService userService, IMapper mapper)
    {
        _postService = postService;
        _userService = userService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReadPostDto>>> GetAllPosts()
    {
        var results = await _postService.GetAllAsync();
        var mapped = _mapper.Map<IEnumerable<ReadPostDto>>(results);
        return Ok(mapped);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ReadPostDto>> GetPostById(int id)
    {
        if (!await _postService.ExistsWithIdAsync(id))
        {
            return NotFound();
        }

        var result = await _postService.GetByIdAsync(id);
        if (result is null)
        {
            return NotFound();
        }

        var mapped = _mapper.Map<ReadPostDto>(result);
        return Ok(mapped);
    }

    [HttpPost]
    public async Task<ActionResult<ReadPostDto>> CreateNewPost(CreatePostDto dto)
    {
        var email = HttpContext.GetUserEmail();
        var user = await _userService.GetUserByEmail(email);
        if (user is null)
        {
            return BadRequest(
                "No user found with the email from the token. Make sure to call /user/check before you call this route.");
        }

        if (!await _userService.CanAccessGroup(user.Id, dto.GroupId))
        {
            return Forbid();
        }

        var mapped = _mapper.Map<Post>(dto);
        mapped.CreatedDateTime = DateTime.Now;
        mapped.CreatorId = user.Id;

        var newId = await _postService.AddAsync(mapped);
        var readDto = _mapper.Map<ReadPostDto>(mapped);

        var test = await _postService.GetByIdAsync(newId);

        return CreatedAtAction(nameof(GetPostById), new { id = mapped.Id }, readDto);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> EditPost(int id, EditPostDto dto)
    {
        var post = await _postService.GetByIdAsync(id);
        if (post is null)
        {
            return NotFound();
        }

        var info = _mapper.Map<EventInfo?>(dto.EventInfo);
        post.Title = dto.Title;
        post.Body = dto.Body;
        post.EventInfo = info;
        post.EditedDateTime = DateTime.Now;

        await _postService.UpdateAsync(post);
        
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeletePost(int id)
    {
        var post = await _postService.GetByIdAsync(id);
        if (post is null)
        {
            return NotFound();
        }

        await _postService.DeleteAsync(post);
        
        return Ok();
    }
}