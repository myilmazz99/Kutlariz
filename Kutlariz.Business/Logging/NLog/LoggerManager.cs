using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Kutlariz.Business.Logging.NLog
{
    public class LoggerManager : ILoggerService
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public LoggerManager()
        {
            LogManager.LoadConfiguration(@"Logging\NLog\nlog.config");
        }

        public void LogError(Exception ex, string message)
        {
            logger.Error(ex, message);
        }

        public void LogInfo(Exception ex, string message)
        {
            logger.Info(ex, message);
        }

        public void LogInfo(string message)
        {
            logger.Info(message);
        }

        public void LogWarn(Exception ex, string message)
        {
            logger.Warn(ex, message);
        }
    }
}
