using Core.Interfaces;
using System;
using System.Collections.Generic;

namespace Core.Factory;

public class CommandHistory
{
    private Stack<ICommand> _executedCommands = new();

    public void Push(ICommand command) => _executedCommands.Push(command);

    public ICommand? Pop() => _executedCommands.Count > 0 ? _executedCommands.Pop() : null;

    public bool CanUndo() => _executedCommands.Count > 0;
}
