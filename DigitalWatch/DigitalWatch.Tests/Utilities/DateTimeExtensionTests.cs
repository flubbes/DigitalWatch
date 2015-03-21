using DigitalWatch.Utilities;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace DigitalWatch.Tests.Utilities
{
    [TestFixture]
    public class DateTimeExtensionTests
    {
        [Test]
        public void CanConvertToDigitalClockFormat()
        {
            var time = new DateTime(2000, 1, 1, 4, 3, 0);
            var result = time.ToDigitalClockFormat();
            result.Should().Be("0403");
        }
    }
}