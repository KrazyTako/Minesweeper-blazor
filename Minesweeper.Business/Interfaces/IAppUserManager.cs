using Microsoft.AspNetCore.Identity;
using Minesweeper.Business.Dto;
using System.Threading.Tasks;

namespace Minesweeper.Business.Interfaces
{
    public interface IAppUserManager
    {
        public Task<IdentityResult> CreateAsync(ApplicationUserDto user, string password);
        public Task<string> GenerateEmailConfirmationTokenAsync(ApplicationUserDto user);
        public IdentityOptions Options { get; }
    }
}
