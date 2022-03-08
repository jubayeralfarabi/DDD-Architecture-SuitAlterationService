// <copyright file="DomainEvent.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.Domain
{
    using System;
    using SuitSupply.Platform.Infrastructure.Core.Events;

    /// <summary>Domain event abstraction.</summary>
    /// <seealso cref="SuitSupply.Platform.Infrastructure.Core.Events.Event" />
    /// <seealso cref="SuitSupply.Platform.Infrastructure.Core.Domain.IDomainEvent" />
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
