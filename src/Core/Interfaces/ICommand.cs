using Core.Models;

namespace Core.Interfaces;

public interface ICommand
{
    string Name { get; }
    void Execute(CommandResult _result);
    void Undo(CommandResult _result);
}
