// <copyright file="IQuery.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.Queries
{
    using SuitSupply.Platform.Infrastructure.Common.Security;

    /// <summary>Query Interface.</summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="SuitSupply.Platform.Infrastructure.Core.Security.ISecurityInfo" />
    public interface IQuery<TResult> : ISecurityInfo
    {
    }
}
