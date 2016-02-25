using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace GameOfThrees
{
    [TestFixture]
    class GameOfThreesTests
    {
        public GameOfThrees Game { get; set; }
        [SetUp]
        public void Init()
        {
            Game = new GameOfThrees();
        }
        [Test]
        public void ShouldReturnZeroWhenGivenZero()
        {
            Assert.AreEqual(0, Game.Play(0));
        }
        [Test]
        public void ShouldReturnOneWhenGivenThree()
        {
            Assert.AreEqual(1, Game.Play(3));
        }
        [Test]
        public void ShouldNotReturnOneWhenGivenNine()
        {
            Assert.AreNotEqual(1, Game.Play(9));
        }
    }
}
