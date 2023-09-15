using AlumniAPI.Models;
using MovieAPI.Services.Interfaces;

namespace AlumniAPI.Services.Interfaces;

public interface IReplyService : IRepository<Reply>
{
    /// <summary>
    /// Finds all replies that are visible to the user that contain the search query.
    /// Case insensitive.
    /// </summary>
    /// <param name="userId">User's id</param>
    /// <param name="query">String that should be searched for</param>
    /// <returns>List of found replies</returns>
    Task<IEnumerable<Reply>> SearchRepliesVisibleToUser(int userId, string query);
}