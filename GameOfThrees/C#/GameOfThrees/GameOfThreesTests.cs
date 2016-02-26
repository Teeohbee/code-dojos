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
            Assert.AreEqual(new List<int> { 0 }, Game.Play(0));
        }
        [Test]
        public void ShouldReturnOneWhenGivenThree()
        {
            Assert.AreEqual(new List<int> { 1 }, Game.Play(3));
        }
        [Test]
        public void ShouldNotReturnOneWhenGivenNine()
        {
            Assert.AreNotEqual(new List<int> { 1 }, Game.Play(9));
        }
        [Test]
        public void ShouldReturnThreeOneWhenGivenNine()
        {
            Assert.AreEqual(new List<int> { 3, 1 }, Game.Play(9));
        }
        [Test]
        public void ShouldReturnTwoOneWhenGivenSix()
        {
            Assert.AreEqual(new List<int> { 2, 1 }, Game.Play(6));
        }
        [Test]
        public void ShouldReturnTwoOneWhenGivenTwentySix()
        {
            Assert.AreEqual("2,+1,1", Game.Play(26));
        }
    }
}
