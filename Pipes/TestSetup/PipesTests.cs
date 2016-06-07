using System.Collections.Generic;
using NUnit.Framework;

namespace TestSetup
{
    [TestFixture]
    class PipesTests
    {
        private Pipes _pipes;
        [SetUp]
        public void Init()
        {
           _pipes = new Pipes();
        }

        [Test]
        public void Solve_GivenOutputDirectlyToTheRightOfInputAndAllGreaterThanSymbols_FindsSolution()
        {
            var board = new List<string> {"*******", "A_____B", "*_____*", "*_____*", "*_____*", "*_____*", "*******"};
            var bag = new List<char> { '>', '>', '>', '>', '>' };

            var solution = _pipes.Solve(board, bag);

            Assert.That(solution, Is.EqualTo(new List<string>{ "*******", "A>>>>>B", "*_____*", "*_____*", "*_____*", "*_____*", "*******"}));
        }

        [Test]
        public void Solve_GivenOutputDirectlyToTheLeftInputAndAllLessThanSymbols_FindsSolution()
        {
            var board = new List<string> { "*******", "B_____A", "*_____*", "*_____*", "*_____*", "*_____*", "*******" };
            var bag = new List<char> { '<', '<', '<', '<', '<' };

            var solution = _pipes.Solve(board, bag);

            Assert.That(solution, Is.EqualTo(new List<string> { "*******", "B<<<<<A", "*_____*", "*_____*", "*_____*", "*_____*", "*******" }));
        }

        [Test]
        public void Solve_GivenOutputDirectlyToTheRightOfInputOnLineOtherThanTheFirstOneAndAllGreaterThanSymbols_FindsSolution()
        {
            var board = new List<string> { "*******", "*_____*", "A_____B", "*_____*", "*_____*", "*_____*", "*******" };
            var bag = new List<char> { '>', '>', '>', '>', '>' };

            var solution = _pipes.Solve(board, bag);

            Assert.That(solution, Is.EqualTo(new List<string> { "*******", "*_____*", "A>>>>>B", "*_____*", "*_____*", "*_____*", "*******" }));
        }

        [Test]
        public void Solve_GivenOutputDirectlyToTheLeftOfInputOnLineOtherThanTheFirstOneAndAllGreaterThanSymbols_FindsSolution()
        {
            var board = new List<string> { "*******", "*_____*", "B_____A", "*_____*", "*_____*", "*_____*", "*******" };
            var bag = new List<char> { '<', '<', '<', '<', '<' };

            var solution = _pipes.Solve(board, bag);

            Assert.That(solution, Is.EqualTo(new List<string> { "*******", "*_____*", "B<<<<<A", "*_____*", "*_____*", "*_____*", "*******" }));
        }

        [Test]
        public void Solve_GivenOutputDirectlyToTheRightOfInputAndEmptyTileBag_DoesNotFindSolution()
        {
            var board = new List<string> { "*******", "A_____B", "*_____*", "*_____*", "*_____*", "*_____*", "*******" };
            var bag = new List<char> {  };

            Assert.Throws<NoSolutionFoundException>(() => _pipes.Solve(board, bag));
        }

        [Test]
        public void Solve_GivenOutputDirectlyToTheLefttOfInputAndEmptyTileBag_DoesNotFindSolution()
        {
            var board = new List<string> { "*******", "B_____A", "*_____*", "*_____*", "*_____*", "*_____*", "*******" };
            var bag = new List<char> { };

            Assert.Throws<NoSolutionFoundException>(() => _pipes.Solve(board, bag));
        }

        [Test]
        public void Solve_GivenOutputToTheRightAndDownOfInput_FindsSolution()
        {
            var board = new List<string> { "*******", "A_____*", "*_____B", "*_____*", "*_____*", "*_____*", "*******" };
            var bag = new List<char> { };
     
            // assert to follow       
        }
    }
}
