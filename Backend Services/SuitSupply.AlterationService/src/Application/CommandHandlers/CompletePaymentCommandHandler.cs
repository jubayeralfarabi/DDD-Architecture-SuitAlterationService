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
    using SuitSupply.AlterationService.Application.CommandHandlers.Helpers;

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
            AlterationAggregate alteration = this.aggregateRepository.GetById(command.AlterationId);

            if (alteration == null) return CommandHandlerHelper.AlterationDoesNotExistMessage(alteration);

            alteration.CompletePayment(command.AlterationId);

            await this.aggregateRepository.UpdateAsync(alteration);

            return CommandHandlerHelper.CheckAggregateErrorEvent(alteration);
        }
    }
}
