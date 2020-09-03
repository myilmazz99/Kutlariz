using Kutlariz.Core.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Kutlariz.Tests
{
    public class BirthdayTest
    {
        [Fact]
        public void CalculateDaysLeftTillNextBday_DaysLeft()
        {
            var calculator = CalculateDaysLeftTillNextBday.Calculate(DateTime.Now.AddDays(-10));
            Assert.Equal(355, calculator);
        }
    }
}
