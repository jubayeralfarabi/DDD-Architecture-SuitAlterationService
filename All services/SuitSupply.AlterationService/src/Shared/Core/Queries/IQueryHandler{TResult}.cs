// <copyright file="IQueryHandler{TResult}.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.Queries
{
    /// <summary>Query Handler Interface.</summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IQueryHandler<TResult>
    {
        QueryResponse<TResult> Handle();
    }
}
