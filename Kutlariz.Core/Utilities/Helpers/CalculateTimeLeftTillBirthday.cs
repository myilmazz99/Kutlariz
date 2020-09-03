using System;
using System.Collections.Generic;
using System.Text;

namespace Kutlariz.Core.Utilities.Helpers
{
    public static class CalculateTimeLeftTillBirthday
    {
        public static string Calculate(DateTime birthday)
        {
            int daysLeft = CalculateDaysLeftTillNextBday.Calculate(birthday);
            if (daysLeft == 0) return "0";

            int months = (int)Math.Floor((double)daysLeft / 30);
            int days = daysLeft - (months * 30);
            int hours = 24 - DateTime.Now.Hour;

            return $"{months} ay {days - 1} gün {hours} saat";
            //DateTime now = DateTime.Now;
            //DateTime nextBday = new DateTime(now.Year, birthday.Month, birthday.Day);

            //if (now > nextBday)
            //{
            //    nextBday = nextBday.AddYears(1);
            //}

            //var timeDiff = nextBday.Subtract(now);

            //var hour = timeDiff.Hours;
            //var day = nextBday.Day - now.Day;
            //var month = (int)Math.Floor((decimal)timeDiff.Days / 30);

            //if (day < 0)
            //    day *= -1;


            ////var month = now.Month - nextBday.Month;
            ////var day = now.Day - nextBday.Day;
            ////var hour = 24 - now.Hour;

            ////if (month < 0)
            ////    month *= -1;

            ////if (day < 0)
            ////    day *= -1;


            //if (now.Month == nextBday.Month && now.Day == nextBday.Day)
            //{
            //    return "0";
            //}

        }
    }
}
