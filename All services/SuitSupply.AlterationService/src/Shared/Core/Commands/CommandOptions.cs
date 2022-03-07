// <copyright file="CommandOptions.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.Commands
{
    public class CommandOptions
    {
        /// <summary>
        /// Gets or sets a value indicating whether the value indicating whether events are published automatically. Default value is true.
        /// </summary>
        public bool PublishEvents { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether the value indicating whether commands are saved alongside events. Default value is true.
        /// </summary>
        public bool SaveCommandData { get; set; } = false;
    }
}
