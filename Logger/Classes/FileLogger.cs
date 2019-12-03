using System;
using System.IO;

namespace Logger
{
    public class FileLogger : Logger
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

        public override void Error(string message)
        {
            streamWriter.WriteLine($"Error: {message}");
            streamWriter.Flush();
        }

        public override void Error(Exception ex)
        {
            streamWriter.WriteLine($"Error exception: {ex.Message}");
            streamWriter.Flush();
        }

        public override void Info(string message)
        {
            streamWriter.WriteLine($"Info: {message}");
            streamWriter.Flush();
        }

        public override void Warning(string message)
        {
            streamWriter.WriteLine($"Warning: {message}");
            streamWriter.Flush();
        }

        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                }
                streamWriter?.Close();
                streamWriter?.Dispose();
                disposed = true;
            }
        }

        ~FileLogger()
        {
            Dispose(false);
        }
    }
}
