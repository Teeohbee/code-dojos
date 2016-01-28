using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorTDD
{
    public class StringCalculator
    {
        public List<string> StringSeparators = new List<string>() { ",", "\n" };
        public int Add(string numbers)
        {
            if (IsEmptyString(numbers))
            {
                return HandleEmptyString();
            }

            if (HasDelimiterLine(numbers))
            {
                numbers = HandleDelimiterLine(numbers);
            }

            string[] splitNumbers = numbers.Split(StringSeparators.ToArray(), StringSplitOptions.None);

            if (ContainsNegatives(numbers))
            {
                HandleNegativeNumbers(splitNumbers);
            }

            var sum = splitNumbers.Sum(int.Parse);
            return sum;
        }

        private void HandleNegativeNumbers(string[] splitNumbers)
        {
            string[] negativeNumbers = ReturnNegativeNumbers(splitNumbers);
            throw new ArgumentException("negatives not allowed: " + string.Join(", ", negativeNumbers));
        }

        private bool ContainsNegatives(string numbers)
        {
            return numbers.Contains("-");
        }

        private string HandleDelimiterLine(string numbers)
        {
            StringSeparators = new List<string>() {numbers[2].ToString()};
            numbers = numbers.Substring(4);
            return numbers;
        }

        private bool IsEmptyString(string numbers)
        {
            return string.IsNullOrEmpty(numbers);
        }

        private int HandleEmptyString()
        {
            return 0;
        }

        private bool HasDelimiterLine(string numbers)
        {
            return numbers.StartsWith("//");
        }

        private static string[] ReturnNegativeNumbers(string[] splitNumbers)
        {
            return splitNumbers.Where(number => number[0].Equals('-')).ToArray();
        }
    }
}
