using AlumniAPI.DataAccess;
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
}