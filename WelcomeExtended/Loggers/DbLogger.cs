using System.Collections.Concurrent;
using System.Text;
using DataLayer.Database;
using DataLayer.Model;
using Microsoft.Extensions.Logging;

namespace WelcomeExtended.Loggers;

public class DbLogger: ILogger
{
    private readonly string _name;
    private readonly ConcurrentDictionary<int, string> _logMessages;

    public DbLogger(string name)
    {
        _name = name;
        _logMessages = new ConcurrentDictionary<int, string>();
    }
    
    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        var message = formatter(state, exception);

        StringBuilder sb = new StringBuilder();
       
        sb.Append("- LOGGER -\n");

        var messageToBeLogged = new StringBuilder();
        messageToBeLogged.Append($"[{logLevel}]");
        messageToBeLogged.AppendFormat(" [{0}]", _name);

        sb.Append(messageToBeLogged.ToString());
        sb.Append($"\n {formatter(state, exception)}\n");
        sb.Append("- LOGGER -");

        using (var context = new DatabaseContext())
        {
            context.Database.EnsureCreated();
            context.Logs.Add(new DatabaseLog()
            {
                Message = sb.ToString(),
                AdditionalInformation = $"AdditionalInformation[{formatter(state, exception)}]\n"
            });
            context.SaveChanges();
        }
     
        _logMessages[eventId.Id] = message;
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return true;
    }

    public IDisposable? BeginScope<TState>(TState state) where TState : notnull
    {
        return null;
    }
}