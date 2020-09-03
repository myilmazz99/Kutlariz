using System;
using System.Collections.Generic;
using System.Text;

namespace Kutlariz.Business.Logging
{
    public interface ILoggerService
    {
        void LogWarn(Exception ex, string message);
        void LogInfo(Exception ex, string message);
        void LogInfo(string message);
        void LogError(Exception ex, string message);
    }
}
