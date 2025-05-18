using Core.Models;

namespace Core.Interfaces;

public interface ICommand
{
    void Execute(CommandResult _result);
    void Undo(CommandResult _result);
}
