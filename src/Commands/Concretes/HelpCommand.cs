
using Commands.Constant;
using Core;
using Core.Interfaces;

namespace Commands.Concretes;

public class HelpCommand : ICommand
{
    public string Name => throw new NotImplementedException();

    public void Execute(CommandResult _result)
    {
        Console.WriteLine(Messages.AvailableCommands);
        Console.WriteLine(Messages.IncrementMessage);
        Console.WriteLine(Messages.DecrementMessage);
        Console.WriteLine(Messages.DoubleMessage);
        Console.WriteLine(Messages.RandAddMessage);
        Console.WriteLine(Messages.UndoMessage); 
        Console.WriteLine(Messages.Exit); 
    }

    public void Undo(CommandResult _result)
    {
        throw new NotImplementedException();
    }
}
