using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfThrees
{
    public class GameOfThrees
    {
        public string Play(int inputNumber)
        {
            StringBuilder MathSteps = new StringBuilder();
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
            if (inputNumberDivided == 3)
            {
                MathSteps.Append(",");
                MathSteps.Append((inputNumberDivided / 3).ToString());
                return MathSteps.ToString();
            }
            return inputNumber.ToString();
        }
    }
}
