using System;
using System.Collections.Generic;
using System.Text;

namespace Kutlariz.Core.Utilities.Helpers
{
    public class RandomNumberGenerator
    {
        public string Generate()
        {
            return new Random().Next(1, 9999).ToString();
        }
    }
}
