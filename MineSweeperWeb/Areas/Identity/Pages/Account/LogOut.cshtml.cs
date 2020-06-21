using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MineSweeperWeb.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LogOutModel : PageModel
    {
        readonly SignInManager<IdentityUser> SignInManager;

        public async Task OnGetAsync()
        {

        }
    }
}
