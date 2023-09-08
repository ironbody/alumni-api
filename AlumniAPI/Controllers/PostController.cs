using AlumniAPI.DTOs.Post;
using AlumniAPI.DTOs.Post.Reply;
using AlumniAPI.Extensions;
using AlumniAPI.Models;
using AlumniAPI.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlumniAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class PostController : ControllerBase
{
    private IPostService _postService;
    private IUserService _userService;
    private IReplyService _replyService;
    private IMapper _mapper;

    private const string UserWithEmailNotFoundMessage =
        "No user found with the email from the token. Make sure to call /user/check before you call this route.";

    public PostController(IPostService postService, IUserService userService, IReplyService replyService,
        IMapper mapper)
    {
        _postService = postService;
        _userService = userService;
        _replyService = replyService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReadPostDto>>> GetAllPosts()
    {
        var user = await RetrieveUser();
        if (user is null)
        {
            return BadRequest(UserWithEmailNotFoundMessage);
        }

        var results = await _postService.GetAllPostsVisibleToUser(user.Id);
        var mapped = _mapper.Map<IEnumerable<ReadPostDto>>(results);
        return Ok(mapped);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ReadPostDto>> GetPostById(int id)
    {
        var user = await RetrieveUser();
        if (user is null)
        {
            return BadRequest(UserWithEmailNotFoundMessage);
        }

        if (!await _postService.ExistsWithIdAsync(id))
        {
            return NotFound();
        }

        var result = await _postService.GetByIdAsync(id);
        if (result is null)
        {
            return NotFound();
        }

        if (!await _postService.PostIsVisibleToUser(result.Id, user.Id))
        {
            return Forbid();
        }

        var mapped = _mapper.Map<ReadPostDto>(result);
        return Ok(mapped);
    }

    [HttpPost]
    public async Task<ActionResult<ReadPostDto>> CreateNewPost(CreatePostDto dto)
    {
        var user = await RetrieveUser();
        if (user is null)
        {
            return BadRequest(UserWithEmailNotFoundMessage);
        }

        if (!await _userService.CanAccessGroup(user.Id, dto.GroupId))
        {
            return Forbid();
        }

        var mapped = _mapper.Map<Post>(dto);
        mapped.CreatedDateTime = DateTime.UtcNow;
        mapped.CreatorId = user.Id;

        var newId = await _postService.AddAsync(mapped);
        var readDto = _mapper.Map<ReadPostDto>(mapped);

        var test = await _postService.GetByIdAsync(newId);

        return CreatedAtAction(nameof(GetPostById), new { id = mapped.Id }, readDto);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> EditPost(int id, EditPostDto dto)
    {
        var user = await RetrieveUser();
        if (user is null)
        {
            return BadRequest(UserWithEmailNotFoundMessage);
        }

        var post = await _postService.GetByIdAsync(id);
        if (post is null)
        {
            return NotFound();
        }

        if (post.CreatorId != user.Id)
        {
            return Forbid();
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
        var user = await RetrieveUser();
        if (user is null)
        {
            return BadRequest(UserWithEmailNotFoundMessage);
        }

        var post = await _postService.GetByIdAsync(id);
        if (post is null)
        {
            return NotFound();
        }

        if (post.CreatorId != user.Id)
        {
            return Forbid();
        }

        await _postService.DeleteAsync(post);

        return Ok();
    }

    [HttpGet("{postId:int}/reply")]
    public async Task<ActionResult<IEnumerable<ReadReplyDto>>> GetReplies(int postId)
    {
        var user = await RetrieveUser();
        if (user is null)
        {
            return BadRequest(UserWithEmailNotFoundMessage);
        }

        var post = await _postService.GetByIdAsync(postId);
        if (post is null)
        {
            return NotFound();
        }

        if (!await _postService.PostIsVisibleToUser(post.Id, user.Id))
        {
            return Forbid();
        }

        var mappedReplies = _mapper.Map<List<ReadReplyDto>>(post.Replies);
        return Ok(mappedReplies);
    }

    [HttpPost("{postId:int}/reply")]
    public async Task<ActionResult<ReadReplyDto>> PostReply(int postId, CreateReplyDto dto)
    {
        var user = await RetrieveUser();
        if (user is null)
        {
            return BadRequest(UserWithEmailNotFoundMessage);
        }

        var post = await _postService.GetByIdAsync(postId);
        if (post is null)
        {
            return NotFound();
        }

        if (!await _postService.PostIsVisibleToUser(post.Id, user.Id))
        {
            return Forbid();
        }

        var newReply = new Reply()
        {
            CreatorId = user.Id,
            ReplyToId = post.Id,
            CreatedDate = DateTime.UtcNow,
            Body = dto.Body,
        };

        post.Replies.Add(newReply);
        await _postService.UpdateAsync(post);

        var mapped = _mapper.Map<ReadReplyDto>(newReply);
        return Ok(mapped);
    }

    [HttpPut("{postId:int}/reply/{replyId:int}")]
    public async Task<ActionResult> EditReply(int postId, int replyId, EditReplyDto dto)
    {
        var user = await RetrieveUser();
        if (user is null)
        {
            return BadRequest(UserWithEmailNotFoundMessage);
        }

        var post = await _postService.GetByIdAsync(postId);
        if (post is null)
        {
            return NotFound("Post doesn't exist");
        }

        if (!await _postService.PostIsVisibleToUser(post.Id, user.Id))
        {
            return Forbid();
        }

        if (user.Id != post.CreatorId)
        {
            return Forbid();
        }

        var reply = await _replyService.GetByIdAsync(replyId);
        if (reply is null)
        {
            return NotFound("Reply does not exist");
        }

        if (reply.ReplyToId != postId)
        {
            return NotFound("Reply is not a reply to the given post");
        }

        reply.Body = dto.Body;

        await _replyService.UpdateAsync(reply);

        // WHY THE FUCK IS THERE SO MUCH CODE JUST FOR VALIDATION AAAAAAA
        return Ok();
    }

    [HttpDelete("{postId:int}/reply/{replyId:int}")]
    public async Task<ActionResult> DeleteReply(int postId, int replyId)
    {
        var user = await RetrieveUser();
        if (user is null)
        {
            return BadRequest(UserWithEmailNotFoundMessage);
        }

        var post = await _postService.GetByIdAsync(postId);
        if (post is null)
        {
            return NotFound("Post doesn't exist");
        }

        if (!await _postService.PostIsVisibleToUser(post.Id, user.Id))
        {
            return Forbid();
        }

        if (user.Id != post.CreatorId)
        {
            return Forbid();
        }

        var reply = await _replyService.GetByIdAsync(replyId);
        if (reply is null)
        {
            return NotFound("Reply does not exist");
        }

        if (reply.ReplyToId != postId)
        {
            return NotFound("Reply is not a reply to the given post");
        }

        await _replyService.DeleteAsync(reply);

        // WHY THE FUCK IS THERE SO MUCH CODE JUST FOR VALIDATION AAAAAAA
        return Ok();
    }

    private async Task<User?> RetrieveUser()
    {
        var email = HttpContext.GetUserEmail();
        var user = await _userService.GetUserByEmail(email);
        return user;
    }
}