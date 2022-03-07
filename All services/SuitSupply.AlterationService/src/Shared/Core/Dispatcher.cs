// <copyright file="Dispatcher.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core
{
    using System.Threading.Tasks;
    using SuitSupply.Platform.Infrastructure.Common.Security;
    using SuitSupply.Platform.Infrastructure.Core.Bus;
    using SuitSupply.Platform.Infrastructure.Core.Commands;
    using SuitSupply.Platform.Infrastructure.Core.Events;
    using SuitSupply.Platform.Infrastructure.Core.Queries;

    /// <summary>Dispatcher class to dispatch message.</summary>
    /// <seealso cref="SuitSupply.Platform.Infrastructure.Core.IDispatcher" />
    public class Dispatcher : IDispatcher
    {
        private readonly ICommandSender commandSender;
        private readonly IEventPublisher eventPublisher;
        private readonly IQueryProcessor queryProcessor;
        private readonly IBusMessageDispatcher busMessageDispatcher;
        private readonly IUserContextProvider userContextProvider;

        public Dispatcher(
            ICommandSender commandSender,
            IEventPublisher eventPublisher,
            IQueryProcessor queryProcessor,
            IBusMessageDispatcher busMessageDispatcher,
            IUserContextProvider userContextProvider)
        {
            this.commandSender = commandSender;
            this.eventPublisher = eventPublisher;
            this.queryProcessor = queryProcessor;
            this.busMessageDispatcher = busMessageDispatcher;
            this.userContextProvider = userContextProvider;
        }

        /// <summary>Sends the bus message asynchronous.</summary>
        /// <typeparam name="TMessage">The type of the message.</typeparam>
        /// <param name="message">The message.</param>
        /// <returns>Return Task.</returns>
        public Task SendBusMessageAsync<TMessage>(TMessage message)
            where TMessage : IMessage
        {
            this.SetUserContextWithMessage(message);
            return this.busMessageDispatcher.DispatchAsync(message);
        }

        /// <summary>Publishes the bus message asynchronous.</summary>
        /// <typeparam name="TMessage">The type of the message.</typeparam>
        /// <param name="message">The message.</param>
        /// <returns>Return task.</returns>
        public Task PublishBusMessageAsync<TMessage>(TMessage message)
            where TMessage : IMessage
        {
            this.SetUserContextWithMessage(message);
            return this.busMessageDispatcher.DispatchAsync(message);
        }

        /// <summary>Sends the asynchronous.</summary>
        /// <param name="command">The command.</param>
        /// <returns>Return CommandResponse.</returns>
        public Task<CommandResponse> SendAsync(ICommand command)
        {
            this.SetUserContextWithMessage(command);
            return this.commandSender.SendAsync(command);
        }

        /// <summary>Publishes the asynchronous.</summary>
        /// <typeparam name="TEvent">The type of the event.</typeparam>
        /// <param name="event">The event.</param>
        /// <returns>Return Task.</returns>
        public Task PublishAsync<TEvent>(TEvent @event)
            where TEvent : IEvent
        {
            this.SetUserContextWithMessage(@event);
            return this.eventPublisher.PublishAsync(@event);
        }

        /// <summary>Gets the result asynchronous.</summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="query">The query.</param>
        /// <returns>Return task with passed type.</returns>
        public async Task<QueryResponse<TResult>> GetResultAsync<TResult>(IQuery<TResult> query)
        {
            this.SetUserContextWithMessage(query);
            return await this.queryProcessor.ProcessAsync(query).ConfigureAwait(false);
        }

        /// <summary>Gets the result asynchronous.</summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <returns>Return task with passed type.</returns>
        public async Task<QueryResponse<TResult>> GetResultAsync<TResult>()
        {
            return await this.queryProcessor.ProcessAsync<TResult>().ConfigureAwait(false);
        }

        /// <summary>Sends the specified command.</summary>
        /// <param name="command">The command.</param>
        /// <returns>CommandResponse type.</returns>
        public CommandResponse Send(ICommand command)
        {
            this.SetUserContextWithMessage(command);
            return this.commandSender.Send(command);
        }

        /// <summary>Sends the specified command.</summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="command">The command.</param>
        /// <returns>CommandResponse type.</returns>
        public CommandResponse Send<TResult>(ICommand command)
        {
            this.SetUserContextWithMessage(command);
            return this.commandSender.Send(command);
        }

        /// <summary>Gets the result.</summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="query">The query.</param>
        /// <returns>Return expected model.</returns>
        public QueryResponse<TResult> GetResult<TResult>(IQuery<TResult> query)
        {
            this.SetUserContextWithMessage(query);
            return this.queryProcessor.Process(query);
        }

        /// <summary>Gets the result.</summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <returns>Return expected model.</returns>
        public QueryResponse<TResult> GetResult<TResult>()
        {
            return this.queryProcessor.Process<TResult>();
        }

        /// <summary>Sets the user context with message.</summary>
        /// <param name="message">The message.</param>
        private void SetUserContextWithMessage(ISecurityInfo message)
        {
            message.SetUserContext(this.userContextProvider.GetUserContext());
        }
    }
}