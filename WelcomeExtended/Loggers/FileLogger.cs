using System.Collections.Concurrent;
using System.Text;
using Microsoft.Extensions.Logging;

namespace WelcomeExtended.Loggers;

public class FileLogger: ILogger
{
    private string _filePath = "file_logger.txt";
    
    //TODO maybe use an object instead of string for higher scope over the log message
    private readonly ConcurrentDictionary<int, string> _logMessages;

    private readonly string _name;

    public FileLogger(string name)
    {
        _name = name;
        _logMessages = new ConcurrentDictionary<int, string>();
    }


    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        var message = formatter(state, exception);
        
        using (BinaryWriter writer = new BinaryWriter(File.Open(_filePath, File.Exists(_filePath) ? FileMode.Append : FileMode.OpenOrCreate)))
        {
            writer.Write($"{message}\n");
            
            writer.Close();
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