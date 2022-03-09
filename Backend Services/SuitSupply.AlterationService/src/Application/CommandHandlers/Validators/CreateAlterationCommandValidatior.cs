using FluentValidation;
using SuitSupply.AlterationService.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuitSupply.AlterationService.Application.CommandHandlers.Validators
{
    public class CreateAlterationCommandValidator : AbstractValidator<CreateAlterationCommand>
    {
        public CreateAlterationCommandValidator()
        {
            this.RuleFor(u => u.CustomerId).NotEmpty().WithMessage("Invalid CustomerId");
            this.RuleFor(u => u.AlterationDetails).NotNull().WithMessage("AlterationDetails must have an element");
            When(u => u.AlterationDetails != null, () => { 
                this.RuleFor(a => a.AlterationDetails.Length).GreaterThan(0).WithMessage("AlterationDetails must have an element");
            });
            this.RuleFor(u => u.AlterationId).NotEqual(Guid.Empty).WithMessage("Invalid AlterationId");
        }
    }
}
