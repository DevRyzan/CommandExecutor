using App.Manager;
using Commands.Concretes.RandAddCommand;
using Core.Interfaces;
using Core.Models;
using Moq;
using Services.Interfaces.IRandomGenerator;
using Xunit;

namespace App.Tests.Comands;

public class RandAddCmdTest
{
    [Fact]
    public void ExecuteShouldAddRandomNum()
    {
         var mockRandomNumGenerator = new Mock<IRandomGenerator>();
        mockRandomNumGenerator.Setup(g => g.Generate()).Returns(5);

        var commandResult = new CommandResult();
        var randaddCmd = new RandAddCommand(mockRandomNumGenerator.Object);

        randaddCmd.Execute(commandResult);

         Assert.Equal(5, commandResult.Result);
    }

    [Fact]
    public void Undo_ShouldUndoRandomNum()
    {
        var mockRandomNumGenerator = new Mock<IRandomGenerator>();
        mockRandomNumGenerator.Setup(g => g.Generate()).Returns(5);

        var cmdManager = new CommandManager(new Mock<ICommandLogger>().Object);
        var command = new RandAddCommand(mockRandomNumGenerator.Object);

         cmdManager.ExecuteCommand(command);  
        var afterExecute = cmdManager.Result.Result;
        cmdManager.UndoLastCommand();  

         Assert.Equal(0, cmdManager.Result.Result);
    }
}
