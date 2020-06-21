using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeperData.Models
{
    public class ApplicationUser : IdentityUser
    {
        public IList<Score> Scores { get; set; }
    }
}
