using Microsoft.Extensions.Logging;

namespace WelcomeExtended.Loggers;

public class DbLoggerProvider: ILoggerProvider
{
    public void Dispose()
    {
    }

    public ILogger CreateLogger(string categoryName)
    {
        return new DbLogger(categoryName);
    }
}