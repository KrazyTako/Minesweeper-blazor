using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace MineSweeperWeb.SignalR
{
    public class ChatHub : Hub<IChatClient>
    {
        public override Task OnConnectedAsync()
        {
            string name = Context.User.Identity.Name ?? Context.ConnectionId;
            Clients.All.ReceiveMessage("system", $"{name} joined the conversation");
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(System.Exception exception)
        {
            string name = Context.User.Identity.Name ?? Context.ConnectionId;
            Clients.All.ReceiveMessage("system", $"{name} left the conversation");
            return base.OnDisconnectedAsync(exception);
        }

        public void SendMessage(string message)
        {
            Clients.All.ReceiveMessage(Context.User.Identity.Name, message);
        }
    }
}
