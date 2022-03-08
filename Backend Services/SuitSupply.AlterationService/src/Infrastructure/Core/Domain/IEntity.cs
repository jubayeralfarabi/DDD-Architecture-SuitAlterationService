// <copyright file="IEntity.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Domain
{
    using System;

    public interface IEntity
    {
        Guid Id { get; }

        Guid CreatedBy { get; }

        DateTime CreatedDate { get; }

        string Language { get; }

        DateTime LastUpdatedDate { get; }

        Guid LastUpdatedBy { get; }

        Guid TenantId { get; }

        string[] Tags { get; }

        Guid VerticalId { get; }

        bool IsMarkedToDelete { get; }
    }
}
