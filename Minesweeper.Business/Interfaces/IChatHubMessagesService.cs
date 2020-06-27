using Minesweeper.Business.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Minesweeper.Business.Interfaces
{
    public interface IChatHubMessagesService
    {
        public Task<ChatHubMessageDto> Add(string msgContent, string applicationUserId);

        public Task<IList<ChatHubMessageDto>> GetAll();
    }
}
