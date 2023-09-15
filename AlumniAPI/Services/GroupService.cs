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
    public async Task<Group?> GetByIdAsync(int id, int userId)
    {
        return await _context.Group
            .Where(g => g.Id == id && g.Users.Any(u => u.Id == userId))
            .Include(g => g.Users)
            .FirstOrDefaultAsync();
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

    public async Task<Group> GetGroupIncludingUsers(int id)
    {
        return await _context.Group
            .Include(group => group.Users)
            .Where(group => group.Id == id)
            .FirstAsync();
    }

    public async Task<Group> GetGroupIncludingPosts(int id)
    {
        return await _context.Group
            .Include(group => group.Posts)
            .ThenInclude(post => post.Creator)
            .Include(group => group.Posts)
            .ThenInclude(post => post.EventInfo)
            .Where(group => group.Id == id)
            .FirstAsync();
    }

    public async Task UpdateGroupUsers(Group group, IEnumerable<int> userIds)
    {
        var newUsers = new List<User>();
        foreach (var userId in userIds)
        {
            var user = await _context.User.FindAsync(userId);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with id {userId} does not exist.");
            }
            newUsers.Add(user);
        }

        group.Users = newUsers;

        await UpdateAsync(group);
    }

    public async Task UpdateGroupPosts(Group group, IEnumerable<int> postIds)
    {
        var newPosts = new List<Post>();
        foreach (var postId in postIds)
        {
            var post = await _context.Post.FindAsync(postId);
            if (post == null)
            {
                throw new KeyNotFoundException($"Post with id {postId} does not exist.");
            }
            newPosts.Add(post);
        }

        group.Posts = newPosts;

        await UpdateAsync(group);
    }
}