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
        public string BackgroundColor { get; set; } = "lightgrey";
        public string Message { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
    }
}
