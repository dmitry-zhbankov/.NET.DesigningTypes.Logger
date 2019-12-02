using System;

namespace Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger;

            Console.WriteLine("Default logging");
            logger = new Logger();
            logger.Error("error message");
            logger.Error(new Exception("exception message"));
            logger.Warning("warning message");
            logger.Info("info message");
            Console.WriteLine("");

            Console.WriteLine("Console logging");
            logger = new ConsoleLogger();
            logger.Error("error message");
            logger.Error(new Exception("exception message"));
            logger.Warning("warning message");
            logger.Info("info message");
            Console.WriteLine("");

            Console.WriteLine("File logging");
            logger = FileLogger.GetInstance();
            logger.Error("error message");
            logger.Error(new Exception("exception message"));
            logger.Warning("warning message");
            logger.Info("info message");
            Console.WriteLine("");

            Console.WriteLine("Db logging");
            logger = DbLogger.GetInstance();
            logger.Error("error message");
            logger.Error(new Exception("exception message"));
            logger.Warning("warning message");
            logger.Info("info message");
            Console.WriteLine("");

            Console.ReadKey();
        }
    }
}
