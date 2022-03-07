// <copyright file="SeriLogConfiguration.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.LogConfiguration.SerilogConfiguration
{
    using System;
    using Microsoft.Extensions.Configuration;
    using Serilog;

    /// <summary>Configure Serilog.</summary>
    public class SeriLogConfiguration
    {
        private readonly IConfiguration configuration;

        /// <summary>Initializes a new instance of the <see cref="SeriLogConfiguration"/> class.</summary>
        public SeriLogConfiguration(IConfigurationRoot config)
        {
            this.LoggerConfiguration = new LoggerConfiguration();
            this.configuration = config;
        }

        /// <summary>Gets the logger configuration.</summary>
        /// <value>The logger configuration.</value>
        private LoggerConfiguration LoggerConfiguration { get; }

        /// <summary>Add WriteToConsole configuration in LoggerConfiguration.</summary>
        /// <param name="layOut">The lay out.</param>
        /// <param name="logLevel">The log level.</param>
        /// <returns>It returns current SeriLogConfiguration.</returns>
        public SeriLogConfiguration UseConsole(string layOut = "", LogLevel logLevel = LogLevel.INFO)
        {
            layOut = this.GetLayout(layOut);
            this.LoggerConfiguration.WriteTo.Async(a => a.Console(outputTemplate: layOut, restrictedToMinimumLevel: SeriLogLevelProvider.GetLogLevel(logLevel)));
            return this;
        }

        /// <summary>Uses the application in sight.</summary>
        /// <param name="logLevel">The log level.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public SeriLogConfiguration UseAppInSight(LogLevel logLevel = LogLevel.INFO)
        {
            this.LoggerConfiguration.WriteTo.Async(a => a.ApplicationInsightsEvents(this.configuration["ApplicationInsightsInstrumentationKey"], restrictedToMinimumLevel: SeriLogLevelProvider.GetLogLevel(logLevel)));
            return this;
        }

        /// <summary>Creates Logger from the LogConfiguration.</summary>
        /// <returns>It returns current SeriLogConfiguration.</returns>
        public SeriLogConfiguration Initiate()
        {
            this.LoggerConfiguration.MinimumLevel.Debug();
            this.LoggerConfiguration.Enrich.WithCorrelationId();
            Log.Logger = this.LoggerConfiguration.CreateLogger();
            return this;
        }

        /// <summary>
        /// It checks if any layout is provided otherwise returns default layout from log setting.
        /// </summary>
        /// <param name="layOut">layout patterns passed to the method. </param>
        /// <returns> Return log layout.</returns>
        private string GetLayout(string layOut)
        {
            layOut = string.IsNullOrEmpty(layOut) ? "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {Message}{NewLine}{Exception}" : layOut;
            return layOut;
        }
    }
}
