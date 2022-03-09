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
            this.logger.LogInformation($"DoPaymentCommandHandler START with AlterationId: '{command.AlterationId}'");

            CommandResponse response = new CommandResponse();

            try
            {
                AlterationAggregate alteration = this.aggregateRepository.GetById(command.AlterationId);

                alteration.CompletePayment(command.AlterationId);

                await this.aggregateRepository.UpdateAsync(alteration);

                var error = alteration.Events.FirstOrDefault(e => e is AlterationBusinessRuleViolationEvent);
                if (error != null)
                {
                    response.ValidationResult.AddError((error as AlterationBusinessRuleViolationEvent).GetMessage());
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, $"Exception: DoPaymentCommandHandler for alterationid {command.AlterationId}, Message {ex.Message}");

                response.ValidationResult.AddError(ex.Message);
            }

            this.logger.LogInformation($"DoPaymentCommandHandler END with AlterationId: '{command.AlterationId}'");

            return response;
        }
    }
}
