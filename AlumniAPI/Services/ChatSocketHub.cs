using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace AlumniAPI.Services;

[Authorize]
public class ChatSocketHub : Hub
{
    public async Task JoinChat(int userId)
    =>
        await Groups
            .AddToGroupAsync(Context.ConnectionId, userId.ToString());
    
    public async Task SendMessageToUser(string body, int senderId, int recipientId)
    {
        await Clients
            .Group(senderId.ToString())
            .SendAsync("ReceiveMessage", body, senderId, DateTime.UtcNow,recipientId);
        await Clients
            .Group(recipientId.ToString())
            .SendAsync("ReceiveMessage", body, senderId, DateTime.UtcNow,recipientId);
    }
}
