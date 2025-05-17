using Core;
using Core.Interfaces;

namespace Commands.Concretes;

public class DecrementCommand : ICommand
{
    public string Name => throw new System.NotImplementedException();

    public void Execute(CommandResult _result) => _result.Result--;
    public void Undo(CommandResult _result)=>_result.Result++;
}
