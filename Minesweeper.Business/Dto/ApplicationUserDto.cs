using System;

namespace Minesweeper.Business.Dto
{
    public class ApplicationUserDto 
    {
        public ApplicationUserDto()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }
        public string PasswordHash { get; set; }
        public bool EmailConfirmed { get; set; }
        public string NormalizedEmail { get; set; }
        public string Email { get; set; }
        public string NormalizedUserName { get; set; }
        public string UserName { get; set; }
    }
}
