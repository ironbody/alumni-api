using AlumniAPI.DataAccess;
using AlumniAPI.Models;
using AlumniAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AlumniAPI.Services;

public class UserService: IUserService
{
    private readonly AlumniDbContext _context;

    public UserService(AlumniDbContext context)
    {
        _context = context;
    }
    //Basic crud
    public async Task<User?> GetByIdAsync(int id)
    {
        return await _context.User.FindAsync(id);
    }

    public async Task<ICollection<User>> GetAllAsync()
    {
        return await _context.User.ToListAsync();
    }

    public async Task<bool> ExistsWithIdAsync(int id)
    {
        return (_context.User?.Any(e => e.Id == id)).GetValueOrDefault();
    }

    public async Task<int> AddAsync(User entity)
    {
        _context.User.Add(entity);
        await _context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task UpdateAsync(User entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(User entity)
    {
        _context.User.Remove(entity);
        await _context.SaveChangesAsync();
    }

    
    //Special
    public async Task<User> GetUserIncludingMessages(int id)
    {
        return await _context.User
            .Include(user => user.ReceivedMessages)
            .Include(user => user.SentMessages)
            .Where(user => user.Id == id)
            .FirstAsync();
    }

    public async Task<User> GetUserIncludingGroups(int id)
    {
        return await _context.User
            .Include(user => user.Groups)
            .Where(user => user.Id == id)
            .FirstAsync();
    }

    public async Task<User> GetUserIncludingPosts(int id)
    {
        return await _context.User
            .Include(user => user.Posts)
            .Where(user => user.Id == id)
            .FirstAsync();
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        var user = await _context.User.FirstOrDefaultAsync(u => u.Email == email);
        return user;
    }

    public async Task<bool> CanAccessGroup(int userId, int groupId)
    {
        var group = await _context.Group
            .Include(g => g.Users)
            .FirstOrDefaultAsync(g => g.Id == groupId);

        if (group is null)
        {
            return false;
        }

        var result = group.Users.Any(u => u.Id == userId);
        return result;
    }
}