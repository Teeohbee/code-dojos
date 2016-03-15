using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LightSwitches
{
    public class LightSwitches
    {
        public int NoOfLights { get; set; }
        public List<int> LightStatus { get; set; }

        public void GenerateStatusArray()
        {
            LightStatus = new List<int>();
            for (int i = 0; i < NoOfLights; i++)
            {
                LightStatus.Add(0);
            }
        }

        public void TurnOnLights(string input)
        {
            var lightRange = ParseInputToRange(input);
            foreach (int index in lightRange)
            {
                LightStatus[index] = (LightStatus[index] == 0) ? 1 : 0;
            }
        }

        private static IEnumerable<int> ParseInputToRange(string input)
        {
            List<int> lights = input.Split(' ').Select(Int32.Parse).ToList();
            int startingLight = Math.Min(lights[0], lights[1]);
            int endingLight = Math.Max(lights[0], lights[1]);
            int count = endingLight - startingLight + 1;
            IEnumerable<int> lightRange = Enumerable.Range(startingLight, count);
            return lightRange;
        }

        public int CalulateNoLightsOn()
        {
            int sum = LightStatus.Sum();
            return sum;
        }
    }

    [TestFixture]
    class LightSwitchesTests
    {
        public LightSwitches LightSwitchGame;
        [SetUp]
        public void Init()
        {
            LightSwitchGame = new LightSwitches();
        }
        [Test]
        public void ShouldInitialiseWithANumberofLightsProperty()
        {
            Assert.That(LightSwitchGame, Has.Property("NoOfLights"));
        }
        [Test]
        public void ShouldAcceptAStartingNumberOfLights()
        {
            LightSwitchGame.NoOfLights = 10;
            Assert.AreEqual(10, LightSwitchGame.NoOfLights);
        }
        [Test]
        public void ShouldGenerateListOfLightStatus()
        {
            LightSwitchGame.NoOfLights = 10;
            LightSwitchGame.GenerateStatusArray();
            var list = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            Assert.AreEqual(list, LightSwitchGame.LightStatus);
        }
        [TestCase("0 0", 1, 0, 0, 0, 0, 0, 0, 0, 0, 0)]
        [TestCase("1 4", 0, 1, 1, 1, 1, 0, 0, 0, 0, 0)]
        [TestCase("0 9", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1)]
        [TestCase("5 6", 0, 0, 0, 0, 0, 1, 1, 0, 0, 0)]
        [TestCase("4 8", 0, 0, 0, 0, 1, 1, 1, 1, 1, 0)]
        public void ShouldTurnOnLightsWhenGivenIncreasingRange(string input, params int[] expectedLightStatus)
        {
            LightSwitchGame.NoOfLights = 10;
            LightSwitchGame.GenerateStatusArray();
            LightSwitchGame.TurnOnLights(input);
            Assert.AreEqual(expectedLightStatus, LightSwitchGame.LightStatus);
        }
        [TestCase("7 3", 0, 0, 0, 1, 1, 1, 1, 1, 0, 0)]
        [TestCase("4 1", 0, 1, 1, 1, 1, 0, 0, 0, 0, 0)]
        [TestCase("9 0", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1)]
        [TestCase("6 5", 0, 0, 0, 0, 0, 1, 1, 0, 0, 0)]
        [TestCase("8 4", 0, 0, 0, 0, 1, 1, 1, 1, 1, 0)]
        public void ShouldTurnOnLightsWhenGivenDecreasingRange(string input, params int[] expectedLightStatus)
        {
            LightSwitchGame.NoOfLights = 10;
            LightSwitchGame.GenerateStatusArray();
            LightSwitchGame.TurnOnLights(input);
            Assert.AreEqual(expectedLightStatus, LightSwitchGame.LightStatus);
        }
        [Test]
        public void ShouldHandleMultipleInputs()
        {
            LightSwitchGame.NoOfLights = 10;
            LightSwitchGame.GenerateStatusArray();
            LightSwitchGame.TurnOnLights("0 5");
            LightSwitchGame.TurnOnLights("3 7");
            var list = new List<int> { 1, 1, 1, 0, 0, 0, 1, 1, 0, 0 };
            Assert.AreEqual(list, LightSwitchGame.LightStatus);
        }
        [Test]
        public void ShouldCalculateNumberOfLightsStillOn()
        {
            LightSwitchGame.NoOfLights = 10;
            LightSwitchGame.GenerateStatusArray();
            LightSwitchGame.TurnOnLights("0 5");
            LightSwitchGame.TurnOnLights("3 7");
            Assert.AreEqual(5, LightSwitchGame.CalulateNoLightsOn());
        }
    }
}
