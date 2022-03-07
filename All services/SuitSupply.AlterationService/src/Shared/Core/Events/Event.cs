// <copyright file="Event.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.Events
{
    using System;
    using SuitSupply.Platform.Infrastructure.Core.Bus;

    /// <summary>Event Model.</summary>
    /// <seealso cref="SuitSupply.Platform.Infrastructure.Core.Bus.BusTopicMessage" />
    /// <seealso cref="SuitSupply.Platform.Infrastructure.Core.Events.IEvent" />
    public class Event : BusTopicMessage, IEvent
    {
        public string Source { get; set; }
    }
}
