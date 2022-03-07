// <copyright file="IRowLevelSecurity.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.RowLevelSecurity
{
    using System;

    public interface IRowLevelSecurity
    {
        Guid[] IdsAllowedToRead { get; set; }

        string[] RolesAllowedToRead { get; set; }
    }
}