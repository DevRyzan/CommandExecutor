using Commands.Concretes;
using Commands.Concretes.DoubleCommand;
using Commands.Concretes.IncrementCommand;
using Commands.Concretes.RandAddCommand;
using Core.Interfaces;
using Services.Interfaces.IRandomGenerator;
using Commands.Constant;

namespace Core.Factory;

public class CommandFactory:ICommandFactory
{
    private readonly Dictionary<string, Func<ICommand>> _commands;

    public CommandFactory(IRandomGenerator randomGenerator)
    {
        _commands = new()
        {
            [InputStrings.Help] = () => new HelpCommand(),
            [InputStrings.Increment] = () => new IncrementCommand(),
            [InputStrings.Decrement] = () => new DecrementCommand(),
            [InputStrings.Double] = () => new DoubleCommand(),
            [InputStrings.RandAdd] = () => new RandAddCommand(randomGenerator)
        };
    }

    public ICommand Command(string input) => _commands.TryGetValue(input.ToLower(), out var cmd) ? cmd() : null;
}
