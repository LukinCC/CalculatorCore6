using System;

namespace Calculator
{
    /// <summary>
    /// Error handler 
    /// </summary>
    public class ErrorHandler : IErrorHandler
    {
        /// <summary>
        /// Send error 
        /// </summary>
        /// <param name="e">Exception for send</param>
        public void SendError(Exception e)
        {
            string logFilePath = AppDomain.CurrentDomain.BaseDirectory + "log.txt";
            FileLogger log = new FileLogger(logFilePath);
            log.WriteLog(e.Message);
        }
    }
}
