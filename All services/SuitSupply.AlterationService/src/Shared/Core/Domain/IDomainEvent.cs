// <copyright file="IDomainEvent.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.Domain
{
    using System;
    using SuitSupply.Platform.Infrastructure.Core.Bus;
    using SuitSupply.Platform.Infrastructure.Core.Events;

    /// <summary>Domain Event Interface.</summary>
    /// <seealso cref="SuitSupply.Platform.Infrastructure.Core.Events.IEvent" />
    public interface IDomainEvent : IEvent, IBusTopicMessage
    {
        Guid Id { get; set; }

        Guid AggregateRootId { get; set; }

        int AggregateRootVersion { get; set; }
    }
}
