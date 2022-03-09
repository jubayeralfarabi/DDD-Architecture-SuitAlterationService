using FluentValidation;
using SuitSupply.AlterationService.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuitSupply.AlterationService.Application.CommandHandlers.Validators
{
    public class FinishAlterationCommandValidator : AbstractValidator<FinishAlterationCommand>
    {
        public FinishAlterationCommandValidator()
        {
            this.RuleFor(u => u.AlterationId).NotEqual(Guid.Empty).WithMessage("Invalid AlterationId");
        }
    }
}
