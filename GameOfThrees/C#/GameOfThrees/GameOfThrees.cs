using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfThrees
{
    public class GameOfThrees
    {
        StringBuilder MathSteps = new StringBuilder();

        public string Play(int inputNumber)
        {
            if (inputNumber == 0)
            {
                return inputNumber.ToString();
            }

            if (inputNumber == 3)
            {
                MathSteps.Append((inputNumber / 3).ToString());
                return MathSteps.ToString();
            }

            int inputNumberDivided = inputNumber/3;
            MathSteps.Append(inputNumberDivided);
            MathSteps.Append(",");
            Play(inputNumberDivided);
            return MathSteps.ToString();
        }
    }
}
