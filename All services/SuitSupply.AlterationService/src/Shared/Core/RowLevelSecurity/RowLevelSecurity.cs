// <copyright file="RowLevelSecurity.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.RowLevelSecurity
{
    using System;

    internal class RowLevelSecurity : IRowLevelSecurity
    {
        public string[] RolesAllowedToRead { get; set; }

        public Guid[] IdsAllowedToRead { get; set; }
    }
}
