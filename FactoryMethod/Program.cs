using System;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(new LoggerFactory());
            customerManager.Save();

            CustomerManager customerManager2 = new CustomerManager(new LoggerFactory2());
            customerManager2.Save();

            Console.ReadLine();
        }
    }

    public class LoggerFactory : ILoggerFactory
    {
        public ILogger CreateLogger()
        {   //Assume this method creates and returns a ILogger. Also you can insert Business logic here 
            //Assume you either log to mail or db or to a txt file.
            return new EdLogger();
        }
    }

    public class LoggerFactory2 : ILoggerFactory
    {
        public ILogger CreateLogger()
        {   //Assume this method creates and returns a ILogger. Also you can insert Business logic here 
            //Assume you either log to mail or db or to a txt file.
            return new Log4NetLogger();
        }
    }

    public interface ILoggerFactory
    {
        ILogger CreateLogger();
    }

    public interface ILogger
    {
        void Log();
    }

    public class EdLogger:ILogger
    {//Assume we created this method and we use it to log something.
        public void Log()
        {
            Console.WriteLine("Logged with EdLogger");
        }
    }

    public class Log4NetLogger : ILogger
    {//Assume we created this method and we use it to log something.
        public void Log()
        {
            Console.WriteLine("Logged with Log4NetLogger");
        }
    }

    public class CustomerManager
    {
        private ILoggerFactory _loggerfactory;
        public CustomerManager(ILoggerFactory loggerfactory)
        {
            _loggerfactory = loggerfactory;
        }
        public void Save()
        {
            Console.WriteLine("Saved");
            ILogger logger = _loggerfactory.CreateLogger();
            logger.Log();
        }
    }
}
