namespace SuitSupply.Platform.Infrastructure.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public interface IAggregateRoot
    {
        Guid Id { get; }

        int Version { get; }

        ReadOnlyCollection<IDomainEvent> Events { get; }

        void LoadsFromHistory(IEnumerable<IDomainEvent> events);
    }
}
