using NLog;
using No8.Solution.Interfaces;
using System;

namespace No8.Solution.Concrete
{
    public class FileLogger : IFileLogger
    {
        Logger logger;

        public FileLogger()
        {
            logger = LogManager.GetCurrentClassLogger();
        }

        public void LogError(string message, Exception ex)
        {
            logger.Error(ex, message);
        }

        public void LogFatal(string message, Exception ex)
        {
            logger.Fatal(ex, message);
        }

        public void LogInfo(string message)
        {
            logger.Info(message);
        }

        public void LogWarn(string message)
        {
            logger.Warn(message);
        }
    }
}
