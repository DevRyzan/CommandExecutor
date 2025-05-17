using System;
using Core.Factory;
using App.Manager;
using Commands.Constant;

class Program
{
    static void Main(string[] args)
    {
        var randomGenerator = new RandomGenerator();  
        var commandFactory = new CommandFactory(randomGenerator);  

        var commandManager = new CommandManager();

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
