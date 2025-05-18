using Xunit;
using App.Manager;
using Commands.Concretes.IncrementCommand;
using Core.Models;
using Core.Interfaces;
using Moq;

namespace App.Tests.Comands;

public class UndoCmdTest
{
    private readonly Mock<ICommandLogger> _mockLogger;

    public UndoCmdTest()
    {
        _mockLogger = new Mock<ICommandLogger>();
    }

    [Fact]
    public void LastCmdShouldRever()
    {
        var cmdManager = new CommandManager(_mockLogger.Object);
        var incrementCmd = new IncrementCommand();
        cmdManager.ExecuteCommand(incrementCmd);
        cmdManager.UndoLastCommand();

        Assert.Equal(0, cmdManager.Result.Result);
    }

    [Fact]
    public void LastCommandShouldDoNothing()
    {
        var cmdManager = new CommandManager(_mockLogger.Object);

        cmdManager.UndoLastCommand();
        Assert.Equal(0, cmdManager.Result.Result);
    }

}
