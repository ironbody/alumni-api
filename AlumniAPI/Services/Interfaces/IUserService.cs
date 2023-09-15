using AlumniAPI.Models;
using MovieAPI.Services.Interfaces;

namespace AlumniAPI.Services.Interfaces;

public interface IUserService : IRepository<User>
{
    // TODO: Add ✨Documentation✨


    /// <summary>
    /// Retrieves a user by id with the messages list included.
    /// </summary>
    /// <param name="id">The user's id</param>
    Task<User> GetUserIncludingMessages(int id);

    /// <summary>
    /// Retrieves the conversations a user has with other people.
    /// </summary>
    /// <param name="id">User's id</param>
    Task<List<ConversationWithLatestMessage>> GetChats(int id);

    /// <summary>
    /// Retrieves a user with the groups list included.
    /// </summary>
    /// <param name="id">User's id</param>
    Task<User> GetUserIncludingGroups(int id);

    /// <summary>
    /// Retrieves a user with the posts list included.
    /// </summary>
    /// <param name="id">User's id</param>
    Task<User> GetUserIncludingPosts(int id);

    /// <summary>
    /// Retrieves a user with the replies list included.
    /// </summary>
    /// <param name="id">User's id</param>
    /// <returns></returns>
    Task<User> GetUserIncludingReplies(int id);

    /// <summary>
    /// Replaces the user's associated groups with the given list of ids.
    /// </summary>
    /// <param name="user">User object</param>
    /// <param name="groupIds">List of groups denoted by their ids</param>
    Task UpdateUserGroups(User user, IEnumerable<int> groupIds);

    /// <summary>
    /// Replaces the user's associated posts with the given list of ids.
    /// </summary>
    /// <param name="user">User object</param>
    /// <param name="postIds">List of posts denoted by their ids</param>
    Task UpdateUserPosts(User user, IEnumerable<int> postIds);

    /// <summary>
    /// Replaces the user's associated replies with the given list of ids.
    /// </summary>
    /// <param name="user">User object</param>
    /// <param name="repliesIds">List of replies denoted by their ids</param>
    Task UpdateUserReplies(User user, IEnumerable<int> repliesIds);

    /// <summary>
    /// Retrieves a user by their email 
    /// </summary>
    /// <param name="email">User's email</param>
    /// <returns>Found user or null</returns>
    Task<User?> GetUserByEmail(string email);

    /// <summary>
    /// Checks whether the user is has access to the group's posts
    /// </summary>
    /// <param name="userId">User's id</param>
    /// <param name="groupId">Group's id</param>
    /// <returns>True if the user is in the group. False if they are not.</returns>
    Task<bool> CanAccessGroup(int userId, int groupId);
}