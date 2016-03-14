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
        public int Lights { get; set; }
    }

    [TestFixture]
    class LightSwitchesTests
    {
        public LightSwitches LightSwitchGame;
        [Test]
        public void ShouldInitialiseWithANumberofLightsProperty()
        {
            LightSwitchGame = new LightSwitches();
            Assert.That(LightSwitchGame, Has.Property("Lights"));
        }
    }
}
