using APIService.Controllers;
using Microsoft.AspNetCore.Mvc;
using Suit.Infrastructure.ServiceBus;
using Suit.PaymentService.Integration.Events;

namespace MockPaymentService.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MockPriceController : ControllerBase
    {
        private readonly ILogger<MockPriceController> logger;
        private readonly IBusMessagePublisher busMessagePublisher;

        public MockPriceController(
            IBusMessagePublisher busMessagePublisher,
            ILogger<MockPriceController> logger)
        {
            this.logger = logger;
            this.busMessagePublisher = busMessagePublisher;
        }

        [HttpPost]
        public async Task PublishMockOrderPaidEvent(MockOrderPaidCommand command)
        {
            await this.busMessagePublisher.SendAsync(new OrderPaidIntegrationEvent { RefId = command.RefId, OrderId = command.OrderId });
            this.logger.LogInformation($"Order paid event triggered successfully for Refid {command.RefId} OrderId {command.OrderId}." );
        }
    }
}
