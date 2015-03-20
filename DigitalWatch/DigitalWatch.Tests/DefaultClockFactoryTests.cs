using NUnit.Framework;

namespace DigitalWatch.Tests
{
    [TestFixture]
    public class DefaultClockFactoryTests
    {
        [Test]
        public void CanCreateFactory()
        {
            var factory = new DefaultClockFactory();
        }
    }
}