using Core.Interfaces;
using Core.Models;

namespace Commands.Concretes;

public class DecrementCommand : ICommand
{
    public void Execute(CommandResult _result) => _result.Result--;
    public void Undo(CommandResult _result)=>_result.Result++;
}
