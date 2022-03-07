// <copyright file="Command.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.Commands
{
    using SuitSupply.Platform.Infrastructure.Core.Bus;

    /// <summary>Command abstraction.</summary>
    /// <seealso cref="SuitSupply.Platform.Infrastructure.Core.Bus.BusQueueMessage" />
    /// <seealso cref="SuitSupply.Platform.Infrastructure.Core.Commands.ICommand" />
    public abstract class Command : BusQueueMessage, ICommand
    {
        public bool? PublishEvents { get; set; } = false;

        public bool? ValidateCommand { get; set; }
    }
}
