using AlumniAPI.Models;
using MovieAPI.Services.Interfaces;

namespace AlumniAPI.Services.Interfaces;

public interface IGroupService: IRepository<Group>
{
    Task<Group> GetGroupIncludingUsers(int id);
    Task<Group> GetGroupIncludingPosts(int id);
    Task UpdateGroupUsers(Group group, IEnumerable<int> userIds);
    Task<Group?> GetByIdAsync(int id, int userId);
}