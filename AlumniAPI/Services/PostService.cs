﻿using AlumniAPI.DataAccess;
using AlumniAPI.Models;
using AlumniAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AlumniAPI.Services;

public class PostService : IPostService
{
    private AlumniDbContext _context;

    public PostService(AlumniDbContext context)
    {
        _context = context;
    }

    public async Task<Post?> GetByIdAsync(int id)
    {
        var post = await _context.Post
            .Include(p => p.Creator)
            .Include(p => p.Group)
            .Include(p => p.EventInfo)
            .Include(p => p.Replies)
            .ThenInclude(r => r.Creator)
            .FirstOrDefaultAsync(p => p.Id == id);
        return post;
    }

    public async Task<ICollection<Post>> GetAllAsync()
    {
        var posts = await _context.Post
            .Include(p => p.Creator)
            .Include(p => p.Group)
            .Include(p => p.EventInfo)
            .ToListAsync();
        return posts;
    }

    public async Task<bool> ExistsWithIdAsync(int id)
    {
        var exists = await _context.Post.AnyAsync(p => p.Id == id);
        return exists;
    }

    public async Task<int> AddAsync(Post entity)
    {
        entity.Id = 0;
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task UpdateAsync(Post entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Post entity)
    {
        _context.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Post>> GetAllPostsVisibleToUser(int userId)
    {
        var user = await _context.User
            .Include(u => u.Groups)
            .ThenInclude(g => g.Posts)
            .ThenInclude(p => p.Creator)
            .Include(u => u.Groups)
            .ThenInclude(g => g.Posts)
            .ThenInclude(p => p.EventInfo)
            .FirstOrDefaultAsync(u => u.Id == userId);

        if (user is null)
        {
            return Enumerable.Empty<Post>();
        }

        var posts = user
            .Groups
            .SelectMany(g => g.Posts)
            .OrderByDescending(p => p.CreatedDateTime < p.EditedDateTime ? p.EditedDateTime : p.CreatedDateTime);
        return posts;
    }

    public async Task<bool> PostIsVisibleToUser(int postId, int userId)
    {
        var user = await _context.User
            .Include(u => u.Groups)
            .FirstOrDefaultAsync(u => u.Id == userId);

        var post = await _context.Post.FindAsync(postId);

        if (user is null || post is null)
        {
            return false;
        }

        return user.Groups.Any(g => g.Id == post.GroupId);
    }

    public async Task<IEnumerable<Post>> SearchPostsVisibleToUser(int userId, string query)
    {
        var user = await _context.User
            .Include(u => u.Groups)
            .ThenInclude(g => g.Posts)
            .ThenInclude(p => p.Creator)
            .FirstOrDefaultAsync(u => u.Id == userId);

        if (user is null)
        {
            return Enumerable.Empty<Post>();
        }
        
        var posts = user.Groups
            .SelectMany(g => g.Posts)
            .OrderByDescending(p =>
                p.CreatedDateTime < p.EditedDateTime ? p.EditedDateTime : p.CreatedDateTime);

        var filteredPosts = posts.Where(p => p.Title.ToLowerInvariant().Contains(query.ToLowerInvariant())
                                             || p.Body.ToLowerInvariant().Contains(query.ToLowerInvariant()));

        return filteredPosts;
    }
}