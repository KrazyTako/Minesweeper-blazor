using System;

namespace Minesweeper.Business.Dto
{
    public class ChatHubMessageDto
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string UserName { get; set; }

        public DateTime Date { get; set; }
    }
}
