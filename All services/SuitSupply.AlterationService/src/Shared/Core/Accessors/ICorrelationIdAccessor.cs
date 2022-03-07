// <copyright file="ICorrelationIdAccessor.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.Accessors
{
    using System;

    public interface ICorrelationIdAccessor
    {
        Guid Id { get; set; }

        Guid ScopeId { get; set; }
    }
}
