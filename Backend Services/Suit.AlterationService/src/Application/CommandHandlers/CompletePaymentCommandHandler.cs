namespace Suit.AlterationService.Application.CommandHandlers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using Suit.AlterationService.Application.Commands;
    using Suit.Platform.Infrastructure.Core.Commands;
    using Suit.Platform.Infrastructure.Core.Domain;
    using Suit.Platform.Infrastructure.Domain;
    using Suit.AlterationService.Domain;
    using Suit.AlterationService.Domain.Events;
    using Suit.AlterationService.Application.CommandHandlers.Validators;
    using Suit.AlterationService.Application.CommandHandlers.Helpers;

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
