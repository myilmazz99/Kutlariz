using System;
using System.Collections.Generic;
using System.Text;

namespace Kutlariz.Core.ActionResult.Abstract
{
    public interface IResult
    {
        bool IsSuccess { get; set; }
        string Message { get; set; }
        IEnumerable<string> Messages { get; set; }
        ErrorType ErrorType { get; set; }
    }
}
