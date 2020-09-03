using System;
using System.Collections.Generic;
using System.Text;

namespace Kutlariz.Core.ActionResult
{
    public class ErrorResult : Result
    {
        public ErrorResult(string message, ErrorType errorType = ErrorType.NotSpecified) : base(false, message)
        {
            ErrorType = errorType;
        }
        public ErrorResult(IEnumerable<string> messages, ErrorType errorType = ErrorType.NotSpecified) : base(false, messages)
        {
            ErrorType = errorType;
        }
    }
}
