namespace Minesweeper.Web
{
    public class TileProperty
    {
        public bool IsBomb { get; set; }
        public bool IsFirstHelper { get; set; }
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
                if (IsFirstHelper && !IsRevealed)
                {
                    return "oi oi-circle-check";
                }
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
