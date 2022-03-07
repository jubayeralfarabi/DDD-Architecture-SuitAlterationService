﻿// <copyright file="QueryHandlerWrapper{TResult}.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.Queries
{
    using System.Threading.Tasks;
    using SuitSupply.Platform.Infrastructure.Core.Dependencies;

    /// <summary>Query Handler Wrapper Class.</summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="SuitSupply.Platform.Infrastructure.Core.Queries.BaseQueryHandlerWrapperNoParam{TResult}" />
    internal class QueryHandlerWrapper<TResult> : BaseQueryHandlerWrapperNoParam<TResult>
    {
        /// <summary>Handles the asynchronous.</summary>
        /// <param name="handlerResolver">The handler resolver.</param>
        /// <returns>Passed Type.</returns>
        public override Task<QueryResponse<TResult>> HandleAsync(IHandlerResolver handlerResolver)
        {
            var handler = GetHandler<IQueryHandlerAsync<TResult>>(handlerResolver);
            return handler.HandleAsync();
        }

        /// <summary>Handles the specified query.</summary>
        /// <param name="handlerResolver">The handler resolver.</param>
        /// <returns>Passed Type.</returns>
        public override QueryResponse<TResult> Handle(IHandlerResolver handlerResolver)
        {
            var handler = GetHandler<IQueryHandler<TResult>>(handlerResolver);
            return handler.Handle();
        }
    }
}
