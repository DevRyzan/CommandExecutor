using Services.Interfaces.IRandomGenerator;
using System;
using System.Numerics;

namespace Core.Factory;

public class RandomGenerator : IRandomGenerator
{
    private readonly Random _random;

    public RandomGenerator()
    {
        _random = new Random();
    }
    public BigInteger Generate()
    {
        byte[] bytes = new byte[16]; 
        new Random().NextBytes(bytes);
        return new BigInteger(bytes);
    }

}