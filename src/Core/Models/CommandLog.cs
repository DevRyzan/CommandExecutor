using System.Numerics;

namespace Core.Models;

public class CommandLog
{
    public string CommandName { get; set; }
    public string CurrentValue { get; set; }
    public DateTime DateTime { get; set; }
}
