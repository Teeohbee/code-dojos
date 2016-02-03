using System;
using NUnit.Framework;

namespace StringCalculatorTDD
{
    [TestFixture]
    class StringCalculatorTests
    {
        public StringCalculator Calculator;

        [SetUp]
        public void Init()
        {
            Calculator = new StringCalculator();
        }

        [Test]
        public void ShouldReturnZeroWhenGivenNoNumbers()
        {
            Assert.AreEqual(0, Calculator.Add(""));
        }
        [Test]
        public void ShouldReturnOneWhenGivenTheStringOne()
        {
            Assert.AreEqual(1, Calculator.Add("1"));
        }
        [Test]
        public void ShouldReturnTwoWhenGivenTheStringTwo()
        {
            Assert.AreEqual(2, Calculator.Add("2"));
        }
        [Test]
        public void ShouldReturnThreeWhenGivenTheStringOneAndTwo()
        {
            Assert.AreEqual(3, Calculator.Add("1,2"));
        }
        [TestCase("1,2,3", 6)]
        [TestCase("9,3,7,4", 23)]
        [TestCase("3,7,9,7,4", 30)]
        [TestCase("2,5,7,9,3,10", 36)]
        public void ShouldHandleAnUnknownAmountOfNumbers(string input, int expected)
        {
            Assert.AreEqual(expected, Calculator.Add(input));
        }
        [Test]
        public void ShouldHandleNewLinesBetweenNumbers()
        {
            Assert.AreEqual(6, Calculator.Add("1\n2,3"));
        }
        [Test]
        public void ShouldSupportDeclarationOfDifferentDelimiters()
        {
            Assert.AreEqual(3, Calculator.Add("//;\n1;2"));
        }
        [Test]
        [ExpectedException( typeof( ArgumentException ), ExpectedMessage="negatives not allowed: -1, -4" )]
        public void ShouldThrowExceptionWhenGivenNegativeNumbers()
        {
           Calculator.Add("1,-1,-4,6,7");
        }
        [Test]
        public void ShouldIgnoreNumbersBiggerThanOneThousand()
        {
            Assert.AreEqual(2, Calculator.Add("2,1001"));
        }
        [Test]
        public void ShouldSupportDelimitersOfVaryingLength()
        {
            Assert.AreEqual(5, Calculator.Add("//[***]\n1***2***3"));
        }
    }
}
