namespace Suit.Infrastructure.ServiceBus
{
    public class BusSettings
    {
        public string ConnectionString { get; set; }
        public string TopicName { get; set; }
        public string SubscriptionName { get; set; }

    }
}
