// <copyright file="Program.cs" company="SuitSupply">
// Copyright SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.AlterationService.Application.CommandWebHost
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Hosting;
    using Serilog;
    using SuitSupply.Platform.Infrastructure.Host.WebApi.Constants;
    using SuitSupply.Platform.Infrastructure.LogConfiguration.SerilogConfiguration;

    [ExcludeFromCodeCoverage]
    public class Program
    {
        public static void Main(string[] args)
        {
            IConfigurationRoot configurationRoot = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable(EnvironmentConstants.AspnetcoreEnvironmentVariableName)}.json")
                .Build();

            SeriLogConfiguration logConfig = new SeriLogConfiguration(configurationRoot).UseConsole().UseAppInSight().Initiate();

            try
            {
                Log.Information("Application Starting.");

                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception e)
            {
                Log.Fatal(e, "The Application failed to start.");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
