using Core.Interfaces;
using Core.Models;

namespace Commands.Concretes.IncrementCommand;

public class IncrementCommand : ICommand
{
    public string Name => throw new System.NotImplementedException();

    public void Execute (CommandResult _cmdResult)=> _cmdResult.Result +=1;
  
    public void Undo (CommandResult _cmdResult)=> _cmdResult.Result -=1;
}