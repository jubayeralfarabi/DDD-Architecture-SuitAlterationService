namespace Suit.Infrastructure.ServiceBus
{
    public interface IBusMessagePublisher
    {
        public Task SendAsync(object @event);
    }
}
