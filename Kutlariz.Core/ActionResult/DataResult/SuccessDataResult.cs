using System;
using System.Collections.Generic;
using System.Text;

namespace Kutlariz.Core.ActionResult.DataResult
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult()
        {

        }
        public SuccessDataResult(string message, T data) : base(true, data, message)
        {
        }
        public SuccessDataResult(T data) : base(true, data)
        {
        }
    }
}
