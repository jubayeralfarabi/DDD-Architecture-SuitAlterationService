// <copyright file="CommandResponse.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.Commands
{
    using System.Collections.Generic;
    using SuitSupply.Platform.Infrastructure.Core.Events;
    using SuitSupply.Platform.Infrastructure.Core.Validation;

    /// <summary>Command response model.</summary>
    public class CommandResponse
    {
        public CommandResponse()
        {
            this.ValidationResult = new ValidationResponse();
        }

        public CommandResponse(ValidationResponse validationResult, object result)
        {
            this.ValidationResult = validationResult;
            this.Result = result;
        }

        public ValidationResponse ValidationResult { get; set; }

        public object Result { get; set; }

        public IEnumerable<IEvent> Events { get; set; }
    }
}
