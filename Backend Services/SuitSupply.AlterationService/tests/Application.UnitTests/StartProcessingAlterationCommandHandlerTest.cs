using Microsoft.Extensions.Logging;
using Moq;
using SuitSupply.AlterationService.Application.CommandHandlers;
using SuitSupply.AlterationService.Application.Commands;
using SuitSupply.AlterationService.Domain;
using SuitSupply.Platform.Infrastructure.Core.Commands;
using SuitSupply.Platform.Infrastructure.Core.Domain;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests
{
    public class StartProcessingAlterationCommandHandlerTest
    {
        private readonly StartProcessingAlterationCommandHandler commandHandler;
        private readonly ILogger<StartProcessingAlterationCommandHandler> logger;
        private readonly IAggregateRepository<AlterationAggregate> aggregateRepository;

        public StartProcessingAlterationCommandHandlerTest()
        {
            this.logger = new Mock<ILogger<StartProcessingAlterationCommandHandler>>().Object;

            this.aggregateRepository = new Mock<IAggregateRepository<AlterationAggregate>>().Object;
            this.commandHandler = new StartProcessingAlterationCommandHandler(this.logger, this.aggregateRepository);
        }

        [Fact]
        public async Task HandleAsync_Failed()
        {
            StartProcessingAlterationCommand command = new StartProcessingAlterationCommand()
            {
            };

            CommandResponse response = await this.commandHandler.HandleAsync(command);

            Assert.False(response.ValidationResult.IsValid);
        }

        [Fact]
        public async Task HandleAsync_Success()
        {
            StartProcessingAlterationCommand command = new StartProcessingAlterationCommand()
            {
                AlterationId = Guid.NewGuid(),
            };

            CommandResponse response = await this.commandHandler.HandleAsync(command);

            Assert.False(response.ValidationResult.IsValid);
        }
    }
}