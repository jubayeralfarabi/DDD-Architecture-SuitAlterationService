// <copyright file="IEvent.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.Events
{
    /// <summary>Event Interface.</summary>
    /// <seealso cref="SuitSupply.Platform.Infrastructure.Core.Bus.IMessage" />
    public interface IEvent
    {

        string Source { get; set; }

        DateTime TimeStamp { get; set; }
    }
}
