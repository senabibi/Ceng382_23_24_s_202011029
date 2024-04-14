public class FileLogger : ILogger
{
  private readonly string _filePath;

  public FileLogger(string filePath)
  {
    _filePath = filePath;
  }

  public void Log(LogRecord log)
  {
    // Implement logic to log message to a JSON file at filePath
    // ...
  }
}
