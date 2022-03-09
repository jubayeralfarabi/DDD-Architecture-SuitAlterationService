namespace SuitSupply.AlterationService.Application.CommandHandlers
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

    public class StartProcessingAlterationCommandHandler : ICommandHandlerAsync<StartProcessingAlterationCommand>
    {
        private ILogger<StartProcessingAlterationCommandHandler> logger;
        private IAggregateRepository<AlterationAggregate> aggregateRepository;

        public StartProcessingAlterationCommandHandler(
            ILogger<StartProcessingAlterationCommandHandler> logger,
            IAggregateRepository<AlterationAggregate> aggregateRepository)
        {
            this.logger = logger;
            this.aggregateRepository = aggregateRepository;
        }

        public async Task<CommandResponse> HandleAsync(StartProcessingAlterationCommand command)
        {
            this.logger.LogInformation($"StartProcessingAlterationCommandHandler START with AlterationId: '{command.AlterationId}'");

            CommandResponse response = new CommandResponse();

            var validationResult = new StartProcessingAlterationCommandValidator().Validate(command);
            if (!validationResult.IsValid)
            {
                validationResult.Errors.ForEach(e => response.ValidationResult.AddError(e.ErrorMessage));

                this.logger.LogInformation($"StartProcessingAlterationCommandValidator END with AlterationId: '{command.AlterationId}'");

                return response;
            }

            AlterationAggregate alteration = this.aggregateRepository.GetById(command.AlterationId);

            if (alteration == null)
            {
                response.ValidationResult.AddError("Alteration does not exist.");

                this.logger.LogInformation($"StartProcessingAlterationCommandValidator END with AlterationId: '{command.AlterationId}'");

                return response;
            }

            alteration.StartProcessing(command.AlterationId);

            await this.aggregateRepository.UpdateAsync(alteration);

            var error = alteration.Events.FirstOrDefault(e => e is AlterationBusinessRuleViolationEvent);
            if (error!=null) 
            { 
                response.ValidationResult.AddError((error as AlterationBusinessRuleViolationEvent).GetMessage());
            }
            
            this.logger.LogInformation($"StartProcessingAlterationCommandHandler END with AlterationId: '{command.AlterationId}'");

            return response;
        }
    }
}
