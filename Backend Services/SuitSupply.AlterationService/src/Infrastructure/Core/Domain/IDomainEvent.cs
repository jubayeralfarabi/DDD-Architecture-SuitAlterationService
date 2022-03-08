namespace SuitSupply.Platform.Infrastructure.Core.Domain
{
    using SuitSupply.Platform.Infrastructure.Core.Events;
    using System;

    public interface IDomainEvent : IEvent
    {
        Guid Id { get; set; }

        Guid AggregateRootId { get; set; }

        int AggregateRootVersion { get; set; }
    }
}
