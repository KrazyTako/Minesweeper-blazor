using Microsoft.AspNetCore.Identity;
using Minesweeper.Business.Dto;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Minesweeper.Business.Interfaces
{
    public interface IAppSignInManager
    {
        public Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure);
        
        public Task SignInAsync(ApplicationUserDto user, bool isPersistent, string authenticationMethod = null);

        public bool IsSignedIn(ClaimsPrincipal principal);

        public Task SignOutAsync();
    }
}
