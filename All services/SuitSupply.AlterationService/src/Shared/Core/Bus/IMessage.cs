// <copyright file="IMessage.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.Bus
{
    using System;
    using SuitSupply.Platform.Infrastructure.Common.Security;

    /// <summary>Message interface.</summary>
    /// <seealso cref="SuitSupply.Platform.Infrastructure.Core.Security.ISecurityInfo" />
    public interface IMessage : ISecurityInfo
    {
        Guid CorrelationId { get; set; }

        Guid ScopeCorrelationId { get; set; }

        DateTime TimeStamp { get; set; }
    }
}
