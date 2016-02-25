using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfThrees
{
    public class GameOfThrees
    {
        public int Play(int inputNumber)
        {
            if (inputNumber == 0)
            {
                return 0;
            }

            if (inputNumber == 3)
            {
                return 1;
            }
            return inputNumber;
        }
    }
}
