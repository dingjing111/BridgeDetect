using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BridgeDetectSystem.util
{
    /// <summary>
    /// 记录操作日志类
    /// </summary>
    public static class LoggerHelper
    {
        public enum LogLevel
        {
            Info,Debug,Warn,Error,Fatal
        }

        public static void Log(string loggerName, string message, LogLevel level)
        {
            //Type type = MethodBase.GetCurrentMethod().DeclaringType;
            //ILog log = LogManager.GetLogger("参数设置");
            //log.Info(message);

            ILog log = LogManager.GetLogger(loggerName);

            if (level == LogLevel.Fatal)
            {
                log.Fatal(message);
            }
            else if (level == LogLevel.Error)
            {
                log.Error(message);
            }
            else if (level == LogLevel.Warn)
            {
                log.Warn(message);
            }
            else if (level == LogLevel.Debug)
            {
                log.Debug(message);
            }
            else
            {
                log.Info(message);
            }
        }

        public static void Log(string loggerName, string message)
        {
            ILog log = LogManager.GetLogger(loggerName);
            log.Info(message);
        }

    }
}
