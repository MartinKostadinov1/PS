using System.Collections.Concurrent;
using System.Text;
using Microsoft.Extensions.Logging;

namespace WelcomeExtended.Loggers;

public class HashLogger: ILogger
{
    //TODO maybe use an object instead of string for higher scope over the log message
    private readonly ConcurrentDictionary<int, string> _logMessages;

    private readonly string _name;

    public HashLogger(string name)
    {
        _name = name;
        _logMessages = new ConcurrentDictionary<int, string>();
    }


    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        var message = formatter(state, exception);
        switch (logLevel)
        {
            case LogLevel.Critical:
                Console.ForegroundColor = ConsoleColor.Red;
                break;
            case LogLevel.Error:
                Console. ForegroundColor = ConsoleColor.DarkRed;
                break;
            case LogLevel.Warning:
                Console. ForegroundColor = ConsoleColor.Yellow;
                break;
            default:
                Console.ForegroundColor = ConsoleColor.White;
                break;
        }
        Console.WriteLine("- LOGGER -");
        var messageToBeLogged = new StringBuilder();
        messageToBeLogged.Append($"[{ logLevel}]");
        messageToBeLogged.AppendFormat(" [{0}]", _name);
        Console.WriteLine(messageToBeLogged);
        Console.WriteLine($" {formatter(state, exception)}");
        Console.WriteLine("- LOGGER -");
        Console.ResetColor();
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

    public void LogSummary()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("- LOGGER SUMMARY -");
        
        var messageToBeLogged = new StringBuilder();

        foreach (var element in _logMessages)
        {
            
            messageToBeLogged.AppendFormat(" [{0}]", _name);
            messageToBeLogged.AppendFormat(element.Value);
            Console.WriteLine(messageToBeLogged);
            messageToBeLogged.Clear();
        }
        
        Console.WriteLine("- LOGGER SUMMARY -");
    }
    
    public void LogMessageByEventId(int eventId)
    {
        if (_logMessages.TryGetValue(eventId, out var message))
        {
            Console.WriteLine($"- LOGGER MESSAGE FOR EVENT: {eventId} -");
            Console.WriteLine($"- {message} -");
            Console.WriteLine("- LOGGER END -");
        }
        else
        {
            Console.WriteLine($"- LOGGER MESSAGE FOR EVENT: {eventId} DOES NOT EXISTS-");
        }
       
    }
    
    public void RemoveLogMessageByEventId(int eventId)
    {
        Console.WriteLine(_logMessages.TryRemove(eventId, out _)
            ? $"- LOGGER MESSAGE FOR EVENT: {eventId} DELETED -"
            : $"- REMOVING LOGGER MESSAGE FOR EVENT: {eventId} FAILED -");
    }
}