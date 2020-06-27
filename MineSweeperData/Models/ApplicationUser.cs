using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeperData.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Score> Scores { get; set; }
        public ICollection<ChatHubMessage> ChatHubMessages { get; set; }
    }
}
