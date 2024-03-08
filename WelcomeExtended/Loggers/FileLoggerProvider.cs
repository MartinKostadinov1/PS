using Microsoft.Extensions.Logging;

namespace WelcomeExtended.Loggers;

public class FileLoggerProvider: ILoggerProvider
{
    public void Dispose()
    {
    }

    public ILogger CreateLogger(string categoryName)
    {
        return new FileLogger(categoryName);
    }
}