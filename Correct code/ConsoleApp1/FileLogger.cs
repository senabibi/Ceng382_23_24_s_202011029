
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
        try
        {
            List<LogRecord> existingLogs = ReadLogsFromFile();

            existingLogs.Add(log);

            string json = JsonSerializer.Serialize(existingLogs, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(logFilePath, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error writing log to file: {ex.Message}");
        }
    }

    private List<LogRecord> ReadLogsFromFile()
    {
        if (!File.Exists(logFilePath))
        {
            return new List<LogRecord>();
        }

        try
        {
            string json = File.ReadAllText(logFilePath);

            List<LogRecord>? logs = JsonSerializer.Deserialize<List<LogRecord>>(json);

            return logs ?? new List<LogRecord>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading log file: {ex.Message}");

            return new List<LogRecord>();
        }
    }
}
