namespace SuitSupply.AlterationService.Application.CommandHandlers
{
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using SuitSupply.AlterationService.Application.Commands;
    using SuitSupply.Platform.Infrastructure.Core.Commands;
    using SuitSupply.Platform.Infrastructure.Core.Domain;
    using SuitSupply.AlterationService.Domain;
    using SuitSupply.AlterationService.Application.CommandHandlers.Helpers;

    public class FinishAlterationCommandHandler : ICommandHandlerAsync<FinishAlterationCommand>
    {
        private ILogger<FinishAlterationCommandHandler> logger;
        private IAggregateRepository<AlterationAggregate> aggregateRepository;

        public FinishAlterationCommandHandler(
            ILogger<FinishAlterationCommandHandler> logger,
            IAggregateRepository<AlterationAggregate> aggregateRepository)
        {
            this.logger = logger;
            this.aggregateRepository = aggregateRepository;
        }

        public async Task<CommandResponse> HandleAsync(FinishAlterationCommand command)
        {
            this.logger.LogInformation($"FinishAlterationCommandHandler START with AlterationId: '{command.AlterationId}'");

            AlterationAggregate alteration = this.aggregateRepository.GetById(command.AlterationId);

            if (alteration == null) return CommandHandlerHelper.AlterationDoesNotExistMessage(alteration);

            alteration.FinishAlteration(command.AlterationId);

            await this.aggregateRepository.UpdateAsync(alteration);

            return CommandHandlerHelper.CheckAggregateErrorEvent(alteration);
        }
    }
}
