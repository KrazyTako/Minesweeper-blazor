using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Minesweeper.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Score> Scores { get; set; }
        public ICollection<ChatHubMessage> ChatHubMessages { get; set; }
    }
}
