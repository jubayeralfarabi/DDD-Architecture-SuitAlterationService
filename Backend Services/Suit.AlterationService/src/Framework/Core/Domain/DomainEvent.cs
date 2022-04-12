// <copyright file="DomainEvent.cs" company="Suit">
// Copyright © 2015-2020 Suit. All Rights Reserved.
// </copyright>

namespace Suit.Platform.Infrastructure.Core.Domain
{
    using System;
    using Suit.Platform.Infrastructure.Core.Events;

    /// <summary>Domain event abstraction.</summary>
    /// <seealso cref="Suit.Platform.Infrastructure.Core.Events.Event" />
    /// <seealso cref="Suit.Platform.Infrastructure.Core.Domain.IDomainEvent" />
    public abstract class DomainEvent : Event, IDomainEvent
    {
        protected DomainEvent()
        {
            this.Id = Guid.NewGuid();
        }

        private DomainEvent(Guid id)
        {
            this.Id = id;
        }

        public Guid Id { get; set; }

        public Guid AggregateRootId { get; set; }

        public Guid CorrelationId { get; set; }

        public int AggregateRootVersion { get; set; }
    }
}
