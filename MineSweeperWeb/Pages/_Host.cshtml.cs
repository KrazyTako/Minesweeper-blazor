using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MineSweeperWeb.Pages
{
    public class _Host : PageModel
    {
        public string SessionCookie { get; set; }

        public void OnGet()
        {
            SessionCookie = HttpContext.Request.Cookies[".AspNetCore.Identity.Application"];
        }
    }
}
