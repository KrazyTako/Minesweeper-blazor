using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Minesweeper.Data.Entities;

namespace Minesweeper.Data
{
    public class MinesweeperDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Score> Scores { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ChatHubMessage> ChatHubMessages { get; set; }
        public MinesweeperDbContext(DbContextOptions<MinesweeperDbContext> options) : base(options) { }
    }
}
