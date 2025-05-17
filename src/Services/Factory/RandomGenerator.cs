using Services.Interfaces.IRandomGenerator;
using System;

namespace Services.Factory;

public class RandomGenerator : IRandomGenerator
{
    private readonly Random _random;

    public RandomGenerator()
    {
        _random = new Random();  
    }

    public int Generate() => _random.Next(int.MinValue, int.MaxValue);
   
}