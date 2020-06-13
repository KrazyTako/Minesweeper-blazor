using System.Collections.Generic;

namespace MineSweeperWeb
{
    public class Difficulty
    {
        private static IDictionary<string, Difficulty> _dic = new Dictionary<string, Difficulty>();

        public readonly static Difficulty BEGINNER        = new Difficulty("Beginner", 9, 9, 10);
        public readonly static Difficulty INTERMEDIATE    = new Difficulty("Intermediate", 16, 16, 40);
        public readonly static Difficulty EXPERT          = new Difficulty("Expert", 16, 30, 99);
        public readonly static Difficulty IMPOSSIBLE      = new Difficulty("Impossible", 30, 30, 250);
        public readonly static Difficulty CUSTOM          = new Difficulty("Custom", 0, 0, 0);

        public string Name { get; }
        public int Rows { get; }
        public int Columns { get; }
        public int Mines { get; }
        private Difficulty(string name, int rows, int columns, int mines)
        {
            Name = name;
            Rows = rows;
            Columns = columns;
            Mines = mines;
            _dic[name] = this;
        }

        public static Difficulty GetByName(string name)
        {
            return _dic[name];
        }

        public static IEnumerable<Difficulty> GetAll()
        {
            return _dic.Values;
        }
    }
}
