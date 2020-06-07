using Microsoft.EntityFrameworkCore;
using MineSweeperData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeperData
{
    public class MinesweeperDbContext : DbContext
    {
        public DbSet<Score> Scores { get; set; }
        public MinesweeperDbContext(DbContextOptions<MinesweeperDbContext> options) : base(options) { }
    }
}
