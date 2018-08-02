using System;

namespace No8.Solution.Interfaces
{
    public interface IFileLogger
    {
        void LogInfo(string message);
        void LogWarn(string message);
        void LogError(string message, Exception ex);
        void LogFatal(string message, Exception ex);
    }
}
