namespace Suit.Platform.Infrastructure.Core.Domain
{
    using Suit.Platform.Infrastructure.Core.Events;
    using System;

    public interface IDomainEvent : IEvent
    {
        Guid Id { get; set; }

        Guid AggregateRootId { get; set; }

        int AggregateRootVersion { get; set; }
    }
}
