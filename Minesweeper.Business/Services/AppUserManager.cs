using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Minesweeper.Business.Dto;
using Minesweeper.Business.Interfaces;
using Minesweeper.Data.Entities;
using System.Threading.Tasks;

namespace Minesweeper.Business.Services
{
    public class AppUserManager : IAppUserManager
    {
        readonly UserManager<ApplicationUser> _userManager;
        readonly IMapper _mapper;
        public AppUserManager(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public Task<IdentityResult> CreateAsync(ApplicationUserDto user, string password)
        {
            var appUser = _mapper.Map<ApplicationUserDto, ApplicationUser>(user);
            return _userManager.CreateAsync(appUser, password);
        }

        public Task<string> GenerateEmailConfirmationTokenAsync(ApplicationUserDto user)
        {
            var appUser = _mapper.Map<ApplicationUserDto, ApplicationUser>(user);
            return _userManager.GenerateEmailConfirmationTokenAsync(appUser);
        }

        public IdentityOptions Options => _userManager.Options;
    }
}
