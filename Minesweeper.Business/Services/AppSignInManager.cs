using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Minesweeper.Business.Dto;
using Minesweeper.Business.Interfaces;
using Minesweeper.Data.Entities;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Minesweeper.Business.Services
{
    public class AppSignInManager : IAppSignInManager
    {
        readonly SignInManager<ApplicationUser> _signInManager;
        readonly IMapper _mapper;
        
        public AppSignInManager(SignInManager<ApplicationUser> signInManager, IMapper mapper)
        {
            _signInManager = signInManager;
            _mapper = mapper;
        }

        public Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure) =>
            _signInManager.PasswordSignInAsync(userName, password, isPersistent, lockoutOnFailure);

        public bool IsSignedIn(ClaimsPrincipal principal) => _signInManager.IsSignedIn(principal);

        public Task SignOutAsync() => _signInManager.SignOutAsync();

        public Task SignInAsync(ApplicationUserDto user, bool isPersistent, string authenticationMethod = null)
        {
            var appUser = _mapper.Map<ApplicationUserDto, ApplicationUser>(user);
            return _signInManager.SignInAsync(appUser, isPersistent, authenticationMethod);
        }
    }
}
