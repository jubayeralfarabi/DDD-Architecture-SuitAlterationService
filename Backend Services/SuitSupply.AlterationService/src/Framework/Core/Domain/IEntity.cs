// <copyright file="IEntity.cs" company="Suit">
// Copyright © 2015-2020 Suit. All Rights Reserved.
// </copyright>

namespace Suit.Platform.Infrastructure.Domain
{
    using System;

    public interface IEntity
    {
        Guid Id { get; }

        DateTime CreatedDate { get; }

        DateTime LastUpdatedDate { get; }
    }
}
