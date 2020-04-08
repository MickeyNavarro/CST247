using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Activity1_3.Services.Utility
{
    public class MyLogger : ILogger
    {
        //singleton pattern example; only one instance of this class can be instanciated 
        private static MyLogger instance; //singleton design pattern 
        private static Logger logger; //static variable to hold a single instance of the nLog logger

        //single pattern design - private constructor 
        private MyLogger()
        {
            
        }


        //single pattern design - this function creates an instance of a class if it has not been instantiated
        //If the class already exists in the program, then send them the reference to the original
        public static MyLogger GetInstance()
        {
            if (instance == null)
                instance = new MyLogger();
            return instance; 
        }

        //private helper method that gets an instance of the NLog logger
        private Logger GetLogger(string theLogger)
        {
            if (MyLogger.logger == null)
                MyLogger.logger = LogManager.GetLogger(theLogger);
            return MyLogger.logger;    
        }


        //ILogger interface implementation: Debug method with optional second argument for message
        public void Debug(string message, string arg = null)
        {
            if (arg == null)
                GetLogger("myAppLoggerRules").Debug(message);
            else
                GetLogger("myAppLoggerRules").Debug(message, arg); 
        }

        //ILogger interface implementation: Error method with optional second argument for message
        public void Error(string message, string arg = null)
        {
            if (arg == null)
                GetLogger("myAppLoggerRules").Error(message);
            else
                GetLogger("myAppLoggerRules").Error(message, arg);
        }

        //ILogger interface implementation: Info method with optional second argument for message
        public void Info(string message, string arg = null)
        {
            if (arg == null)
                GetLogger("myAppLoggerRules").Info(message);
            else
                GetLogger("myAppLoggerRules").Info(message, arg);
        }

        //ILogger interface implementation: Warn method with optional second argument for message
        public void Warning(string message, string arg = null)
        {
            if (arg == null)
                GetLogger("myAppLoggerRules").Warn(message);
            else
                GetLogger("myAppLoggerRules").Warn(message, arg);
        }
    }
}