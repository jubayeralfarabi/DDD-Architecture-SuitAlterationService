using Microsoft.Extensions.Logging;
using Moq;
using SuitSupply.AlterationService.Application.CommandHandlers;
using SuitSupply.AlterationService.Application.Commands;
using SuitSupply.AlterationService.Domain;
using SuitSupply.AlterationService.Domain.Entities;
using SuitSupply.AlterationService.Domain.ValueObjects;
using SuitSupply.Platform.Infrastructure.Core.Commands;
using SuitSupply.Platform.Infrastructure.Core.Domain;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests
{
    public class CreateAlterationCommandHandlerTest
    {
        public AlterationDetails[] ValidAlterationDetails => new AlterationDetails[] { new AlterationDetails() { AlterationName = AlterationTypeEnum.SleeveRight, AlterationValue = 1, Id = 0 } };
        public const string customerId = "customer";
        private readonly CreateAlterationCommandHandler commandHandler;
        private readonly ILogger<CreateAlterationCommandHandler> logger;
        private readonly IAggregateRepository<AlterationAggregate> aggregateRepository;

        public CreateAlterationCommandHandlerTest()
        {
            this.logger = new Mock<ILogger<CreateAlterationCommandHandler>>().Object;

            this.aggregateRepository = new Mock<IAggregateRepository<AlterationAggregate>>().Object;
            this.commandHandler = new CreateAlterationCommandHandler(this.logger, this.aggregateRepository);
        }

        [Fact]
        public async Task HandleAsync_Success()
        {
            CreateAlterationCommand command = new CreateAlterationCommand()
            {
                AlterationDetails = ValidAlterationDetails,
                AlterationId = Guid.NewGuid(),
                CustomerId = customerId,
            };

            CommandResponse response = await this.commandHandler.HandleAsync(command);

            Assert.True(response.ValidationResult.IsValid);
        }

        [Fact]
        public async Task HandleAsync_Failed()
        {
            CreateAlterationCommand command = new CreateAlterationCommand()
            {
            };

            CommandResponse response = await this.commandHandler.HandleAsync(command);

            Assert.False(response.ValidationResult.IsValid);
        }
    }
}