using Minesweeper.Business.Dto;
using System.Threading.Tasks;

namespace Minesweeper.Web.SignalR
{
    public interface IChatClient
    {
        Task ReceiveSystemMessage(string message);

        Task ReceiveUserMessage(ChatHubMessageDto message);
    }
}
