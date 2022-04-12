using Microsoft.Extensions.Logging;
using Moq;
using Suit.AlterationService.Application.CommandHandlers;
using Suit.AlterationService.Application.Commands;
using Suit.AlterationService.Domain;
using Suit.Platform.Infrastructure.Core.Commands;
using Suit.Platform.Infrastructure.Core.Domain;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests
{
    public class FinishAlterationCommandHandlerTest
    {
        private readonly FinishAlterationCommandHandler commandHandler;
        private readonly ILogger<FinishAlterationCommandHandler> logger;
        private readonly IAggregateRepository<AlterationAggregate> aggregateRepository;

        public FinishAlterationCommandHandlerTest()
        {
            this.logger = new Mock<ILogger<FinishAlterationCommandHandler>>().Object;

            this.aggregateRepository = new Mock<IAggregateRepository<AlterationAggregate>>().Object;
            this.commandHandler = new FinishAlterationCommandHandler(this.logger, this.aggregateRepository);
        }

        [Fact]
        public async Task HandleAsync_Failed()
        {
            FinishAlterationCommand command = new FinishAlterationCommand()
            {
            };

            CommandResponse response = await this.commandHandler.HandleAsync(command);

            Assert.False(response.ValidationResult.IsValid);
        }

        [Fact]
        public async Task HandleAsync_Success()
        {
            FinishAlterationCommand command = new FinishAlterationCommand()
            {
                AlterationId = Guid.NewGuid(),
            };

            CommandResponse response = await this.commandHandler.HandleAsync(command);

            Assert.False(response.ValidationResult.IsValid);
        }
    }
}