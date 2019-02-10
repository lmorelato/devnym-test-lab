using System;
using Moq;
using NyTO.Library.Code;
using Xunit;

namespace NyTO.Test.Code
{
    public class LegacyClassTests
    {
        private readonly DateTime _sunday;
        private readonly DateTime _saturday;
        private readonly Mock<IAppDateTime> _fakeSystemClock;

        public LegacyClassTests()
        {
            // xunit tear up
            _sunday = new DateTime(2019, 2, 10);
            _saturday = new DateTime(2019, 2, 9);
            _fakeSystemClock = new Mock<IAppDateTime>();
        }

        [Fact]
        public void CheckIfSaturday_DayIsSaturday_ThrowsException()
        {
            _fakeSystemClock
                .Setup(o => o.GetDateTime())
                .Returns(_saturday);

            var legacy = new LegacyClass(_fakeSystemClock.Object);
            Assert.Throws<Exception>(() => legacy.CheckDate());
        }

        [Fact]
        public void CheckIfSaturday_DayIsNotSaturday_ReturnTrue()
        {
            _fakeSystemClock
                .Setup(o => o.GetDateTime())
                .Returns(_sunday);

            var legacy = new LegacyClass(_fakeSystemClock.Object);
            legacy.CheckDate();
        }
    }
}
