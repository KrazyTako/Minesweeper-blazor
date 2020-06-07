using Microsoft.EntityFrameworkCore;
using MineSweeperData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<Score>> GetScoresInDateRange(DateTime start, DateTime end)
        {
            return await dbContext.Scores
                            .Where(score => score.Date > start && score.Date < end)
                            .ToListAsync();
        }
    }
}
