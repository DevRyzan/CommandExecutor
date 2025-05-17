using Core;
using Core.Interfaces;
using System.Collections.Generic;

namespace App.Manager;

public class CommandManager
{
    public CommandResult Result { get; set; } = new CommandResult();

    private Stack<ICommand> _commandHistory = new();
    public void ExecuteCommand(ICommand command)
    {
        command.Execute(Result);            
        _commandHistory.Push(command);     
    }

    public void UndoLastCommand()
    {
        if (_commandHistory.Count > 0)
        {
            var lastCommand = _commandHistory.Pop();
            lastCommand.Undo(Result);         
        }
    }
}
