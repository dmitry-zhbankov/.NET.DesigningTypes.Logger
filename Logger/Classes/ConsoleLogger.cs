using System;

namespace Logger.Classes
{
    public class ConsoleLogger : ILogger
    {
        public void Error(string message)
        {
            Console.WriteLine($"Log {DateTime.Now:s} Error: {message}");
        }

        public void Error(Exception ex)
        {
            Console.WriteLine($"Log {DateTime.Now:s} Error exception: {ex?.Message}");
        }

        public void Info(string message)
        {
            Console.WriteLine($"Log {DateTime.Now:s} Info: {message}");
        }

        public void Warning(string message)
        {
            Console.WriteLine($"Log {DateTime.Now:s} Warning: {message}");
        }
    }
}
