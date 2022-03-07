// <copyright file="CommandSender.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.Commands
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using SuitSupply.Platform.Infrastructure.Common.Security;
    using SuitSupply.Platform.Infrastructure.Core.Dependencies;
    using SuitSupply.Platform.Infrastructure.Core.Events;
    using SuitSupply.Platform.Infrastructure.Core.Validation;

    /// <summary>Command sender class to produce all kind of methods related to send commands.</summary>
    /// <seealso cref="SuitSupply.Platform.Infrastructure.Core.Commands.ICommandSender" />
    public class CommandSender : ICommandSender
    {
        private readonly IHandlerResolver handlerResolver;
        private IUserContextProvider userContextProvider;
        private ILogger logger;

        public CommandSender(
            IHandlerResolver handlerResolver,
            IUserContextProvider userContextProvider,
            ILogger<CommandSender> logger)
        {
            this.handlerResolver = handlerResolver;
            this.userContextProvider = userContextProvider;
            this.logger = logger;
        }

        /// <summary>Sends the asynchronous.</summary>
        /// <typeparam name="TCommand">The type of the command.</typeparam>
        /// <param name="command">The command.</param>
        /// <returns>CommandResponse.</returns>
        /// <exception cref="System.ArgumentNullException">command.</exception>
        public async Task<CommandResponse> SendAsync(ICommand command)
        {
            CommandResponse commandResponse = new CommandResponse();
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            this.SetUserContext(command);

            var handler = this.handlerResolver.ResolveHandler(command, typeof(ICommandHandlerAsync<>));
            var handleMethod = handler.GetType().GetMethod("HandleAsync", new[] { command.GetType() });
            var response = await (Task<CommandResponse>)handleMethod.Invoke(handler, new object[] { command });

            if (response == null)
            {
                return null;
            }

            return new CommandResponse(response.ValidationResult != null ? response.ValidationResult : new ValidationResponse(), response.Result);
        }

        /// <summary>Sets the user context.</summary>
        /// <param name="command">The command.</param>
        private void SetUserContext(ICommand command)
        {
            if (command.UserContext == null)
            {
                command.SetUserContext(this.userContextProvider.GetUserContext());
            }
        }

        /// <summary>Sends the specified command.</summary>
        /// <typeparam name="TCommand">The type of the command.</typeparam>
        /// <param name="command">The command.</param>
        /// <returns>CommandResponse.</returns>
        /// <exception cref="System.ArgumentNullException">command.</exception>
        public CommandResponse Send(ICommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            this.SetUserContext(command);

            var handler = this.handlerResolver.ResolveHandler(command, typeof(ICommandHandler<>));
            var handleMethod = handler.GetType().GetMethod("Handle", new[] { command.GetType() });
            var response = (CommandResponse)handleMethod.Invoke(handler, new object[] { command });

            if (response == null)
            {
                return null;
            }

            return new CommandResponse(response.ValidationResult, response.ValidationResult);
        }
    }
}
