using Commands.Concretes;
using Commands.Concretes.DoubleCommand;
using Commands.Concretes.IncrementCommand;
using Commands.Concretes.RandAddCommand;
using Core.Interfaces;
using Services.Interfaces.IRandomGenerator;
using System.Collections.Generic;
using System;

namespace Core.Factory;

public class CommandFactory:ICommandFactory
{
    private readonly Dictionary<string, Func<ICommand>> _commands;

    public CommandFactory(IRandomGenerator randomGenerator)
    {
        _commands = new()
        {
            ["increment"] = () => new IncrementCommand(),
            ["decrement"] = () => new DecrementCommand(),
            ["double"] = () => new DoubleCommand(),
            ["randadd"] = () => new RandAddCommand(randomGenerator)
        };
    }

    public ICommand Command(string input) => _commands.TryGetValue(input.ToLower(), out var cmd) ? cmd() : null;
}
