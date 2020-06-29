using Microsoft.AspNetCore.SignalR;
using Minesweeper.Business.Interfaces;
using System.Threading.Tasks;

namespace Minesweeper.Web.SignalR
{
    public class ChatHub : Hub<IChatClient>
    {
        readonly IChatHubMessagesService _chatHubMessagesService;
        static int UserCount;

        public ChatHub(IChatHubMessagesService chatHubMessagesService)
        {
            _chatHubMessagesService = chatHubMessagesService;
        }
        public override Task OnConnectedAsync()
        {
            string name = Context.User.Identity.Name ?? Context.ConnectionId;
            Clients.All.ReceiveSystemMessage($"system : {name} joined the conversation");
            UserCount++;
            if (name.ToLower() == "krazytako")
            {
                Clients.Caller.ReceiveSystemMessage($"system : There are {UserCount} players connected");
            }
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(System.Exception exception)
        {
            string name = Context.User.Identity.Name ?? Context.ConnectionId;
            Clients.All.ReceiveSystemMessage($"system : {name} left the conversation");
            UserCount--;
            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(string message)
        {
            var hubMessage = await _chatHubMessagesService.Add(message, Context.UserIdentifier);
            await Clients.All.ReceiveUserMessage(hubMessage);
        }
    }
}
