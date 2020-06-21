using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MineSweeperData.Models;

namespace MineSweeperData
{
    public class MinesweeperDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Score> Scores { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public MinesweeperDbContext(DbContextOptions<MinesweeperDbContext> options) : base(options) { }
    }
}
