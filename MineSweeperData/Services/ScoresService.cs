﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MineSweeperData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MineSweeperData.Services
{
    public class ScoresService
    {
        readonly IServiceScopeFactory _serviceScopeFactory;
        public ScoresService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task<IEnumerable<Score>> GetAllScores()
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<MinesweeperDbContext>();
                return await context.Scores.ToListAsync();
            }
        }

        public async Task<Score> CreateUserScore(string userId, int width, int height, int mineCount, long elapsedMilliseconds)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<MinesweeperDbContext>();
                Score newScore = new Score();
                newScore.ApplicationUserId = userId;
                newScore.Name = "";
                newScore.Date = DateTime.Now;
                newScore.Width = width;
                newScore.Height = height;
                newScore.MineCount = mineCount;
                newScore.Time = TimeSpan.FromMilliseconds(elapsedMilliseconds);

                context.Scores.Add(newScore);
                await context.SaveChangesAsync();
                return newScore;
            }
        }

        public async Task<Score> CreateAnonymousScore(string name, string message, int width, int height, int mineCount, long elapsedMilliseconds)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<MinesweeperDbContext>();
                Score newScore = new Score();
                newScore.Date = DateTime.Now;
                newScore.Name = name;
                newScore.Message = message;
                newScore.Width = width;
                newScore.Height = height;
                newScore.MineCount = mineCount;
                newScore.Time = TimeSpan.FromMilliseconds(elapsedMilliseconds);

                context.Scores.Add(newScore);
                await context.SaveChangesAsync();
                return newScore;
            }
        }

        public async Task<IEnumerable<Score>> GetScoresByUserId(string userId)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<MinesweeperDbContext>();
                return await context.Scores
                                  .Where(score => score.ApplicationUserId == userId)
                                  .ToListAsync();
            }
        }

        public async Task<IEnumerable<Score>> GetScoresInDateRange(DateTime start, DateTime end)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<MinesweeperDbContext>();
                return await context.Scores
                            .Where(score => score.Date > start && score.Date < end)
                            .ToListAsync();
            }
        }
    }
}
