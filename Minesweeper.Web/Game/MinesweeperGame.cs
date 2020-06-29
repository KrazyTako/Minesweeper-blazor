using System;

namespace Minesweeper.Web.Game
{
    public class MinesweeperGame
    {
        public int Rows { get; }
        public int Columns { get; }
        public int MineCount { get; }
        public int RevealToWin => (Rows * Columns) - MineCount;
        public int FlagCount { get; private set; }
        public int RevealedSuccess { get; private set; } = 0;
        public bool GameOver { get; private set; } = false;
        public TileProperty[][] gameBoard { get; private set; }

        public event EventHandler GameWon;

        public event EventHandler GameLost;

        private Random generator = new Random();
        public MinesweeperGame() : this(9, 9, 10) { }
        public MinesweeperGame(int rows, int columns, int mineCount)
        {
            Rows = rows;
            Columns = columns;
            MineCount = mineCount;
            gameBoard = new TileProperty[rows][];

            for (int i = 0; i < gameBoard.Length; i++)
            {
                gameBoard[i] = new TileProperty[columns];
                for (int j = 0; j < gameBoard[i].Length; j++)
                {
                    gameBoard[i][j] = new TileProperty();
                    gameBoard[i][j].Row = i;
                    gameBoard[i][j].Col = j;
                }
            }

            int count = 0;
            while (count < MineCount)
            {
                int randomRow = generator.Next(0, rows);
                int randomCol = generator.Next(0, columns);
                TileProperty tile = gameBoard[randomRow][randomCol];

                if (!tile.IsBomb)
                {
                    tile.IsBomb = true;
                    count++;
                }
            }

            bool markedFirstHelper = false;
            while (!markedFirstHelper)
            {
                int randomRow = generator.Next(0, rows);
                int randomCol = generator.Next(0, columns);
                TileProperty tile = gameBoard[randomRow][randomCol];

                if (!tile.IsBomb)
                {
                    markedFirstHelper = true;
                    tile.IsFirstHelper = true;
                }
            }

            IterateAll(tile =>
            {
                IterateNeighbors(tile, neighbor =>
                {
                    if (neighbor.IsBomb)
                    {
                        tile.SurroundingCount++;
                    }
                });
            });
        }

        public void Reveal(TileProperty tile)
        {
            if (tile.IsFlagged || tile.IsRevealed || GameOver)
            {
                return;
            }

            tile.IsRevealed = true;
            if (tile.IsBomb)
            {
                OnGameLose();
                return;
            }
            RevealedSuccess++;

            if (tile.SurroundingCount == 0)
            {
                RevealAllSurrounding(tile);
            }

            if (RevealedSuccess == RevealToWin)
            {
                GameOver = true;
                GameWon.Invoke(this, EventArgs.Empty);
            }
        }

        public void Flag(TileProperty tile)
        {
            if (tile.IsRevealed || GameOver)
            {
                return;
            }

            if (!tile.IsFlagged) 
            {
                FlagCount++;
            }
            else
            {
                FlagCount--;
            }
            tile.IsFlagged = !tile.IsFlagged;
        }

        public void Chord(TileProperty tile)
        {
            if (!tile.IsRevealed || GameOver)
            {
                return;
            }

            // Count surrounding flags
            int surroundingFlags = 0;
            IterateNeighbors(tile, neighbor =>
            {
                if (neighbor.IsFlagged)
                {
                    surroundingFlags++;
                }
            });

            // Make sure its equal to the surrounding count, otherwise ignore this action
            if (surroundingFlags == tile.SurroundingCount)
            {
                IterateNeighbors(tile, Reveal);
            }
        }

        private void OnGameLose()
        {
            GameOver = true;
            IterateAll(tile =>
            {
                if (tile.IsBomb)
                {
                    tile.IsRevealed = true;
                }
            });
            GameLost(this, EventArgs.Empty);
        }

        private void RevealAllSurrounding(TileProperty tile)
        {
            IterateNeighbors(tile, neighbor =>
            {
                if (!neighbor.IsRevealed)
                {
                    neighbor.IsRevealed = true;
                    RevealedSuccess++;
                    if (neighbor.SurroundingCount == 0)
                    {
                        RevealAllSurrounding(neighbor);
                    }
                }
            });
        }

        private void IterateAll(Action<TileProperty> action)
        {
            for (int i = 0; i < gameBoard.Length; i++)
            {
                for (int j = 0; j < gameBoard[i].Length; j++)
                {
                    var tile = gameBoard[i][j];
                    action.Invoke(tile);
                }
            }
        }

        private void IterateNeighbors(TileProperty tile, Action<TileProperty> action)
        {
            for (int xoff = -1; xoff <= 1; xoff++)
            {
                for (int yoff = -1; yoff <= 1; yoff++)
                {
                    var i = tile.Row + xoff;
                    var j = tile.Col + yoff;
                    if (i > -1 && i < Rows && j > -1 && j < Columns)
                    {
                        var neighbor = gameBoard[i][j];
                        action.Invoke(neighbor);
                    }
                }
            }
        }
    }
}
