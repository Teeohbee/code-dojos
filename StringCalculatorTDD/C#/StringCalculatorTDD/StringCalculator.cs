using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorTDD
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers)) return 0;

            List<string> stringSeparators = new List<string>() {",", "\n"};

            if (numbers.StartsWith("//"))
            {
                stringSeparators = new List<string>() {numbers[2].ToString()};
                numbers = numbers.Substring(4);
            }

            string[] splitNumbers = numbers.Split(stringSeparators.ToArray(), StringSplitOptions.None);
            var sum = Sum(splitNumbers);
            var negativeNumbers = NegativeNumbers(splitNumbers);
            if (negativeNumbers.Any())
            {
                string[] negativeNumbersArray = negativeNumbers.ToArray();
                throw new ArgumentException("negatives not allowed: " + string.Join(", ", negativeNumbersArray));
            }
            return sum;
        }

        private static List<string> NegativeNumbers(string[] splitNumbers)
        {
            List<string> negativeNumbers = new List<string>();
            foreach (string number in splitNumbers)
            {
                if (number[0].Equals('-'))
                {
                    negativeNumbers.Add(number);
                }
            }
            return negativeNumbers;
        }

        private static int Sum(string[] splitNumbers)
        {
            int sum = 0;
            foreach (string number in splitNumbers)
            {
                sum += int.Parse(number);
            }
            return sum;
        }
    }
}
