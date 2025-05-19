using Core.Interfaces;
using Core.Models;

namespace Commands.Concretes;
/// <summary>
/// Decrements the result by 1 and increments the value by 1
/// </summary>
public class DecrementCommand : ICommand
{
    public void Execute(CommandResult _result) => _result.Result--;
    public void Undo(CommandResult _result)=>_result.Result++;
}
