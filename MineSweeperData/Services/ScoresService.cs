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

        public async Task<Score> CreateNewScore(string name, string message, int width, int height, int mineCount, long elapsedMilliseconds)
        {
            Score newScore = new Score();
            newScore.Date = DateTime.Now;
            newScore.Name = name;
            newScore.Message = message;
            newScore.Width = width;
            newScore.Height = height;
            newScore.MineCount = mineCount;
            newScore.Time = TimeSpan.FromMilliseconds(elapsedMilliseconds);

            dbContext.Scores.Add(newScore);
            await dbContext.SaveChangesAsync();
            return newScore;
        }

        public async Task<IEnumerable<Score>> GetScoresInDateRange(DateTime start, DateTime end)
        {
            return await dbContext.Scores
                            .Where(score => score.Date > start && score.Date < end)
                            .ToListAsync();
        }
    }
}
