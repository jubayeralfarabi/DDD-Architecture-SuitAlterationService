// <copyright file="IEntity.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Domain
{
    using System;

    public interface IEntity
    {
        Guid Id { get; }

        DateTime CreatedDate { get; }

        DateTime LastUpdatedDate { get; }
    }
}
