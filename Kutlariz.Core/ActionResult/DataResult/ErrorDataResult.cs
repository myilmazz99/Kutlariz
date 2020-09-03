using System;
using System.Collections.Generic;
using System.Text;

namespace Kutlariz.Core.ActionResult.DataResult
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(string message, T data) : base(true, data, message)
        {
        }
        public ErrorDataResult(string message) : base(true, message)
        {
        }
        public ErrorDataResult(T data) : base(true, data)
        {
        }
    }
}
