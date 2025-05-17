using Core.Interfaces;
using Core.Models;

namespace Commands.Concretes.UndoCommand;

public class UndoCommand: ICommand
{
    private readonly Stack<ICommand> _commandStack;

    public UndoCommand(Stack<ICommand> commandStack)
    {
        _commandStack = commandStack;
    }

    public string Name => throw new System.NotImplementedException();

    public void Execute(CommandResult _result)
    {
        if (_commandStack.Count>0)
        {
            var lastCommand = _commandStack.Pop();
            lastCommand.Undo(_result);
            
        }
    }
    public void Undo(CommandResult _result)
    {

    }
}