using Microsoft.EntityFrameworkCore;
using MineSweeperData.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MineSweeperData.Services
{
    public class ScoresService
    {
        readonly MinesweeperDbContext dbContext;
        public ScoresService(MinesweeperDbContext context)
        {
            dbContext = context;
        }

        public async Task<IEnumerable<Score>> GetAllScores()
        {
            return await dbContext.Scores.ToListAsync();
        }

        public async Task<Score> CreateNewScore(Score score)
        {
            dbContext.Scores.Add(score);
            await dbContext.SaveChangesAsync();
            return score;
        }
    }
}
