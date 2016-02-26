using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfThrees
{
    public class GameOfThrees
    {
        List<int> MathSteps = new List<int>();

        public List<int> Play(int inputNumber)
        {
            if (inputNumber == 0)
            {
                MathSteps.Add(inputNumber);
                return MathSteps;
            }

            if (inputNumber == 1)
            {
                MathSteps.Add(inputNumber);
                return MathSteps;
            }

            if (inputNumber == 3)
            {
                MathSteps.Add((inputNumber / 3));
                return MathSteps;
            }

            if (inputNumber%3 == 0)
            {
                int inputNumberDivided = inputNumber / 3;
                MathSteps.Add(inputNumberDivided);
                Play(inputNumberDivided);
            }
            if ((inputNumber+1) % 3 == 0)
            {
                MathSteps.Add(1);
                int inputNumberDivided = (inputNumber+1) / 3;
                MathSteps.Add(inputNumberDivided);
                Play(inputNumberDivided);
            }
            if ((inputNumber-1) % 3 == 0)
            {
                MathSteps.Add(-1);
                int inputNumberDivided = (inputNumber-1) / 3;
                MathSteps.Add(inputNumberDivided);
                Play(inputNumberDivided);
            }
            return MathSteps;
        }
    }
}
