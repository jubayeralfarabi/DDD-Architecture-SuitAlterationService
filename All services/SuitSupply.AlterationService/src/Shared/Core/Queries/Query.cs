// <copyright file="Query.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.Queries
{
    using System;
    using SuitSupply.Platform.Infrastructure.Common.Constants;
    using SuitSupply.Platform.Infrastructure.Common.Security;

    /// <summary>Query abstraction class.</summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="SuitSupply.Platform.Infrastructure.Core.Queries.IQuery{TResult}" />
    public abstract class Query<TResult> : IQuery<TResult>
    {
        protected Query()
        {
            this.PageNumber = 1;
            this.PageSize = 10;
            this.DoCount = false;
            this.CorrelationId = Guid.NewGuid();
        }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public bool DoCount { get; set; } = true;

        public UserContext UserContext { get; private set; }

        public void SetUserContext(UserContext userContext)
        {
            this.UserContext = userContext;
        }

        public int Skip => (this.PageNumber - 1) * this.PageSize;

        public int Take => this.PageSize;

        public SuitSupplyVerticalsEnum Vertical { get; set; }

        public Guid CorrelationId { get; set; }
    }
}
