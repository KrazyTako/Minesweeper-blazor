using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MineSweeperWeb
{
    public class TileProperty
    {
        public bool IsBomb { get; set; }
        public bool IsRevealed { get; set; }
        public bool IsFlagged { get; set; }
        public string CssClass
        {
            get
            {
                if (!IsRevealed)
                {
                    return "tile-hidden";
                }
                return "tile-revealed";
            }
        }

        public string CssIcon
        {
            get
            {
                if (IsFlagged)
                {
                    return "oi oi-flag";
                }
                if (!IsRevealed)
                {
                    return "";
                }
                if (IsBomb)
                {
                    return "oi oi-x";
                }
                return "";
            }
        }
        public int SurroundingCount { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
    }
}
