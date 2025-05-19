using Core.Interfaces;
using Core.Models;

namespace Commands.Concretes.IncrementCommand;
/// <summary>
/// Increments the result value by 1 and Undo methods decrements the value by 1. 
/// </summary>
public class IncrementCommand : ICommand
{ 

    public void Execute (CommandResult _cmdResult)=> _cmdResult.Result +=1;
  
    public void Undo (CommandResult _cmdResult)=> _cmdResult.Result -=1;
}