// <copyright file="IContextAccessor.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.Accessors
{
    using SuitSupply.Platform.Infrastructure.Core.Models;

    public interface IContextAccessor
    {
        SecurityContext Context { get; set; }
    }
}
