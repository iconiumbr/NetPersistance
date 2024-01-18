namespace FiapStore.Logs
{
    public class CustomLogger : ILogger
    {
        public readonly string _loggerName;
        public readonly CustomLogProviderConfiguration _configuration;

        public CustomLogger (string loggerName,
            CustomLogProviderConfiguration configuration)
        {
            _loggerName = loggerName;
            _configuration = configuration;
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, 
            EventId eventId, 
            TState state, 
            Exception? exception, 
            Func<TState, Exception?, string> formatter)
        {
            var message = string.Format($"{logLevel}:{eventId}" + 
                $"{formatter(state,exception)} ");

            if ( exception != null ) { message += exception.ToString(); }

            WriteTextOnFile(message);
        }

        private void WriteTextOnFile(string Message) {
            var path = $@"c:\logger\logger-{DateTime.Now:yyyy-MM-dd}.txt";
            var folder = $@"c:\logger";
            if (!File.Exists(path)) 
            {
                if (!File.Exists(folder)) Directory.CreateDirectory(folder);
                File.Create(path).Dispose();
            }

            using StreamWriter stream = new StreamWriter(path,true);
            stream.WriteLine(Message);
            stream.Close();
        }
    }
}
