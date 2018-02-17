using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using log4net;

/// <summary>
/// Setup log4net separately so that if we decide to use other logger it can be added without modify this class
/// </summary>
namespace TSoft.Data.Common.Logging.Log4Net
{
    public class Log4NetLogger : ILogger
    {
        private ILog _logger;

        public Log4NetLogger()
        {
            _logger = LogManager.GetLogger(this.GetType());
        }

        //Info
        public void Info(string message)
        {
            _logger.Info(message);
        }

        public void Info(Exception exception)
        {
            Info(LogUtility.BuildExceptionMessage(exception));
        }

        public void Info(string message, Exception exception)
        {
            _logger.Info(message, exception);
        }

        //Warn
        public void Warn(string message)
        {
            _logger.Warn(message);
        }

        public void Warn(Exception exception)
        {
            Warn(LogUtility.BuildExceptionMessage(exception));
        }

        public void Warn(string message, Exception exception)
        {
            _logger.Warn(message, exception);
        }

        //Debug
        public void Debug(string message)
        {
            _logger.Debug(message);
        }

        public void Debug(Exception exception)
        {
            Debug(LogUtility.BuildExceptionMessage(exception));
        }

        public void Debug(string message, Exception exception)
        {
            _logger.Debug(message, exception);
        }

        //Error
        public void Error(string message)
        {
            _logger.Error(message);            
        }

        public void Error(Exception exception)
        {
            Error(LogUtility.BuildExceptionMessage(exception));
        }

        public void Error(string message, Exception exception)
        {
            _logger.Error(message, exception);
        }

        //Fatal
        public void Fatal(string message)
        {
            _logger.Fatal(message);
        }

        public void Fatal(Exception x)
        {
            Fatal(LogUtility.BuildExceptionMessage(x));
        }                            

        public void Fatal(string message, Exception exception)
        {
            _logger.Fatal(message, exception);
        }
    }
}