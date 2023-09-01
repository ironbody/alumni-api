using AlumniAPI.DTOs.Test;
using AlumniAPI.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AlumniAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController: ControllerBase
{
    
    private readonly ITestService _service;
    private readonly IMapper _mapper;

    public TestController(ITestService service, IMapper mapper)
    {
        _mapper = mapper;
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TestDto>>> GetName()
    {
        var names = await _service.GetAllAsync();
        var testDto = _mapper.Map<List<TestDto>>(names);
        return Ok(testDto);
    }
}