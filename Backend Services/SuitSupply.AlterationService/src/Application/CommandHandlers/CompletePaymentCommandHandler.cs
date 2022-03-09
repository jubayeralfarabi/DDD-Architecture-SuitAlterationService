﻿namespace SuitSupply.AlterationService.Application.CommandHandlers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using SuitSupply.AlterationService.Application.Commands;
    using SuitSupply.Platform.Infrastructure.Core.Commands;
    using SuitSupply.Platform.Infrastructure.Core.Domain;
    using SuitSupply.Platform.Infrastructure.Domain;
    using SuitSupply.AlterationService.Domain;
    using SuitSupply.AlterationService.Domain.Events;
    using SuitSupply.AlterationService.Application.CommandHandlers.Validators;

    public class CompletePaymentCommandHandler : ICommandHandlerAsync<CompletePaymentCommand>
    {
        private ILogger<CompletePaymentCommandHandler> logger;
        private IAggregateRepository<AlterationAggregate> aggregateRepository;

        public CompletePaymentCommandHandler(
            ILogger<CompletePaymentCommandHandler> logger,
            IAggregateRepository<AlterationAggregate> aggregateRepository)
        {
            this.logger = logger;
            this.aggregateRepository = aggregateRepository;
        }

        public async Task<CommandResponse> HandleAsync(CompletePaymentCommand command)
        {
            this.logger.LogInformation($"DoPaymentCommandHandler START with AlterationId: '{command.AlterationId}'");

            CommandResponse response = new CommandResponse();

            var validationResult = new CompletePaymentCommandValidator().Validate(command);
            if (!validationResult.IsValid)
            {
                validationResult.Errors.ForEach(e => response.ValidationResult.AddError(e.ErrorMessage));

                this.logger.LogInformation($"CompletePaymentCommandValidator END with AlterationId: '{command.AlterationId}'");

                return response;
            }

            AlterationAggregate alteration = this.aggregateRepository.GetById(command.AlterationId);

            if (alteration == null)
            {
                response.ValidationResult.AddError("Alteration does not exist.");

                this.logger.LogInformation($"CompletePaymentCommandValidator END with AlterationId: '{command.AlterationId}'");

                return response;
            }

            alteration.CompletePayment(command.AlterationId);

            await this.aggregateRepository.UpdateAsync(alteration);

            var error = alteration.Events.FirstOrDefault(e => e is AlterationBusinessRuleViolationEvent);
            if (error != null)
            {
                response.ValidationResult.AddError((error as AlterationBusinessRuleViolationEvent).GetMessage());
            }
            
            this.logger.LogInformation($"DoPaymentCommandHandler END with AlterationId: '{command.AlterationId}'");

            return response;
        }
    }
}
