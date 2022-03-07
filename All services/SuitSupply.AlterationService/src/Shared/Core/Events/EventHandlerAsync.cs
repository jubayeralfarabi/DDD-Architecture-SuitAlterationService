// <copyright file="EventHandlerAsync.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.Bus
{
    using System;
    using System.Threading.Tasks;
    using SuitSupply.Platform.Infrastructure.Core.Events;

    /// <summary>Event Handler Abastraction Class.</summary>
    /// <typeparam name="T">Type.</typeparam>
    /// <seealso cref="SuitSupply.Platform.Infrastructure.Core.Events.IEventHandlerAsync{T}" />
    public abstract class EventHandlerAsync<T> : IEventHandlerAsync<T>
        where T : class, IEvent
    {
        protected EventHandlerAsync(IServiceProvider serviceProvider)
        {
        }

        public abstract Task HandleAsync(T @event);
    }
}
