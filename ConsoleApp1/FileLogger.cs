using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class FileLogger : ILogger
{
    private readonly string logFilePath;

    public FileLogger(string logFilePath)
    {
        this.logFilePath = logFilePath;
    }

    public void Log(LogRecord log)
    {
        var existingLogs = ReadLogsFromFile();
        existingLogs.Add(log);
        var json = JsonSerializer.Serialize(existingLogs, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(logFilePath, json);
    }

    private List<LogRecord> ReadLogsFromFile()
    {
        if (!File.Exists(logFilePath))
        {
            return new List<LogRecord>();
        }
        string json = File.ReadAllText(logFilePath);
        return JsonSerializer.Deserialize<List<LogRecord>>(json) ?? new List<LogRecord>();
    }
}
