﻿// <copyright file="IDomainRepository.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.Domain
{
    using System;
    using System.Threading.Tasks;
    using SuitSupply.Platform.Infrastructure.Core.Domain;

    /// <summary>Domain Repository Interface.</summary>
    /// <typeparam name="T">Type.</typeparam>
    public interface IDomainRepository<T>
        where T : IAggregateRoot
    {
        Task SaveAsync(T aggregate);

        void Save(T aggregate);

        Task<T> GetByIdAsync(Guid id);

        T GetById(Guid id);
    }
}