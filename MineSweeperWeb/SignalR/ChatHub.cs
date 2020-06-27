using Microsoft.AspNetCore.SignalR;
using MineSweeperData.Services;
using System.Threading.Tasks;

namespace MineSweeperWeb.SignalR
{
    public class ChatHub : Hub<IChatClient>
    {
        readonly ChatHubMessagesService _chatHubMessagesService;
        public ChatHub(ChatHubMessagesService chatHubMessagesService)
        {
            _chatHubMessagesService = chatHubMessagesService;
        }
        public override Task OnConnectedAsync()
        {
            string name = Context.User.Identity.Name ?? Context.ConnectionId;
            Clients.All.ReceiveSystemMessage($"system : {name} joined the conversation");
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(System.Exception exception)
        {
            string name = Context.User.Identity.Name ?? Context.ConnectionId;
            Clients.All.ReceiveSystemMessage($"system : {name} left the conversation");
            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(string message)
        {
            var hubMessage = await _chatHubMessagesService.Add(message, Context.UserIdentifier);
            await Clients.All.ReceiveUserMessage(hubMessage);
        }
    }
}
