using System;
using Core.Factory;
using App.Manager;
using Commands.Constant;
using Core.Services;
using Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces.IRandomGenerator;
using App;

class Program
{
    static void Main(string[] args)
    {
        var serviceCollection = new ServiceCollection();

        
        Dependencies.Configure(serviceCollection);
        
        var serviceProvider = serviceCollection.BuildServiceProvider();

        var commandFactory = serviceProvider.GetRequiredService<ICommandFactory>();
        var commandManager = serviceProvider.GetRequiredService<CommandManager>();

        var randomGenerator = new RandomGenerator();  
        var log = new CommandLogger();

        Console.Write(Messages.ChooseCommand);

        while (true)
        {
            Console.WriteLine($"{Messages.CurrentResult}{commandManager.Result.Result}");


            Console.Write(Messages.EnteraCommand);
            
            string command = Console.ReadLine();

            if (command.ToLower() == InputStrings.Undo)
            {
                commandManager.UndoLastCommand();
                continue;
            }

            if (command.ToLower() == InputStrings.Exit)
                break;

            var commandToExecute = commandFactory.Command(command);

            if (commandToExecute == null)
            {
                Console.WriteLine(Messages.UnknownCommand);
                continue;
            }

            commandManager.ExecuteCommand(commandToExecute);
        }
    }
}
