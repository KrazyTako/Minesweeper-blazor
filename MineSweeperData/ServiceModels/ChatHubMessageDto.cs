using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeperData.ServiceModels
{
    public class ChatHubMessageDto
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string UserName { get; set; }

        public DateTime Date { get; set; }
    }
}
