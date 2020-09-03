﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Kutlariz.Core.ActionResult
{
    public class SuccessResult : Result
    {
        public SuccessResult() : base(true)
        {

        }
        public SuccessResult(string message) : base(true, message)
        {
        }
        public SuccessResult(IEnumerable<string> messages) : base(true, messages)
        {
        }
    }
}
