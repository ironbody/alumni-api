using AlumniAPI.Models;
using MovieAPI.Services.Interfaces;

namespace AlumniAPI.Services.Interfaces;

public interface IPostService: IRepository<Post>
{
    Task<IEnumerable<Post>> GetAllPostsVisibleToUser(int userId);
    Task<bool> PostIsVisibleToUser(int postId, int userId);
}