using AlumniAPI.DataAccess;
using AlumniAPI.Models;
using AlumniAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AlumniAPI.Services;

public class ReplyService: IReplyService
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
}