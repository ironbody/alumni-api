using AlumniAPI.Models;
using MovieAPI.Services.Interfaces;

namespace AlumniAPI.Services.Interfaces;

public interface IGroupService: IRepository<Group>
{
    /// <summary>
    /// Retrieves a group with the users list included
    /// </summary>
    /// <param name="id">Group's id</param>
    /// <returns>Found group</returns>
    Task<Group> GetGroupIncludingUsers(int id);
    
    /// <summary>
    /// Retrieves a group with the posts list included
    /// </summary>
    /// <param name="id">Group's id</param>
    /// <returns>Found group</returns>
    Task<Group> GetGroupIncludingPosts(int id);
    
    /// <summary>
    /// Replaces the group's associated users with the given list of ids.
    /// </summary>
    /// <param name="group">Group object</param>
    /// <param name="userIds">List of users denoted by their ids</param>
    Task UpdateGroupUsers(Group group, IEnumerable<int> userIds);
    
    /// <summary>
    /// Replaces the group's associated posts with the given list of ids.
    /// </summary>
    /// <param name="group">Group object</param>
    /// <param name="postIds">List of posts denoted by their ids</param>
    Task UpdateGroupPosts(Group group, IEnumerable<int> postIds);
}