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

            try
            {
                AlterationAggregate alteration = this.aggregateRepository.GetById(command.AlterationId);

                alteration.StartProcessing(command.AlterationId);

                await this.aggregateRepository.UpdateAsync(alteration);

                var error = alteration.Events.FirstOrDefault(e => e is AlterationBusinessRuleViolationEvent);
                if (error!=null) 
                { 
                    response.ValidationResult.AddError((error as AlterationBusinessRuleViolationEvent).GetMessage());
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, $"Exception: StartProcessingAlterationCommandHandler for alterationid {command.AlterationId}, Message {ex.Message}");

                response.ValidationResult.AddError(ex.Message);
            }

            this.logger.LogInformation($"StartProcessingAlterationCommandHandler END with AlterationId: '{command.AlterationId}'");

            return response;
        }
    }
}
