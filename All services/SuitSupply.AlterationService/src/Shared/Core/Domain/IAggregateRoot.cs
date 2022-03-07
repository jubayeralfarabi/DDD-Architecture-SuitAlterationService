// <copyright file="IAggregateRoot.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    /// <summary>Aggregate root interface.</summary>
    public interface IAggregateRoot
    {
        Guid Id { get; }

        int Version { get; }

        ReadOnlyCollection<IDomainEvent> Events { get; }

        void LoadsFromHistory(IEnumerable<IDomainEvent> events);
    }
}
