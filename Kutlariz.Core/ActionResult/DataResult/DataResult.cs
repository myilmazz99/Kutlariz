using System;
using System.Collections.Generic;
using System.Text;

namespace Kutlariz.Core.ActionResult.DataResult
{
    public class DataResult<T> : Result
    {
        public DataResult()
        {

        }
        public DataResult(bool isSuccess, T data) : base(isSuccess)
        {
            Data = data;
        }
        public DataResult(bool isSuccess, string message) : base(isSuccess, message)
        {
        }
        public DataResult(bool isSuccess, T data, string message) : base(isSuccess, message)
        {
            Data = data;
        }

        public T Data { get; set; }
    }
}
