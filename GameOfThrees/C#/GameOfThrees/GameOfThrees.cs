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
            switch (inputNumber)
            {
                case 0:
                    MathSteps.Add(inputNumber);
                    return MathSteps;
                case 1:
                    return MathSteps;
                case 3:
                    MathSteps.Add((inputNumber / 3));
                    return MathSteps;
            }

            if (IsDivisableByThree(inputNumber))
            {
                HandleDivision(inputNumber);
            }
            if ((inputNumber+1) % 3 == 0)
            {
                HandleDivision(inputNumber+1);
            }
            if ((inputNumber-1) % 3 == 0)
            {
                HandleDivision(inputNumber-1);
            }
            return MathSteps;
        }

        private void HandleDivision(int inputNumber)
        {
            int inputNumberDivided = inputNumber/3;
            MathSteps.Add(inputNumberDivided);
            Play(inputNumberDivided);
        }

        private static bool IsDivisableByThree(int inputNumber)
        {
            return inputNumber%3 == 0;
        }
    }
}
