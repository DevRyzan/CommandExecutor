using Commands.Concretes;
using Core.Models;
using Xunit;
namespace App.Tests.Comands;

public class DecrementCmdTest
{
    [Fact]
    public void ExecuteShouldResultByOne()
    {
        
        var cmdResult = new CommandResult { Result = 5 };
        var decrementCmd = new DecrementCommand();

         decrementCmd.Execute(cmdResult);

        Assert.Equal(4, cmdResult.Result);
    }

    [Fact]
    public void UndoShouldUndoResultByOne()
    {
         var cmdResult = new CommandResult { Result = 4 };
        var decrementCmd = new DecrementCommand();

        decrementCmd.Undo(cmdResult);

         Assert.Equal(5, cmdResult.Result);
    }
}
