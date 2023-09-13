using AlumniAPI.Models;
using MovieAPI.Services.Interfaces;

namespace AlumniAPI.Services.Interfaces;

public interface IReplyService : IRepository<Reply>
{
    Task<IEnumerable<Reply>> SearchRepliesVisibleToUser(int userId, string query);
}