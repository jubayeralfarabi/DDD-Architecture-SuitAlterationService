﻿namespace SuitSupply.DeliveryPlatform.Shop.Applications.CommandHandlers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using SuitSupply.DeliveryPlatform.Shop.Domain.Aggregates;
    using SuitSupply.AlterationService.Application.Commands;
    using SuitSupply.Platform.Infrastructure.Core.Commands;
    using SuitSupply.Platform.Infrastructure.Core.Domain;
    using SuitSupply.Platform.Infrastructure.Domain;

    /// <summary>
    /// Responsible to handle Sample Creation Command request.
    /// </summary>
    public class DoPaymentCommandHandler : ICommandHandlerAsync<DoPaymentCommand>
    {
        private ILogger<DoPaymentCommandHandler> logger;
        private IAggregateRepository<AlterationAggregate> aggregateRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateAlterationCommandHandler"/> class.
        /// </summary>
        /// <param name="logger">Logger instance.</param>
        /// <param name="aggregateRepository"><see cref="IAggregateRepository."/>Aggregate Repository.</param>
        public DoPaymentCommandHandler(
            ILogger<DoPaymentCommandHandler> logger,
            IAggregateRepository<AlterationAggregate> aggregateRepository)
        {
            this.logger = logger;
            this.aggregateRepository = aggregateRepository;
        }

        /// <summary>
        /// Handler.
        /// </summary>
        /// <param name="command"><see cref="CreateAlterationCommand"/>.</param>
        /// <returns>Task of <see cref="CommandResponse"/>.</returns>
        public async Task<CommandResponse> HandleAsync(DoPaymentCommand command)
        {
            this.logger.LogInformation($"DoPaymentCommandHandler START with CorrelationId: '{command.CorrelationId}'");

            CommandResponse response = new CommandResponse();

            try
            {
                AlterationAggregate alteration = this.aggregateRepository.GetById(command.AlterationId);

                alteration.DoPayment(command.AlterationId, command.CorrelationId, command.UserContext);

                await this.aggregateRepository.UpdateAsync(alteration).ConfigureAwait(false);

                if (alteration.Events.Any(e => e is FailedToProcessEvent)) response.ValidationResult.AddError("FailedToProcess");

                response.Result = alteration.Events;
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, $"Exception: DoPaymentCommandHandler with CorrelationId: '{command.CorrelationId}', for alterationid {command.AlterationId}, Message {ex.Message}");

                response.ValidationResult.AddError(ex.Message);
            }

            this.logger.LogInformation($"DoPaymentCommandHandler END with CorrelationId: '{command.CorrelationId}'");

            return response;
        }
    }
}