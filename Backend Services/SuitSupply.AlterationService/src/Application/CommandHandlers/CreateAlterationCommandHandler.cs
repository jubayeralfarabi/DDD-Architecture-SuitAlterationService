﻿namespace SuitSupply.AlterationService.Application.CommandHandlers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using SuitSupply.AlterationService.Application.Commands;
    using SuitSupply.Platform.Infrastructure.Core.Commands;
    using SuitSupply.Platform.Infrastructure.Core.Domain;
    using SuitSupply.AlterationService.Domain;
    using SuitSupply.Platform.Infrastructure.Domain;
    using SuitSupply.AlterationService.Domain.Events;

    public class CreateAlterationCommandHandler : ICommandHandlerAsync<CreateAlterationCommand>
    {
        private ILogger<CreateAlterationCommandHandler> logger;
        private IAggregateRepository<AlterationAggregate> aggregateRepository;

        public CreateAlterationCommandHandler(
            ILogger<CreateAlterationCommandHandler> logger,
            IAggregateRepository<AlterationAggregate> aggregateRepository)
        {
            this.logger = logger;
            this.aggregateRepository = aggregateRepository;
        }

        public async Task<CommandResponse> HandleAsync(CreateAlterationCommand command)
        {
            this.logger.LogInformation($"CreateAlterationCommandHandler START with AlterationId: '{command.AlterationId}'");

            CommandResponse response = new CommandResponse();

            try
            {
                AlterationAggregate alteration = this.aggregateRepository.GetById(command.AlterationId);
                
                if(alteration!= null)
                {
                    this.logger.LogInformation($"CreateAlterationCommandHandler END with AlterationId: '{command.AlterationId}'");

                    response.ValidationResult.AddError("Alteration Id already exists.");

                    return response;
                }

                alteration = new AlterationAggregate();

                alteration.CreateAlteration(command.AlterationId, command.AlterationDetails, command.CustomerId);

                await this.aggregateRepository.SaveAsync(alteration);

                var error = alteration.Events.FirstOrDefault(e => e is AlterationBusinessRuleViolationEvent);
                if (error != null)
                {
                    response.ValidationResult.AddError((error as AlterationBusinessRuleViolationEvent).GetMessage());
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, $"Exception: CreateAlterationCommandHandler for alterationid {command.AlterationId}, Message {ex.Message}");

                response.ValidationResult.AddError(ex.Message);
            }

            this.logger.LogInformation($"CreateAlterationCommandHandler END with AlterationId: '{command.AlterationId}'");

            return response;
        }
    }
}
