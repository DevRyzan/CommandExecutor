using Core.Interfaces;
using Core.Models;
using System.Text.Json;

namespace Core.Services;

public class CommandLogger :ICommandLogger

{
    private static readonly string _logFilePath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
        "CommandExecutorLogs",
        "commandlog.json"
    );

    public void Log(CommandLog log)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(_logFilePath)!);

        List<CommandLog> logs = new();

        if (File.Exists(_logFilePath))
        {
            var json = File.ReadAllText(_logFilePath);
            if (!string.IsNullOrWhiteSpace(json))
                logs = JsonSerializer.Deserialize<List<CommandLog>>(json) ?? new List<CommandLog>();
        }

        logs.Add(log);

        var updatedJson = JsonSerializer.Serialize(logs, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_logFilePath, updatedJson);
    } 
    public List<CommandLog> LogList()
    {
        throw new NotImplementedException();
    }
}

