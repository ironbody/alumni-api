using AlumniAPI.DataAccess;
using AlumniAPI.Models;
using AlumniAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AlumniAPI.Services;

public class DirectMessageService: IDirectMessageService
{
    private readonly AlumniDbContext _context;

    public DirectMessageService(AlumniDbContext context)
    {
        _context = context;
    }
    
    //Basic crud
    public async Task<DirectMessage?> GetByIdAsync(int id)
    {
        return await _context.DirectMessage.FindAsync(id);
    }

    public async Task<ICollection<DirectMessage>> GetAllAsync()
    {
        return await _context.DirectMessage.ToListAsync();
    }

    public async Task<bool> ExistsWithIdAsync(int id)
    {
        return (_context.DirectMessage?.Any(e => e.Id == id)).GetValueOrDefault();
    }

    public async Task<int> AddAsync(DirectMessage entity)
    {
        _context.DirectMessage.Add(entity);
        await _context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task UpdateAsync(DirectMessage entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(DirectMessage entity)
    {
        _context.DirectMessage.Remove(entity);
        await _context.SaveChangesAsync();
    }
}