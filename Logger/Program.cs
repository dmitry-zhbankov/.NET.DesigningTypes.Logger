using System;

namespace Logger
{
    class Program
    {
        static void Method(string[] args)
        {
            Console.WriteLine("Default console logger");
            ILogger logger = new Classes.Logger();
            logger.Error("error message");
            logger.Error(new Exception("exception message"));
            logger.Warning("warning message");
            logger.Info("info message");
            Console.WriteLine("***");

            ((Classes.Logger)logger).Loggers.Add(DbLogger.GetInstance());
            Console.WriteLine("Default console logger + Db logger");
            logger.Error("error message");
            logger.Error(new Exception("exception message"));
            logger.Warning("warning message");
            logger.Info("info message");
            Console.WriteLine("***");

            ((Classes.Logger)logger).Loggers.Add(FileLogger.GetInstance());
            Console.WriteLine("Default console logger + Db logger + File logger");
            logger.Error("error message");
            logger.Error(new Exception("exception message"));
            logger.Warning("warning message");
            logger.Info("info message");
            Console.WriteLine("***");
        }

        static void Main(string[] args)
        {
            Method(null);
            GC.Collect();
            Console.ReadKey();
        }
    }
}
