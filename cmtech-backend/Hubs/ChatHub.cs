using cmtech_backend.Models.Dtos;
using Microsoft.AspNetCore.SignalR;

namespace cmtech_backend.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(MessageDto messageDto)
        {
            await Clients.User(messageDto.recieverId.ToString()).SendAsync("RecieveMessage", Context.User.Identity.Name, messageDto);
            //await Clients.All.SendAsync("RecieveMessage", messageDto);
        }
    }
}
