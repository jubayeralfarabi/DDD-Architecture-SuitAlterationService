// <copyright file="CommandResponseWithEvents.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.Commands
{
    using System.Collections.Generic;
    using SuitSupply.Platform.Infrastructure.Core.Events;
    using SuitSupply.Platform.Infrastructure.Core.Validation;

    /// <summary>Command response model with events.</summary>
    public class CommandResponseWithEvents
    {
        public ValidationResponse ValidationResult { get; set; }

        public object Result { get; set; }

        public IEnumerable<IEvent> Events { get; set; }
    }
}
