using FluentValidation;
using Suit.AlterationService.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suit.AlterationService.Application.CommandHandlers.Validators
{
    public class CompletePaymentCommandValidator : AbstractValidator<CompletePaymentCommand>
    {
        public CompletePaymentCommandValidator()
        {
            this.RuleFor(u => u.AlterationId).NotEqual(Guid.Empty).WithMessage("Invalid AlterationId");
        }
    }
}
