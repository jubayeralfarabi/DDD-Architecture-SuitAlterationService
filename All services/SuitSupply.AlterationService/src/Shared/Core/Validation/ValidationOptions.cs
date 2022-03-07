// <copyright file="ValidationOptions.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.Validation
{
    /// <summary>Validation Options Model.</summary>
    public class ValidationOptions
    {
        public bool ValidateAllCommands { get; set; } = false;

        public bool ValidateAllQuery { get; set; }
    }
}
