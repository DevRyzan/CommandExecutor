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
        var serviceCollectionDI = new ServiceCollection();

        
        Dependencies.Configure(serviceCollectionDI);
        
        var serviceProvider = serviceCollectionDI.BuildServiceProvider();

        var cmdFactory = serviceProvider.GetRequiredService<ICommandFactory>();
        var cmdManager = serviceProvider.GetRequiredService<CommandManager>();

        var randomGenerator = new RandomGenerator();  
        var log = new CommandLogger();

        Console.Write(Messages.ChooseCommand);

        while (true)
        {
            Console.WriteLine($"{Messages.CurrentResult}{cmdManager.Result.Result}");


            Console.Write(Messages.EnteraCommand);
            
            string executedCmd = Console.ReadLine();

            if (executedCmd.ToLower() == InputStrings.Undo)
            {
                cmdManager.UndoLastCommand();
                continue;
            }

            if (executedCmd.ToLower() == InputStrings.Exit)
                break;

            var commandExecute = cmdFactory.Command(executedCmd);

            if (commandExecute == null)
            {
                Console.WriteLine(Messages.UnknownCommand);
                continue;
            }

            cmdManager.ExecuteCommand(commandExecute);
        }
    }
}
