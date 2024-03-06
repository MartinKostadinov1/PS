using Microsoft.Extensions.Logging;

namespace WelcomeExtended.Loggers;

public class LoggerProvider: ILoggerProvider
{
    public void Dispose()
    {
    }

    public ILogger CreateLogger(string categoryName)
    {
        return new HashLogger(categoryName);
    }
}