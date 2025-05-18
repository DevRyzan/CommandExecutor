using App.Manager;
using Commands.Concretes.DoubleCommand;
using Core.Interfaces;
using Core.Models;
using Moq;
using Xunit;


namespace App.Tests.Comands;

public class DoubleCmdTest
{

    [Fact]
    public void ExecuteShouldDoubleTheResult()
    {
         var cmdResult = new CommandResult { Result = 6 };
        var doubleCmd = new DoubleCommand();
        doubleCmd.Execute(cmdResult);

        Assert.Equal(12, cmdResult.Result);
    }

    [Fact]
    public void UndoShouldUndoTheResult()
    {
        var mockLogger = new Mock<ICommandLogger>();
        var cmdManager = new CommandManager(mockLogger.Object);
        cmdManager.Result.Result = 3;  

        var doubleCmd = new DoubleCommand();
        cmdManager.ExecuteCommand(doubleCmd);
        cmdManager.UndoLastCommand();           

       
        Assert.Equal(3, cmdManager.Result.Result);
    }
}
