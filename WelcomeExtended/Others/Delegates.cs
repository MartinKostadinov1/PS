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
        logger.LogInformation(error);
    }


    public static void LogToFile(string error)
    {
        fileLogger.LogInformation(error);
    }

    public static void LogToDb(string error)
    {
        dbLogger.LogInformation(error);
    }




    public static void LogError(string error)
    {
        logger.LogError(error);
    }
    
    
    public static void LogErrorToFile(string error)
    {
        fileLogger.LogError(error);
    }
    
    public static void LogErrorToDb(string error)
    {
        dbLogger.LogError(error);
    }

}