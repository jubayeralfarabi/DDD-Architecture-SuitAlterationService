namespace SuitSupply.AlterationService.Application.CommandHandlers
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
            this.logger.LogInformation($"CreateAlterationCommandHandler START with CorrelationId: '{command.CorrelationId}'");

            CommandResponse response = new CommandResponse();

            try
            {
                AlterationAggregate alteration = new AlterationAggregate();

                alteration.CreateAlteration(command.AlterationId, command.AlterationDetails, command.CustomerId, command.CorrelationId);

                await this.aggregateRepository.SaveAsync(alteration).ConfigureAwait(false);

                if (alteration.Events.Any(e => e is FailedToProcessEvent)) response.ValidationResult.AddError("FailedToProcess");

                response.Result = alteration.Events;
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, $"Exception: CreateAlterationCommandHandler with CorrelationId: '{command.CorrelationId}', for alterationid {command.AlterationId}, Message {ex.Message}");

                response.ValidationResult.AddError(ex.Message);
            }

            this.logger.LogInformation($"CreateAlterationCommandHandler END with CorrelationId: '{command.CorrelationId}'");

            return response;
        }
    }
}
