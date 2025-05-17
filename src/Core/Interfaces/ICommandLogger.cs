using Core.Models;

namespace Core.Interfaces;

public interface ICommandLogger
{
    void Log(CommandLog newLog);
    List<CommandLog> LogList();
}
