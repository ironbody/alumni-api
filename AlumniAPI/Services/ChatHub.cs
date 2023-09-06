using AlumniAPI.Services.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace AlumniAPI.Services;

public class ChatHub : Hub
{
    public async Task JoinChat(string chatId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, chatId);
    }
    
    public async Task SendMessageToAll(string message, int userId)
    {
        await Clients.All.SendAsync("ReceiveMessage", message, userId);
    }
    public async Task SendMessageToChat(string message, string chatId, int userId)
    {
        await Clients.Group(chatId).SendAsync("ReceiveMessage", message, userId);
    }
}
