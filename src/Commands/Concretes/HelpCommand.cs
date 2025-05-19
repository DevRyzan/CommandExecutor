
using Commands.Constant;
using Core.Interfaces;
using Core.Models;

namespace Commands.Concretes;
/// <summary>
/// Information command "help" for all commands.
/// </summary>
public class HelpCommand : ICommand
{


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
    }
}
