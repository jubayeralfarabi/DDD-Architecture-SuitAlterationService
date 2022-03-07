// <copyright file="IDomainEventProcessor.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.Events
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using SuitSupply.Platform.Infrastructure.Core.Commands;

    /// <summary>Domain Event Processor Interface.</summary>
    public interface IDomainEventProcessor
    {
        Task Process(IEnumerable<IEvent> events, ICommand command);
    }
}
