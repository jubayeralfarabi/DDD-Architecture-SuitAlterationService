// <copyright file="DomainEventProcessor.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.Events
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using SuitSupply.Platform.Infrastructure.Common.Security;
    using SuitSupply.Platform.Infrastructure.Core.Commands;
    using SuitSupply.Platform.Infrastructure.Core.Domain;

    /// <summary>Domain Event Processor to process all events and store in EventStore.</summary>
    /// <seealso cref="SuitSupply.Platform.Infrastructure.Core.Events.IDomainEventProcessor" />
    public class DomainEventProcessor : IDomainEventProcessor
    {
        private readonly IDomainStore domainStore;
        private readonly IEventPublisher eventPublisher;
        private readonly UserContext userContext;

        public DomainEventProcessor(IDomainStore domainStore, IEventPublisher eventPublisher, UserContext userContext)
        {
            this.domainStore = domainStore;
            this.eventPublisher = eventPublisher;
            this.userContext = userContext;
        }

        /// <summary>Processes the specified events.</summary>
        /// <param name="events">The events.</param>
        /// <param name="command">The command.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task Process(IEnumerable<IEvent> events, ICommand command)
        {
            try
            {
                if (events == null || !events.Any())
                {
                    return;
                }

                var domainEvents = (IEnumerable<IDomainEvent>)events;
                await this.Store(domainEvents);
                await this.PublishToBus(domainEvents, command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Stores the specified events.</summary>
        /// <param name="events">The events.</param>
        /// <returns>Task.</returns>
        public Task Store(IEnumerable<IDomainEvent> events)
        {
            foreach (var @event in events)
            {
                if (@event.UserContext == null)
                {
                    @event.SetUserContext(this.userContext);
                }
            }

            var aggregateDetail = events.First();
            return this.domainStore.SaveAsync(aggregateDetail.AggregateRootId, events);
        }

        /// <summary>Publishes to bus.</summary>
        /// <param name="events">The events.</param>
        /// <param name="command">The command.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task PublishToBus(IEnumerable<IDomainEvent> events, ICommand command)
        {
            if (!command.PublishEvents.HasValue)
            {
                return;
            }

            foreach (var @event in events)
            {
                await this.eventPublisher.PublishAsync(@event);
            }
        }
    }
}
