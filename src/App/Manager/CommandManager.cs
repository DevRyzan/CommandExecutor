using Core.Interfaces;
using Core.Models;
using System.Collections.Generic;
using System.Numerics;

namespace App.Manager;

public class CommandManager
{
    public CommandResult Result { get; set; } = new CommandResult();

    private Stack<ICommand> _commandHistory = new();
    private readonly ICommandLogger _commandLogger;
    public CommandManager(ICommandLogger commandLogger)
    {
        _commandLogger = commandLogger;
        
    }
    public void ExecuteCommand(ICommand command)
    {
        command.Execute(Result);            
        _commandHistory.Push(command);

        _commandLogger.Log(new CommandLog
        {
            CommandName = command.GetType().Name,
            CurrentValue = Result.Result.ToString(),
            DateTime = DateTime.Now
        });
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
