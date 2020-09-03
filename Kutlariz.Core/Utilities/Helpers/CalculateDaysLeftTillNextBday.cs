using System;
using System.Collections.Generic;
using System.Text;

namespace Kutlariz.Core.Utilities.Helpers
{
    public static class CalculateDaysLeftTillNextBday
    {
        public static int Calculate(DateTime birthday)
        {
            DateTime nextBDay = new DateTime(DateTime.Now.Year, birthday.Month, birthday.Day);
            int gap = DateTime.Now.DayOfYear - nextBDay.DayOfYear;

            if (gap < 0)
            {
                return gap * -1;
            }
            else if (gap > 0)
            {
                return 365 - gap;
            }

            return gap;
        }
    }
}
