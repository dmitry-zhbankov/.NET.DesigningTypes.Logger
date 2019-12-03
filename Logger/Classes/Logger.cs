using System;
using System.Collections.Generic;

namespace Logger.Classes
{
    public class Logger : ILogger, IDisposable
    {
        public List<ILogger> Loggers { get; set; }
        bool disposed = false;

        public Logger()
        {
            Loggers = new List<ILogger>();
            Loggers.Add(new ConsoleLogger());
        }

        public void Error(string message)
        {
            foreach (var item in Loggers)
            {
                item?.Error(message);
            }
        }

        public void Error(Exception ex)
        {
            foreach (var item in Loggers)
            {
                item?.Error(ex);
            }
        }

        public void Info(string message)
        {
            foreach (var item in Loggers)
            {
                item?.Info(message);
            }
        }

        public void Warning(string message)
        {
            foreach (var item in Loggers)
            {
                item?.Warning(message);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            Console.WriteLine("BaseLogger disposer");
            if (disposed)
                return;
            if (disposing)
            {
            }
            foreach (var item in Loggers)
            {
                (item as IDisposable)?.Dispose();
            }
            disposed = true;
        }

        ~Logger()
        {
            Console.WriteLine("BaseLogger destructor");
            Dispose(false);
        }
    }
}
