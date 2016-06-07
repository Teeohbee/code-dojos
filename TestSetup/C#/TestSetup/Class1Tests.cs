using NUnit.Framework;

namespace TestSetup
{
    [TestFixture]
    class Class1Tests
    {
        public Class1 Class1;
        [SetUp]
        public void Init()
        {
            Class1 = new Class1();
        }
        [Test]
        public void ShouldDoSomething()
        {

        }
    }
}
