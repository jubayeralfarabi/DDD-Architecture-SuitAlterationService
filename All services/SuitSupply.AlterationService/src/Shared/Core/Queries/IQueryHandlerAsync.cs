// <copyright file="IQueryHandlerAsync.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.Queries
{
    using System.Threading.Tasks;

    /// <summary>QueryHandlerAsync Interface.</summary>
    /// <typeparam name="TQuery">The type of the query.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IQueryHandlerAsync<in TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        Task<QueryResponse<TResult>> HandleAsync(TQuery query);
    }
}
