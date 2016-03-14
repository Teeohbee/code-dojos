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
            List<int> lights = input.Split(' ').Select(Int32.Parse).ToList();
            int startingLight = lights[0];
            int count = lights[1] - lights[0] + 1;
            IEnumerable<int> lightRange = Enumerable.Range(startingLight, count);
            foreach (int index in lightRange)
            {
                if (LightStatus[index] == 0)
                {
                    LightStatus[index] = 1;
                }
                else if (LightStatus[index] == 1)
                {
                    LightStatus[index] = 0;
                }
            }
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
        [TestCase("0 0",1,0,0,0,0,0,0,0,0,0)]
        public void ShouldTurnOnFirstLightWhenGivenZeroZero(string input, params int[] expectedLightStatus)
        {
            LightSwitchGame.NoOfLights = 10;
            LightSwitchGame.GenerateStatusArray();
            LightSwitchGame.TurnOnLights(input);
            Assert.AreEqual(expectedLightStatus, LightSwitchGame.LightStatus);
        }
    }
}
