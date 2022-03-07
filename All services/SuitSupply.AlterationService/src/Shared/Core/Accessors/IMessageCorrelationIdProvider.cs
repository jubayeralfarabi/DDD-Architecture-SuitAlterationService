// <copyright file="IMessageCorrelationIdProvider.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.Accessors
{
    using System;

    public interface IMessageCorrelationIdProvider
    {
        Guid GetMessageCorrelationId();

        Guid GetMessageScopeCorrelationId();
    }
}
