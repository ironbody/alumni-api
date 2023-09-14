using AlumniAPI.DataAccess;
using AlumniAPI.Models;
using AlumniAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AlumniAPI.Services;

public class ReplyService : IReplyService
{
    private AlumniDbContext _context;

    public ReplyService(AlumniDbContext context)
    {
        _context = context;
    }

    public async Task<Reply?> GetByIdAsync(int id)
    {
        return await _context.Reply.FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<ICollection<Reply>> GetAllAsync()
    {
        return await _context.Reply.ToListAsync();
    }

    public async Task<bool> ExistsWithIdAsync(int id)
    {
        return await _context.Reply.AnyAsync(r => r.Id == id);
    }

    public async Task<int> AddAsync(Reply entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task UpdateAsync(Reply entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Reply entity)
    {
        _context.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Reply>> SearchRepliesVisibleToUser(int userId, string query)
    {
        var user = await _context
            .User
            .Include(u => u.Groups)
            .FirstOrDefaultAsync(u => u.Id == userId);
        if (user is null)
        {
            return Enumerable.Empty<Reply>();
        }

        var replies = _context
            .Reply
            .Include(r => r.Creator)
            .Include(r => r.ReplyTo)
            .Include(r => r.ReplyTo.Creator)
            .Include(r => r.ReplyTo.Group)
            .Include(r => r.ReplyTo.EventInfo)
            .OrderByDescending(r => r.CreatedDate)
            .AsEnumerable();

        var filteredReplies = replies
            .Where(r => user.Groups.Any(g => g.Id == r.ReplyTo.GroupId))
            .Where(r => r.Body.Contains(query));
        return filteredReplies;
    }
}