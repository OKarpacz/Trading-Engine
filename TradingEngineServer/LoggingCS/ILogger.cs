﻿using System.Diagnostics;

namespace LoggingCS
{

    public interface ILogger
    {
        void Debug(string module, string message);
        void Debug(string module, Exception exception);
        
        void Information(string module, string message);
        void Information(string module, Exception exception);
        
        void Warning(string module, string message);
        void Warning(string module, Exception exception);
        
        void Error(string module, string message); 
        void Error(string module, Exception exception);
    }
}