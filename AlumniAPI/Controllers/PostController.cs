using AlumniAPI.DTOs.Post;
using AlumniAPI.Models;
using AlumniAPI.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AlumniAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostController: ControllerBase
{
    private IPostService _service;
    private IMapper _mapper;

    public PostController(IPostService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReadPostDto>>> GetAllPosts()
    {
        var results = await _service.GetAllAsync();
        var mapped = _mapper.Map<IEnumerable<ReadPostDto>>(results);
        return Ok(mapped);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ReadPostDto>> GetPostById(int id)
    {
        if (! await _service.ExistsWithIdAsync(id))
        {
            return NotFound();
        }
        
        var result = await _service.GetByIdAsync(id);
        if (result is null)
        {
            return Problem();
        }
        var mapped = _mapper.Map<ReadPostDto>(result);
        return Ok(mapped);
    }
}