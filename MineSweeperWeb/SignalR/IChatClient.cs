using System.Threading.Tasks;

namespace MineSweeperWeb.SignalR
{
    public interface IChatClient
    {
        Task ReceiveMessage(string name, string message);

        Task SendMessage(string userId, string message);
    }
}
