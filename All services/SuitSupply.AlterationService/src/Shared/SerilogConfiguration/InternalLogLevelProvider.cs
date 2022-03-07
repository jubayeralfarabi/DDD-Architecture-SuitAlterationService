// <copyright file="InternalLogLevelProvider.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.LogConfiguration.SerilogConfiguration
{
    using System;

    public class InternalLogLevelProvider
    {
        public static LogLevel GetInternalLogLevel(string logLevel)
        {
            try
            {
                switch (logLevel.ToUpper())
                {
                    case Constants.ALL:
                        return LogLevel.ALL;

                    case Constants.DEBUG:
                        return LogLevel.DEBUG;

                    case Constants.INFO:
                        return LogLevel.INFO;

                    case Constants.WARN:
                        return LogLevel.WARN;

                    case Constants.ERROR:
                        return LogLevel.ERROR;

                    case Constants.FATAL:
                        return LogLevel.FATAL;

                    default:
                        throw new ArgumentOutOfRangeException(nameof(logLevel));
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
