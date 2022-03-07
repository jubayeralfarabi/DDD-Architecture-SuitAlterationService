// <copyright file="Message.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.Bus
{
    using System;
    using System.Collections.Generic;
    using SuitSupply.Platform.Infrastructure.Common.Security;

    /// <summary>Message abstract class.</summary>
    /// <seealso cref="SuitSupply.Platform.Infrastructure.Core.Bus.IMessage" />
    public abstract class Message : IMessage
    {
        public DateTime? ScheduledEnqueueTimeUtc { get; set; }

        public IDictionary<string, object> Properties { get; set; }

        public UserContext UserContext { get; private set; }

        public Guid CorrelationId { get; set; }

        public Guid ScopeCorrelationId { get; set; }

        public void SetUserContext(UserContext userContext) => this.UserContext = userContext;

        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
    }
}
