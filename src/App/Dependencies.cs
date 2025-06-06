﻿using App.Manager;
using Core.Factory;
using Core.Interfaces;
using Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces.IRandomGenerator;



namespace App;
/// <summary>
/// Configures and registers dependencies for DI container used from program.cs
/// </summary>
public static class Dependencies
{
    public static void Configure(IServiceCollection services)
    {
        services.AddSingleton<IRandomGenerator, RandomGenerator>();
        services.AddSingleton<ICommandLogger, CommandLogger>();
        services.AddSingleton<ICommandFactory, CommandFactory>();
        services.AddSingleton<CommandManager>();
    }
}
