// <copyright file="HandlerResolver.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.Dependencies
{
    using System;
    using System.Linq;

    /// <summary>HandlerResolver class.</summary>
    /// <seealso cref="SuitSupply.Platform.Infrastructure.Core.Dependencies.IHandlerResolver" />
    public class HandlerResolver : IHandlerResolver
    {
        private readonly IResolver resolver;

        public HandlerResolver(IResolver resolver)
        {
            this.resolver = resolver;
        }

        public THandler ResolveHandler<THandler>()
        {
            var handler = this.resolver.Resolve<THandler>();

            if (handler == null)
            {
                //throw new HandlerNotFoundException(typeof(THandler));
            }

            return handler;
        }

        /// <summary>Resolves the handler.</summary>
        /// <param name="handlerType">Type of the handler.</param>
        /// <returns>object.</returns>
        public object ResolveHandler(Type handlerType)
        {
            var handler = this.resolver.Resolve(handlerType);

            return handler;
        }

        /// <summary>Resolves the handler.</summary>
        /// <param name="param">The parameter.</param>
        /// <param name="type">The type.</param>
        /// <returns>object.</returns>
        public object ResolveHandler(object param, Type type)
        {
            var paramType = param.GetType();
            var handlerType = type.MakeGenericType(paramType);
            return this.ResolveHandler(handlerType);
        }

        /// <summary>Resolves the query handler.</summary>
        /// <param name="query">The query.</param>
        /// <param name="type">The type.</param>
        /// <returns>object.</returns>
        public object ResolveQueryHandler(object query, Type type)
        {
            var queryType = query.GetType();
            var queryInterface = queryType.GetInterfaces()[0];
            var resultType = queryInterface.GetGenericArguments().FirstOrDefault();
            var handlerType = type.MakeGenericType(queryType, resultType);
            return this.ResolveHandler(handlerType);
        }
    }
}