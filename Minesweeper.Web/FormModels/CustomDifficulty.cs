﻿using System.ComponentModel.DataAnnotations;

namespace Minesweeper.Web.FormModels
{
    public class CustomDifficulty
    {
        [Range(5, 30)]
        public int Rows { get; set; }
        [Range(5, 30)]
        public int Columns { get; set; }
        public int Mines { get; set; }
    }
}
