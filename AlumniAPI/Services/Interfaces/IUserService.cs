using AlumniAPI.Models;
using MovieAPI.Services.Interfaces;

namespace AlumniAPI.Services.Interfaces;

public interface IUserService: IRepository<User>
{
    Task<User> GetUserIncludingMessages(int id);
    Task<User> GetUserIncludingGroups(int id);
    Task<User> GetUserIncludingPosts(int id);
    
}