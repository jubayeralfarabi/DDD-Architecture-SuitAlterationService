namespace Suit.AlterationService.Application.CommandHandlers
{
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using Suit.AlterationService.Application.Commands;
    using Suit.Platform.Infrastructure.Core.Commands;
    using Suit.Platform.Infrastructure.Core.Domain;
    using Suit.AlterationService.Domain;
    using Suit.AlterationService.Application.CommandHandlers.Helpers;

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
