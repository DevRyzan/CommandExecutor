using Core;
using Core.Interfaces;
using Services.Interfaces.IRandomGenerator;
using System.Numerics;

namespace Commands.Concretes.RandAddCommand;

public class RandAddCommand : ICommand
{ 
    private readonly IRandomGenerator _randomGenerator;
    private BigInteger _generatedValue;

    public RandAddCommand(IRandomGenerator randomGenerator)
    {
        _randomGenerator = randomGenerator;
    }

    public string Name => throw new System.NotImplementedException();

    public void Execute(CommandResult _result){
        _generatedValue =_randomGenerator.Generate();
        _result.Result +=_generatedValue; 
    }

    public void Undo(CommandResult _result) => _result.Result-=_generatedValue;
}