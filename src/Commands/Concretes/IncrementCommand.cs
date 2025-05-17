using Core;
using Core.Interfaces;

namespace Commands.Concretes.IncrementCommand;

public class IncrementCommand : ICommand
{
    public string Name => throw new System.NotImplementedException();

    public void Execute (CommandResult _result)=> _result.Result +=1;
  
    public void Undo (CommandResult _result)=> _result.Result -=1;
}