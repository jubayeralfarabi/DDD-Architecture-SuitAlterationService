// <copyright file="MessageCorrelationIdProvider.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.Accessors
{
    using System;
    using SuitSupply.Platform.Infrastructure.Core;

    public class MessageCorrelationIdProvider : IMessageCorrelationIdProvider
    {
        private readonly ICorrelationIdAccessor correlationIdAccessor;

        public MessageCorrelationIdProvider(ICorrelationIdAccessor correlationIdAccessor)
        {
            this.correlationIdAccessor = correlationIdAccessor;
        }

        public Guid GetMessageCorrelationId()
        {
            return this.correlationIdAccessor.Id;
        }

        public Guid GetMessageScopeCorrelationId()
        {
            return this.correlationIdAccessor.ScopeId;
        }
    }
}
