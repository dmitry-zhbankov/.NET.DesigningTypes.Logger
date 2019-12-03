using System;
using System.IO;

namespace Logger
{
    public class FileLogger : ILogger, IDisposable
    {
        StreamWriter streamWriter;
        private bool disposed = false;
        private static FileLogger instance;

        private FileLogger()
        {
            var fileName = $"Log {DateTime.Now:yyyy'-'MM'-'dd'T'HH'-'mm'-'ss}";
            FileStream fileStream = File.Open(fileName, FileMode.Create);
            streamWriter = new StreamWriter(fileStream);
        }

        public static FileLogger GetInstance()
        {
            if (instance == null)
            {
                instance = new FileLogger();
            }
            return instance;
        }

        public void Error(string message)
        {
            streamWriter.WriteLine($"Error: {message}");
            streamWriter.Flush();
        }

        public void Error(Exception ex)
        {
            streamWriter.WriteLine($"Error exception: {ex?.Message}");
            streamWriter.Flush();
        }

        public void Info(string message)
        {
            streamWriter.WriteLine($"Info: {message}");
            streamWriter.Flush();
        }

        public void Warning(string message)
        {
            streamWriter.WriteLine($"Warning: {message}");
            streamWriter.Flush();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            Console.WriteLine("FileLogger disposer");
            if (!disposed)
            {
                if (disposing)
                {
                }
                instance = null;
                streamWriter?.Close();
                streamWriter?.Dispose();
                disposed = true;
            }
        }

        ~FileLogger()
        {
            Console.WriteLine("FileLogger destructor");
            Dispose(false);
        }
    }
}
