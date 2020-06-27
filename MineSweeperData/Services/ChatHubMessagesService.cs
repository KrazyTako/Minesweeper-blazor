using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MineSweeperData.Models;
using MineSweeperData.ServiceModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MineSweeperData.Services
{
    public class ChatHubMessagesService
    {
        readonly IServiceScopeFactory _serviceScopeFactory;
        readonly IMapper _mapper;

        public ChatHubMessagesService(IServiceScopeFactory serviceScopeFactory, IMapper mapper)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _mapper = mapper;
        }

        public async Task<ChatHubMessageDto> Add(string msgContent, string applicationUserId)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<MinesweeperDbContext>();
                var message = new ChatHubMessage()
                {
                    ApplicationUserId = applicationUserId,
                    Content = msgContent,
                    Date = DateTime.UtcNow,
                };
                context.ChatHubMessages.Add(message);
                await context.SaveChangesAsync();
                await context.Entry(message).Reference(msg => msg.ApplicationUser).LoadAsync();
                return _mapper.Map<ChatHubMessage, ChatHubMessageDto>(message);
            }
        }

        public async Task<IList<ChatHubMessageDto>> GetAll()
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<MinesweeperDbContext>();
                var messages = await context.ChatHubMessages
                                    .Include(hubMsg => hubMsg.ApplicationUser)
                                    .ToListAsync();
                return _mapper.Map<List<ChatHubMessage>, List<ChatHubMessageDto>>(messages);
            }
        }
    }
}
