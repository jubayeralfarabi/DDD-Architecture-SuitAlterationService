// <copyright file="IQueryHandlerAsync{TResult}.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.Queries
{
    using System.Threading.Tasks;

    /// <summary>QueryHandlerAsync Interface.</summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IQueryHandlerAsync<TResult>
    {
        Task<QueryResponse<TResult>> HandleAsync();
    }
}
