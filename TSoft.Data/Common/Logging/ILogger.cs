using System;

namespace TSoft.Data.Common.Logging
{
    /// <summary>
    /// Common contract for trace instrumentation. You 
    /// can implement this contrat with several frameworks.
    /// .NET Diagnostics API, EntLib, Log4Net,NLog etc.
    /// <remarks>
    /// The use of this abstraction depends on the real needs you have and the specific features  
    /// you want to use of a particular existing implementation. 
    ///  You could also eliminate this abstraction and directly use "any" implementation in your code, 
    /// Logger.Write(new LogEntry()) in EntLib, or LogManager.GetLog("logger-name") with log4net... etc.
    /// </remarks>
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Log information message 
        /// </summary>
        /// <param name="message">The information message to write</param>
        void Info(string message);

        /// <summary>
        /// Log information message
        /// </summary>
        /// <param name="exception">Exception to write in debug message</param>
        void Info(Exception exception);

        /// <summary>
        /// Log information information 
        /// </summary>
        /// <param name="message">The information message to write</param>
        /// <param name="exception">Exception to write in debug message</param>
        void Info(string message, Exception exception);

        /// <summary>
        /// Log warning message
        /// </summary>
        /// <param name="message">The warning message to write</param>        
        void Warn(string message);

        /// <summary>
        /// Log warning message
        /// </summary>
        /// <param name="exception">Exception to write in warning message</param>
        void Warn(Exception exception);

        /// <summary>
        /// Log warning information 
        /// </summary>
        /// <param name="message">The warning message to write</param>
        /// <param name="exception">Exception to write in warning message</param>
        void Warn(string message, Exception exception);

        /// <summary>
        /// Log debug message
        /// </summary>
        /// <param name="message">The debug message</param>
        void Debug(string message);

        /// <summary>
        /// Log debug message
        /// </summary>
        /// <param name="exception">Exception to write in debug message</param>
        void Debug(Exception exception);
    
        /// <summary>
        /// Log debug message
        /// </summary>
        /// <param name="message">The debug message</param>
        /// <param name="exception">Exception to write in debug message</param>
        void Debug(string message, Exception exception);                

        /// <summary>
        /// Log error message
        /// </summary>
        /// <param name="message">The error message to write</param>       
        void Error(string message);

        /// <summary>
        /// Log error message
        /// </summary>
        /// <param name="exception">The exception associated with this error</param>
        void Error(Exception exception);        

        /// <summary>
        /// Log error message
        /// </summary>
        /// <param name="message">The error message to write</param>
        /// <param name="exception">The exception associated with this error</param>
        void Error(string message, Exception exception);

        /// <summary>
        /// Log FATAL error
        /// </summary>
        /// <param name="message">The message of fatal error</param>        
        void Fatal(string message);

        /// <summary>
        /// log FATAL error
        /// </summary>
        /// <param name="exception">The exception to write in this fatal message</param>
        void Fatal(Exception exception);

        /// <summary>
        /// Log FATAL error
        /// </summary>
        /// <param name="message">The message of fatal error</param>
        /// <param name="exception">The exception to write in this fatal message</param>
        void Fatal(string message, Exception exception);              
    }
}
