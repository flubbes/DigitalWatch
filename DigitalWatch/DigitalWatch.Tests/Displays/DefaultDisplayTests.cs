using DigitalWatch.Displays;
using FluentAssertions;
using NUnit.Framework;

namespace DigitalWatch.Tests.Displays
{
    [TestFixture]
    public class DefaultDisplayTests
    {
        private DefaultDisplay _display;

        [SetUp]
        public void SetUp()
        {
            _display = new DefaultDisplay();
        }

        [Test]
        public void IsDerivedFromClockDisplayInterface()
        {
            _display.Should().BeAssignableTo<IClockDisplay>();
        }

        [Test]
        public void EventIsTriggeredWhenUpdateIsCalled()
        {
            var isTriggered = false;
            _display.Update += (sender, args) => isTriggered = true;

            _display.TriggerUpdate("");

            isTriggered.Should().BeTrue();
        }

        [Test]
        public void EventHasDisplayDataParameter()
        {
            var displayData = "";
            _display.Update += (sender, args) =>
            {
                displayData = args.DisplayData;
            };

            _display.TriggerUpdate("Test");

            displayData.Should().Be("Test");
        }
    }
}
