public class LogHandler
{
    public void AddLog(LogRecord log, ILogger logger)
    {
        logger.Log(log);
    }
}
