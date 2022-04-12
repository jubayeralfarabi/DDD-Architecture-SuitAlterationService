using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Suit.AlterationService.Application.Commands;
using Suit.Platform.Infrastructure.Core;
using Suit.PaymentService.Integration.Events;
using Newtonsoft.Json;

namespace Suit.AlterationService.Integration.AzureFunc
{
    public class OrderPaidEventHandlerAzFunc
    {
        private readonly ILogger<OrderPaidEventHandlerAzFunc> logger;
        private readonly IDispatcher dispatcher;
        public OrderPaidEventHandlerAzFunc(ILogger<OrderPaidEventHandlerAzFunc> log, IDispatcher dispatcher)
        {
            this.logger = log;
            this.dispatcher = dispatcher;
        }

        [FunctionName("OrderPaidEventHandler")]
        public Task Run([ServiceBusTrigger("order-integration", "alteration-orderPaidEventHandler", Connection = "BusConnectionString")] string message)
        {
            var @event = JsonConvert.DeserializeObject<OrderPaidIntegrationEvent>(message);
            this.logger.LogInformation($"Received order paid event from az bus");
            return this.dispatcher.SendAsync(new CompletePaymentCommand { AlterationId = @event.RefId });
        }
    }
}
