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

    public async Task<User> GetUserIncludingReplies(int id)
    {
        return await _context.User
            .Include(user => user.Replies)
            .Where(user => user.Id == id)
            .FirstAsync();
    }


    public async Task UpdateUserGroups(User user, IEnumerable<int> groupIds)
    {
        var newGroups = new List<Group>();
        foreach (var groupId in groupIds)
        {
            var group = await _context.Group.FindAsync(groupId);
            if (group == null)
            {
                throw new KeyNotFoundException($"Group with id {groupId} does not exist.");
            }
            newGroups.Add(group);
        }

        user.Groups = newGroups;

        await UpdateAsync(user);
    }

    public async Task UpdateUserPosts(User user, IEnumerable<int> postIds)
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

        user.Posts = newPosts;

        await UpdateAsync(user);
    }

    public async Task UpdateUserReplies(User user, IEnumerable<int> repliesIds)
    {
        var newReplies = new List<Reply>();
        foreach (var replyId in repliesIds)
        {
            var reply = await _context.Reply.FindAsync(replyId);
            if (reply == null)
            {
                throw new KeyNotFoundException($"Reply with id {replyId} does not exist.");
            }
            newReplies.Add(reply);
        }

        user.Replies = newReplies;

        await UpdateAsync(user);
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
    public async Task<List<ConversationWithLatestMessage>> GetChats(int userId)
    {
        var conversations = _context.User
            .Where(user => user.Id != userId)
            .Select(user => new
            {
                User = user,
                LatestMessage = user.SentMessages
                    .Where(msg => msg.RecipientId == userId)
                    .Concat(user.ReceivedMessages.Where(msg => msg.SenderId == userId))
                    .OrderByDescending(msg => msg.SentTime)
                    .FirstOrDefault()
            })
            .Where(conversation => conversation.LatestMessage != null)
            .ToList()
            .Select(conversation => new ConversationWithLatestMessage
            {
                UserId = conversation.User.Id,
                Name = conversation.User.Name,
                AvatarURL = conversation.User.AvatarURL,
                Body = conversation.LatestMessage?.Body,
                SentTime = conversation.LatestMessage?.SentTime ?? new()
            })
            .ToList();

        return conversations;
    }
}

public class ConversationWithLatestMessage
{
    public int UserId { get; set; }
    public string? Name { get; set; }
    public string? AvatarURL { get; set; }
    public string? Body { get; set; }
    public DateTime SentTime { get; set; }
    
}