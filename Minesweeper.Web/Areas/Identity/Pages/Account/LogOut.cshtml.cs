using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Minesweeper.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LogOutModel : PageModel
    {
        public async Task OnGetAsync()
        {

        }
    }
}
