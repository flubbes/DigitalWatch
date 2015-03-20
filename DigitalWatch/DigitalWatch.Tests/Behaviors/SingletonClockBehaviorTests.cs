using NUnit.Framework;

namespace DigitalWatch.Tests.Behaviors
{
    [TestFixture]
    public class SingletonClockBehaviorTests
    {
        [Test]
        public void CanCreate()
        {
            var behavior = new SingletonClockBehaviorTests();
        }
    }
}
