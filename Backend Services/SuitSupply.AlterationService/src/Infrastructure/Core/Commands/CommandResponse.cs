namespace SuitSupply.Platform.Infrastructure.Core.Commands
{
    using System.Collections.Generic;
    using SuitSupply.Platform.Infrastructure.Core.Events;
    using FluentValidation;
    using Shohoz.Platform.Infrastructure.Core.Validation;

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
