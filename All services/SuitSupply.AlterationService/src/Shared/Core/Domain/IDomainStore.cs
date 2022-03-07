// <copyright file="IDomainStore.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>Domain Store Interface.</summary>
    public interface IDomainStore
    {
        void Save(Guid aggregateRootId, IEnumerable<IDomainEvent> events);

        Task SaveAsync(Guid aggregateRootId, IEnumerable<IDomainEvent> events);

        IEnumerable<IDomainEvent> GetEvents(Guid aggregateId);

        Task<IEnumerable<IDomainEvent>> GetEventsAsync(Guid aggregateId);
    }
}
