using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Suit.Infrastructure.ServiceBus;
using Suit.PaymentService.Integration.Events;
using System.Text;

public class BusHostedService : IHostedService
{
    private readonly BusSettings busSettings;
    private readonly ServiceBusClient client;
    private readonly ServiceBusProcessor processor;
    public BusHostedService(IOptions<BusSettings> busSettingsOptions)
    {
        this.busSettings = busSettingsOptions.Value;
        client = new ServiceBusClient(busSettings.ConnectionString);
        processor = client.CreateProcessor(busSettings.TopicName, busSettings.SubscriptionName, new ServiceBusProcessorOptions());
    }

    public Task MessageHandler(ProcessMessageEventArgs args)
    {
        var messageJson = Encoding.UTF8.GetString(args.Message.Body);

        var message = JsonConvert.DeserializeObject<AlterationFinishedIntegrationEvent>(messageJson);

        Console.WriteLine($"Received: {messageJson} from subscription: {busSettings.SubscriptionName} for customer {message.CustomerId}");

        return args.CompleteMessageAsync(args.Message);
    }

    public Task ErrorHandler(ProcessErrorEventArgs args)
    {
        Console.WriteLine(args.Exception.ToString());
        return Task.CompletedTask;
    }


    public async Task StartAsync(CancellationToken cancellationToken)
    {

          this.processor.ProcessMessageAsync += MessageHandler;
          this.processor.ProcessErrorAsync += ErrorHandler;

          await this.processor.StartProcessingAsync();
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
         await this.processor.StopProcessingAsync();
         await this.processor.DisposeAsync();
         await this.client.DisposeAsync();
    }
}