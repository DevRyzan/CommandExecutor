using System;
using Core.Factory;
using App.Manager;

class Program
{
    static void Main(string[] args)
    {
        var randomGenerator = new RandomGenerator();  
        var commandFactory = new CommandFactory(randomGenerator);  

        var commandManager = new CommandManager();

        Console.Write("Choose one command \n-icrement  \n-decrement \n-double \n-randadd \n-undo \n---if you need help and wanna learn command details type 'help'\n");

        while (true)
        {
            Console.WriteLine($"Current result: {commandManager.Result.Result}");
            
            Console.Write("Enter a command: ");
            
            string command = Console.ReadLine();

            if (command.ToLower() == "undo")
            {
                commandManager.UndoLastCommand();
                continue;
            }

            if (command.ToLower() == "exit")
                break;

            var commandToExecute = commandFactory.Command(command);

            if (commandToExecute == null)
            {
                Console.WriteLine("Unknown command.");
                continue;
            }

            commandManager.ExecuteCommand(commandToExecute);
        }
    }
}
