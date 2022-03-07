// <copyright file="CommandHandlerAsync.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.Bus
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using SuitSupply.Platform.Infrastructure.Core.Commands;

    /// <summary>Command handler abstraction.</summary>
    /// <typeparam name="T">Command.</typeparam>
    /// <seealso cref="SuitSupply.Platform.Infrastructure.Core.Commands.ICommandHandlerAsync{T}" />
    public abstract class CommandHandlerAsync<T> : ICommandHandlerAsync<T>
        where T : class, ICommand
    {
        private readonly IServiceProvider serviceProvider;
        private readonly ILogger logger;

        protected CommandHandlerAsync(IServiceProvider serviceProvider, ILogger logger)
        {
            this.serviceProvider = serviceProvider;
            this.logger = logger;
        }

        public abstract Task<CommandResponse> HandleAsync(T command);
    }
}
