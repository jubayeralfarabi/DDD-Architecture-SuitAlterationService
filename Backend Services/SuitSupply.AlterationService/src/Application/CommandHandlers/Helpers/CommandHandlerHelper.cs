using SuitSupply.AlterationService.Application.Commands.Models;
using SuitSupply.AlterationService.Domain;
using SuitSupply.AlterationService.Domain.Entities;
using SuitSupply.AlterationService.Domain.Events;
using SuitSupply.AlterationService.Domain.ValueObjects;
using SuitSupply.Platform.Infrastructure.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuitSupply.AlterationService.Application.CommandHandlers.Helpers
{
    public static class CommandHandlerHelper
    {
        public static CommandResponse CheckAggregateErrorEvent(AlterationAggregate alteration)
        {
            CommandResponse response = new CommandResponse();
            var error = alteration.Events.FirstOrDefault(e => e is AlterationBusinessRuleViolationEvent);
            if (error != null)
            {
                response.ValidationResult.AddError((error as AlterationBusinessRuleViolationEvent).GetMessage());
            }
            return response;
        }

        public static CommandResponse AlterationDoesNotExistMessage(AlterationAggregate alteration)
        {
            CommandResponse response = new CommandResponse();

            response.ValidationResult.AddError("Alteration does not exist.");

            return response;
        }

        public static CommandResponse AlterationDoesExistMessage(AlterationAggregate alteration)
        {
            CommandResponse response = new CommandResponse();

            response.ValidationResult.AddError("Alteration Id already exists.");

            return response;
        }


        public static AlterationDetails[] GetAlterationDetails(AlterationDetailsApplication[] alteration)
        {
            return alteration.Select(a=> new AlterationDetails { AlterationName = (AlterationTypeEnum)Enum.Parse(typeof(AlterationTypeEnum),a.AlterationName.ToString()), AlterationValue = a.AlterationValue}).ToArray();
        }
    }
}
