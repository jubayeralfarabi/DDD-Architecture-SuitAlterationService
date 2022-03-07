// <copyright file="IEvent.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.Events
{
    using SuitSupply.Platform.Infrastructure.Core.Bus;

    /// <summary>Event Interface.</summary>
    /// <seealso cref="SuitSupply.Platform.Infrastructure.Core.Bus.IMessage" />
    public interface IEvent : IMessage
    {
        string Source { get; set; }
    }
}
