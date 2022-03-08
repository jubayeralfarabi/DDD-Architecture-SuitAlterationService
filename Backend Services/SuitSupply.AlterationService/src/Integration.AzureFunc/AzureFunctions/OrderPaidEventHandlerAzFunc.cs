using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using SuitSupply.AlterationService.Application.Commands;
using SuitSupply.Platform.Infrastructure.Core;
using SuitSupply.PaymentService.Integration.Events;

namespace SuitSupply.AlterationService.Integration.AzureFunc
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
        public Task Run([ServiceBusTrigger("order-integration", "alteration-orderPaidEventHandler", Connection = "BusConnectionString")] OrderPaidIntegrationEvent @event)
        {
            this.logger.LogInformation($"Received order paid event from az bus");
            return this.dispatcher.SendAsync(new CompletePaymentCommand { AlterationId = @event.RefId });
        }
    }
}
