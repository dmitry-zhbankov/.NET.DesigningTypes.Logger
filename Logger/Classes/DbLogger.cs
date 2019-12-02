using Microsoft.Data.Sqlite;
using System;

namespace Logger
{
    class DbLogger : Logger
    {
        private static DbLogger instance;
        private bool disposed = false;
        private static SqliteConnection connection;

        private DbLogger()
        {
            connection = new SqliteConnection(@"Data Source=log.db");
            var sqlExpression =
                @"CREATE TABLE IF NOT EXISTS Logs(
                Id INTEGER PRIMARY KEY,
                Time Text NOT NULL,
                Content TEXT NOT NULL
                );";
            connection?.Open();
            var command = new SqliteCommand(sqlExpression, connection);
            command.ExecuteNonQuery();
            command.Dispose();
        }

        public static DbLogger GetInstance()
        {
            if (instance == null)
            {
                instance = new DbLogger();
            }
            return instance;
        }

        public override void Error(string message)
        {
            if (instance != null)
            {
                var sqlExpression = $"INSERT INTO Logs(Content, Time) VALUES('Error: {message}', datetime('now','localtime'))";
                var command = new SqliteCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
                command.Dispose();
            }
        }

        public override void Error(Exception ex)
        {
            if (instance != null)
            {
                var sqlExpression = $"INSERT INTO Logs(Content, Time) VALUES('Error: {ex.Message}', datetime('now','localtime'))";
                var command = new SqliteCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
                command.Dispose();
            }
        }

        public override void Info(string message)
        {
            if (instance != null)
            {
                var sqlExpression = $"INSERT INTO Logs(Content, Time) VALUES('Error: {message}', datetime('now','localtime'))";
                var command = new SqliteCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
                command.Dispose();
            }
        }

        public override void Warning(string message)
        {
            if (instance != null)
            {
                var sqlExpression = $"INSERT INTO Logs(Content, Time) VALUES('Error: {message}', datetime('now','localtime'))";
                var command = new SqliteCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
                command.Dispose();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                }
                connection?.Close();
                connection?.Dispose();
                disposed = true;
                Console.WriteLine("Object has disposed");
            }
        }

        ~DbLogger()
        {
            Dispose(false);
        }
    }
}
