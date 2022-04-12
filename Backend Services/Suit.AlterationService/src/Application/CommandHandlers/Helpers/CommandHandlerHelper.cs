using Suit.AlterationService.Application.Commands.Models;
using Suit.AlterationService.Domain;
using Suit.AlterationService.Domain.Entities;
using Suit.AlterationService.Domain.Events;
using Suit.AlterationService.Domain.ValueObjects;
using Suit.Platform.Infrastructure.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suit.AlterationService.Application.CommandHandlers.Helpers
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
