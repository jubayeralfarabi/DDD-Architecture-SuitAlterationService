using Microsoft.Extensions.Logging;
using Moq;
using Suit.AlterationService.Application.CommandHandlers;
using Suit.AlterationService.Application.Commands;
using Suit.AlterationService.Domain;
using Suit.AlterationService.Domain.Entities;
using Suit.AlterationService.Domain.ValueObjects;
using Suit.Platform.Infrastructure.Core.Commands;
using Suit.Platform.Infrastructure.Core.Domain;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests
{
    public class CompletePaymentCommandHandlerTest
    {
        private readonly CompletePaymentCommandHandler commandHandler;
        private readonly ILogger<CompletePaymentCommandHandler> logger;
        private readonly IAggregateRepository<AlterationAggregate> aggregateRepository;

        public CompletePaymentCommandHandlerTest()
        {
            this.logger = new Mock<ILogger<CompletePaymentCommandHandler>>().Object;

            this.aggregateRepository = new Mock<IAggregateRepository<AlterationAggregate>>().Object;
            this.commandHandler = new CompletePaymentCommandHandler(this.logger, this.aggregateRepository);
        }

        [Fact]
        public async Task HandleAsync_Failed()
        {
            CompletePaymentCommand command = new CompletePaymentCommand()
            {
            };

            CommandResponse response = await this.commandHandler.HandleAsync(command);

            Assert.False(response.ValidationResult.IsValid);
        }


        [Fact]
        public async Task HandleAsync_Success()
        {
            CompletePaymentCommand command = new CompletePaymentCommand()
            {
                AlterationId = Guid.NewGuid(),
            };

            CommandResponse response = await this.commandHandler.HandleAsync(command);

            Assert.False(response.ValidationResult.IsValid);
        }
    }
}