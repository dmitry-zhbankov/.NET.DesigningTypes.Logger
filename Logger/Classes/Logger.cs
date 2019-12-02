using System;

namespace Logger
{
    public class Logger : ILogger, IDisposable
    {
        private bool disposed = false;

        public virtual void Error(string message)
        {
            Console.WriteLine($"Log {DateTime.Now:s} Error: {message}");
        }

        public virtual void Error(Exception ex)
        {
            Console.WriteLine($"Log {DateTime.Now:s} Error: {ex.Message}");
        }

        public virtual void Info(string message)
        {
            Console.WriteLine($"Log {DateTime.Now:s} Error: {message}");
        }

        public virtual void Warning(string message)
        {
            Console.WriteLine($"Log {DateTime.Now:s} Error: {message}");
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                }
                disposed = true;
            }
        }

        ~Logger()
        {
            Dispose(false);
        }
    }
}
