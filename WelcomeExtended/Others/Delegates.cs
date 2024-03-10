using Microsoft.Extensions.Logging;
using WelcomeExtended.Helpers;

namespace WelcomeExtended.Others;

public class Delegates
{
    public static readonly ILogger logger = LoggerHelper.GetLogger("LOGGER");
    public static readonly ILogger fileLogger = LoggerHelper.GetFileLogger("FILE_LOGGER");
    public static readonly ILogger dbLogger = LoggerHelper.GetDbLogger("DB_LOGGER");

    public static void Log(string error)
    {
        logger.LogError(error);
    }
    
    
    public static void LogToFile(string error)
    {
        fileLogger.LogError(error);
    }
    
    public static void LogToDb(string error)
    {
        dbLogger.LogError(error);
    }

}