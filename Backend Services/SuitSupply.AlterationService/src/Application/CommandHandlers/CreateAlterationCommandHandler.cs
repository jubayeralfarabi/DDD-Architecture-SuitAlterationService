namespace Suit.AlterationService.Application.CommandHandlers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using Suit.AlterationService.Application.Commands;
    using Suit.Platform.Infrastructure.Core.Commands;
    using Suit.Platform.Infrastructure.Core.Domain;
    using Suit.AlterationService.Domain;
    using Suit.Platform.Infrastructure.Domain;
    using Suit.AlterationService.Domain.Events;
    using Suit.AlterationService.Application.CommandHandlers.Validators;
    using Suit.Platform.Infrastructure.Core.Validation;
    using Suit.AlterationService.Application.CommandHandlers.Helpers;

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
            AlterationAggregate alteration = this.aggregateRepository.GetById(command.AlterationId);

            if (alteration != null) return CommandHandlerHelper.AlterationDoesExistMessage(alteration);

            alteration = new AlterationAggregate();

            alteration.CreateAlteration(command.AlterationId, CommandHandlerHelper.GetAlterationDetails(command.AlterationDetails), command.CustomerId);

            await this.aggregateRepository.SaveAsync(alteration);

            return CommandHandlerHelper.CheckAggregateErrorEvent(alteration);
        }
    }
}
