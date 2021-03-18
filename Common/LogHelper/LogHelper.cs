using log4net;
using System;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = @"log4net.config", Watch = true)]
namespace Common.Log
{
    public sealed class LogHelper
    {
        #region Fields
        private static LogHelper instance = null;
        private static readonly object lockHelper = new object();
        private static ILog logger = LogManager.GetLogger(typeof(LogHelper));
        #endregion

        #region Constructors
        private LogHelper() { }
        #endregion

        #region Methods
        public static LogHelper CreateInstance()
        {
            if (instance == null)
            {
                lock (lockHelper)
                {
                    if (instance == null)
                    {
                        instance = new LogHelper();
                    }
                }
            }

            return instance;
        }

        public void Fatal(string message)
        {
            logger.Fatal(message);
        }

        public void Fatal(string message, Exception e)
        {
            logger.Fatal(message, e);
        }

        public void Error(string message)
        {
            logger.Error(message);
        }

        public void Error(string message, Exception e)
        {
            logger.Error(message, e);
        }

        public void Warning(string message)
        {
            logger.Warn(message);
        }

        public void Info(string message)
        {
            logger.Info(message);
        }

        public void Debug(string message)
        {
            logger.Debug(message);
        }
        #endregion
    }
}
