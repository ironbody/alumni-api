using AlumniAPI.DataAccess;
using AlumniAPI.Models;
using AlumniAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AlumniAPI.Services;

public class GroupService: IGroupService
{
    private readonly AlumniDbContext _context;

    public GroupService(AlumniDbContext context)
    {
        _context = context;
    }
    public async Task<Group?> GetByIdAsync(int id)
    {
        return await _context.Group.FindAsync(id);
    }

    public async Task<ICollection<Group>> GetAllAsync()
    {
        return await _context.Group.ToListAsync();
    }

    public async Task<bool> ExistsWithIdAsync(int id)
    {
        return (_context.Group?.Any(e => e.Id == id)).GetValueOrDefault();
    }

    public async Task<int> AddAsync(Group entity)
    {
        _context.Group.Add(entity);
        await _context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task UpdateAsync(Group entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Group entity)
    {
        _context.Group.Remove(entity);
        await _context.SaveChangesAsync();
    }
}