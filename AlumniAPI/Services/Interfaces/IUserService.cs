using AlumniAPI.Models;
using MovieAPI.Services.Interfaces;

namespace AlumniAPI.Services.Interfaces;

public interface IUserService : IRepository<User>
{
    Task<User> GetUserIncludingMessages(int id);
    Task<User> GetUserIncludingGroups(int id);
    Task<User> GetUserIncludingPosts(int id);
    Task<User?> GetUserByEmail(string email);
    Task<bool> CanAccessGroup(int userId, int groupId);
}