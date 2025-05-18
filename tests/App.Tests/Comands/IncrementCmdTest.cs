using Xunit;
using Core;
using Commands.Concretes.IncrementCommand;
using Core.Models;

namespace App.Tests.Comands;

public class IncrementCmdTest
{
    [Fact]
    public void ExecuteShouldResultByOne()
    {
        var incrementCmd = new IncrementCommand();
        var result = new CommandResult { Result = 10 };

        incrementCmd.Execute(result);

        
        Assert.Equal(11, result.Result);
    }

    [Fact]
    public void UndoShouldUndoResultByOne()
    {
        var incrementCmd = new IncrementCommand();
        var result = new CommandResult { Result = 10 };

        incrementCmd.Undo(result);

        Assert.Equal(9, result.Result);
    }
}
