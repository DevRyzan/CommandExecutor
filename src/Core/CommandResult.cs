using System.Numerics;

namespace Core;

public class CommandResult
{
    public BigInteger Result { get; set; } = 0;

    public CommandResult()
    {
        Result = 0;
    }
    public CommandResult(int _result)
    {
        Result = _result;
    }
}