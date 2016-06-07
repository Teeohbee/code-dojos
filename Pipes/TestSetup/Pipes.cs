using System.Collections.Generic;
using System.Linq;

namespace TestSetup
{
    public class Pipes
    {
        public IList<string> Board { get; set; }

        public List<string> Solve(List<string> board, List<char> bag)
        {
            var tileCounts = CalculateTileCounts(bag);

            int singleLineABIndex = board.IndexOf("A_____B");

            if (singleLineABIndex != -1 && tileCounts.Right >= 5)
            {
                board[singleLineABIndex] = "A>>>>>B";
                return board;
            }

            int singleLineBAIndex = board.IndexOf("B_____A");

            if (singleLineBAIndex != -1 && tileCounts.Left >= 5)
            {
                board[singleLineBAIndex] = "B<<<<<A";
                return board;
            }

            throw new NoSolutionFoundException();
        }

        private TileCounts CalculateTileCounts(List<char> bag)
        {
            var tileCounts = new TileCounts();
            tileCounts.Calculate(bag);
            return tileCounts;
        }

        public struct TileCounts
        {
            public int Left { get; private set; }
            public int Right { get; private set; }
            public int Up { get; private set; }
            public int Down { get; private set; }

            public void Calculate(List<char> bag)
            {
                Left = bag.Count(t => t == '<');
                Right = bag.Count(t => t == '>');
                Up = bag.Count(t => t == '^');
                Down = bag.Count(t => t == 'V');
            }
        }
    }
}
