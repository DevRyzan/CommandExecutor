using Core.Interfaces;
using Core.Models;
using System.Numerics;

namespace Commands.Concretes.DoubleCommand;
/// <summary>
/// doubled the result and undo the changes.
/// </summary>
public class DoubleCommand :ICommand
{  
    private BigInteger _previousValue;



    public void Execute(CommandResult _result)
    {
        _previousValue = _result.Result;
        
        _result.Result *= 2;
    }

    public void Undo(CommandResult _result) => _result.Result = _previousValue;

}