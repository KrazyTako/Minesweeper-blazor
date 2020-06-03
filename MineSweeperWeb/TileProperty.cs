﻿using Microsoft.AspNetCore.SignalR;
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
        public string BackgroundColor { get; set; } = "lightgrey";
        public string Message
        {
            get
            {
                if(IsFlagged)
                {
                    return "?";
                }
                if(!IsRevealed)
                {
                    return "";
                }
                if(IsBomb)
                {
                    return "X";
                }
                else
                {
                    return SurroundingCount.ToString();
                }
            }
        }
        public int SurroundingCount { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
    }
}
