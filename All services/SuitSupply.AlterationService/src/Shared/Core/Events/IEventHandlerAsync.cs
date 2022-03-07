// <copyright file="IEventHandlerAsync.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.Events
{
    using System.Threading.Tasks;

    /// <summary>Event handler async interface.</summary>
    /// <typeparam name="TEvent">The type of the event.</typeparam>
    public interface IEventHandlerAsync<in TEvent>
        where TEvent : IEvent
    {
        Task HandleAsync(TEvent @event);
    }
}
