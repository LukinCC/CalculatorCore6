using System;

namespace Calculator
{
    public interface IErrorHandler
    {
        /// <summary>
        /// Send error 
        /// </summary>
        /// <param name="e">Exception for send</param>
        void SendError(Exception e);
    }
}
