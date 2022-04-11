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
    using SuitSupply.AlterationService.Domain.Events;
    using SuitSupply.AlterationService.Application.CommandHandlers.Validators;
    using SuitSupply.Platform.Infrastructure.Core.Validation;
    using SuitSupply.AlterationService.Application.CommandHandlers.Helpers;

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
