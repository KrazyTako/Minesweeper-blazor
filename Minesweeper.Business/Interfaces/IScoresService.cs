using Minesweeper.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Minesweeper.Business.Interfaces
{
    public interface IScoresService
    {
        public Task<IEnumerable<Score>> GetAllScores();

        public Task<Score> CreateUserScore(string userId, int width, int height, int mineCount, long elapsedMilliseconds);

        public Task<IEnumerable<Score>> GetScoresByUserId(string userId);

        public Task<IEnumerable<Score>> GetScoresInDateRange(DateTime start, DateTime end);
    }
}
