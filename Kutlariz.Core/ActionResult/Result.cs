using Kutlariz.Core.ActionResult.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kutlariz.Core.ActionResult
{
    public class Result : IResult
    {
        public Result()
        {

        }
        public Result(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }
        public Result(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }
        public Result(bool isSuccess, IEnumerable<string> messages)
        {
            IsSuccess = isSuccess;
            Messages = messages;
        }

        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public IEnumerable<string> Messages { get; set; }
        public ErrorType ErrorType { get; set; }
    }
}
