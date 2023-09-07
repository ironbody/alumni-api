using AlumniAPI.Services.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace AlumniAPI.Services;

public class ChatSocketHub : Hub
{
    public async Task JoinChat(int userId)
    {
        await Groups
            .AddToGroupAsync(Context.ConnectionId, userId.ToString());
    }
    
    public async Task SendMessageToAll(string message, int fromUserId, int toUserId)
    {
        await Clients
            .Group(toUserId.ToString())
            .SendAsync("ReceiveMessage", message, fromUserId);
    }
}
