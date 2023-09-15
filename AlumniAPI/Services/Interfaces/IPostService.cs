using AlumniAPI.Models;
using MovieAPI.Services.Interfaces;

namespace AlumniAPI.Services.Interfaces;

public interface IPostService : IRepository<Post>
{
    /// <summary>
    /// Retrieves all posts from the groups the user is in.
    /// </summary>
    /// <param name="userId">User's Id</param>
    /// <returns>List of found posts</returns>
    Task<IEnumerable<Post>> GetAllPostsVisibleToUser(int userId);

    /// <summary>
    /// Finds all posts that is visible to the user containing the search string in its title or body.
    /// Case insensitive.
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="query"></param>
    /// <returns></returns>
    Task<IEnumerable<Post>> SearchPostsVisibleToUser(int userId, string query);

    /// <summary>
    /// Checks if the user is in the group that the post is posted to
    /// </summary>
    /// <param name="postId">Post's Id</param>
    /// <param name="userId">User's Id</param>
    /// <returns>True if the user is in same group as the post. False otherwise.</returns>
    Task<bool> PostIsVisibleToUser(int postId, int userId);
}