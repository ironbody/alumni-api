using AlumniAPI.Models;
using MovieAPI.Services.Interfaces;

namespace AlumniAPI.Services.Interfaces;

public interface IPostService : IRepository<Post>
{
    Task<IEnumerable<Post>> GetAllPostsVisibleToUser(int userId);
    Task<IEnumerable<Post>> SearchPostsVisibleToUser(int userId, string query);
    Task<bool> PostIsVisibleToUser(int postId, int userId);
}