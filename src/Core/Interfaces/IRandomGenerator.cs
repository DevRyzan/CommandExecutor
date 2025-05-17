using System.Numerics;

namespace Services.Interfaces.IRandomGenerator;

    public interface IRandomGenerator
    {
        BigInteger Generate();
    }
