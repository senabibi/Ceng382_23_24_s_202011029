using System;
using System.Collections.Generic;
using System.Linq;

public static class LogService
{
    public static List<LogRecord> DisplayLogsByName(string name, string logFilePath)
    {
        var logs = new FileLogger(logFilePath).ReadLogsFromFile();
        return logs.Where(log => log.ReserverName.Contains(name)).ToList();
    }

    public static List<LogRecord> DisplayLogs(DateTime start, DateTime end, string logFilePath)
    {
        var logs = new FileLogger(logFilePath).ReadLogsFromFile();
        return logs.Where(log => log.Timestamp >= start && log.Timestamp <= end).ToList();
    }
}
