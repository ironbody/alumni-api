using AlumniAPI.Models;
using MovieAPI.Services.Interfaces;

namespace AlumniAPI.Services.Interfaces;

public interface IUserService: IRepository<User>
{
    Task<User> GetUserIncludingMessages(int id);
    Task<User> GetUserIncludingGroups(int id);
    Task<User> GetUserIncludingPosts(int id);
    Task<User> GetUserIncludingReplies(int id);
    Task UpdateUserGroups(User user, IEnumerable<int> groupIds);
    Task UpdateUserPosts(User user, IEnumerable<int> postIds);
    Task UpdateUserReplies(User user, IEnumerable<int> repliesIds);
}