using MineSweeperData.Models;
using MineSweeperData.ServiceModels;
using System.Threading.Tasks;

namespace MineSweeperWeb.SignalR
{
    public interface IChatClient
    {
        Task ReceiveSystemMessage(string message);

        Task ReceiveUserMessage(ChatHubMessageDto message);
    }
}
