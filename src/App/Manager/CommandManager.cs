using Core.Interfaces;
using Core.Models;
using System.Collections.Generic;
using System.Numerics;

namespace App.Manager;

public class CommandManager
{
    public CommandResult Result { get; set; } = new CommandResult();

    private Stack<ICommand> _cmdHistory = new();
    private readonly ICommandLogger _cmdLogger;
    public CommandManager(ICommandLogger cmdLogger)
    {
        _cmdLogger = cmdLogger;
        
    }
    public void ExecuteCommand(ICommand command)
    {
        command.Execute(Result);            
        _cmdHistory.Push(command);

        _cmdLogger.Log(new CommandLog
        {
            CommandName = command.GetType().Name,
            CurrentValue = Result.Result.ToString(),
            DateTime = DateTime.Now
        });
    }

    public void UndoLastCommand()
    {
        if (_cmdHistory.Count > 0)
        {
            var lastCommand = _cmdHistory.Pop();
            lastCommand.Undo(Result);         
        }
    }
}
