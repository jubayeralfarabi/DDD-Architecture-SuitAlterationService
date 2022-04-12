// <copyright file="IEvent.cs" company="Suit">
// Copyright © 2015-2020 Suit. All Rights Reserved.
// </copyright>

namespace Suit.Platform.Infrastructure.Core.Events
{
    /// <summary>Event Interface.</summary>
    /// <seealso cref="Suit.Platform.Infrastructure.Core.Bus.IMessage" />
    public interface IEvent
    {

        string Source { get; set; }

        DateTime TimeStamp { get; set; }
    }
}
