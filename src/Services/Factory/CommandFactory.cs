using Core.Interfaces;

namespace Commands.Factory;

public class CommandFactory:ICommandFactory
{
    public ICommand commandFactory(string input)
    {
        return input.ToLower() switch
        {
            "increment" => new IncrementCommand(),
            "decrement" => new DecrementCommands(),
            "double" => new DoubleCommand(),
            "randadd" => new RandAddCommand(new RandomGenerator()),
            _ => null
        };
    } 
}
