using System.Collections.Concurrent;

namespace FiapStore.Logs
{
    public class CustomLogProvider : ILoggerProvider
    {
        private readonly CustomLogProviderConfiguration _loggerConfig;
        private readonly ConcurrentDictionary<string, CustomLogger> _loggers = new ConcurrentDictionary<string, CustomLogger>();

        public CustomLogProvider(CustomLogProviderConfiguration loggerConfig) 
        { _loggerConfig = loggerConfig; }

        public ILogger CreateLogger(string categoryName)
        {
            return _loggers.GetOrAdd(categoryName,
                nome=> new CustomLogger(nome,_loggerConfig));
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
