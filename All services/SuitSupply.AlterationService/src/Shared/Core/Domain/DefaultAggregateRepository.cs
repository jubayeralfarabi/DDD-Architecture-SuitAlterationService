﻿// <copyright file="DefaultAggregateRepository.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

/*
namespace SuitSupply.Platform.Infrastructure.Core.Domain
{
    using System;
    using System.Threading.Tasks;
    using SuitSupply.Platform.Infrastructure.Repository.Contracts;

    /// <summary>Generic domain repository.</summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="SuitSupply.Platform.Infrastructure.Core.Domain.IDomainRepository{T}" />
    public class DefaultAggregateRepository<T> : IAggregateRepository<T>
        where T : IAggregateRoot
    {
        private readonly IRepository repository;
        private readonly IDispatcher dispatcher;

        public DefaultAggregateRepository(IRepository repository, IDispatcher dispatcher)
        {
            this.repository = repository;
            this.dispatcher = dispatcher;
        }

        public Task SaveAsync(T aggregate)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T aggregate)
        {
            throw new NotImplementedException();
        }

        public T GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
*/