namespace Suit.Platform.Infrastructure.Core.Commands
{
    using System.Collections.Generic;
    using Suit.Platform.Infrastructure.Core.Events;
    using FluentValidation;
    using Suit.Platform.Infrastructure.Core.Validation;

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
    }
}
