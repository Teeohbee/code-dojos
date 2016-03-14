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
    }
}
