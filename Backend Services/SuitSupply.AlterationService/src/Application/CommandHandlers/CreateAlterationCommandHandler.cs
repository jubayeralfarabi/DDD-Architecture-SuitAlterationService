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
            this.logger.LogInformation($"CreateAlterationCommandHandler START with AlterationId: '{command.AlterationId}'");

            CommandResponse response = new CommandResponse();

            var validationResult = new CreateAlterationCommandValidator().Validate(command);
            if(!validationResult.IsValid)
            {
                validationResult.Errors.ForEach(e => response.ValidationResult.AddError(e.ErrorMessage));

                this.logger.LogInformation($"CreateAlterationCommandHandler END with AlterationId: '{command.AlterationId}'");

                return response;
            }

            AlterationAggregate alteration = this.aggregateRepository.GetById(command.AlterationId);
                
            if(alteration!= null)
            {
                this.logger.LogInformation($"CreateAlterationCommandHandler END with AlterationId: '{command.AlterationId}'");

                response.ValidationResult.AddError("Alteration Id already exists.");

                return response;
            }

            alteration = new AlterationAggregate();

            alteration.CreateAlteration(command.AlterationId, command.AlterationDetails, command.CustomerId);

            await this.aggregateRepository.SaveAsync(alteration);

            var error = alteration.Events.FirstOrDefault(e => e is AlterationBusinessRuleViolationEvent);
            if (error != null)
            {
                response.ValidationResult.AddError((error as AlterationBusinessRuleViolationEvent).GetMessage());
            }
            
            this.logger.LogInformation($"CreateAlterationCommandHandler END with AlterationId: '{command.AlterationId}'");

            return response;
        }
    }
}
