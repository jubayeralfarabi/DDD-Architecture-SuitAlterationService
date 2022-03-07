// <copyright file="EventPublisher.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.Events
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using SuitSupply.Platform.Infrastructure.Common.Security;
    using SuitSupply.Platform.Infrastructure.Core.Bus;
    using SuitSupply.Platform.Infrastructure.Core.Dependencies;

    /// <summary>Class to publish events.</summary>
    /// <seealso cref="SuitSupply.Platform.Infrastructure.Core.Events.IEventPublisher" />
    public class EventPublisher : IEventPublisher
    {
        private readonly IBusMessageDispatcher busMessageDispatcher;
        private readonly IHandlerResolver handlerResolver;
        private UserContext userContext;

        public EventPublisher(IBusMessageDispatcher busMessageDispatcher, UserContext userContext, IHandlerResolver handlerResolver)
        {
            this.busMessageDispatcher = busMessageDispatcher;
            this.handlerResolver = handlerResolver;
            this.userContext = userContext;
        }

        /// <summary>Publishes the asynchronous.</summary>
        /// <typeparam name="TEvent">The type of the event.</typeparam>
        /// <param name="event">The event.</param>
        /// <exception cref="ArgumentNullException">event.</exception>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task PublishAsync<TEvent>(TEvent @event)
            where TEvent : IEvent
        {
            if (@event == null)
            {
                throw new ArgumentNullException(nameof(@event));
            }

            this.userContext = @event.UserContext;

            var handler = this.handlerResolver.ResolveHandler<IEventHandlerAsync<TEvent>>();
            await handler.HandleAsync(@event);

            if (@event is IBusTopicMessage message)
            {
                await this.busMessageDispatcher.DispatchAsync(message);
            }
        }

        /// <summary>Publishes the asynchronous.</summary>
        /// <typeparam name="TEvent">The type of the event.</typeparam>
        /// <param name="events">The events.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task PublishAsync<TEvent>(IEnumerable<TEvent> events)
            where TEvent : IEvent
        {
            foreach (var @event in events)
            {
                await this.PublishAsync(@event);
            }
        }
    }
}
