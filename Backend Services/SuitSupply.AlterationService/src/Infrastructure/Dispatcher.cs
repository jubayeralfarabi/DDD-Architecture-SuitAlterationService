namespace Suit.Platform.Infrastructure.Core
{
    using System.Threading.Tasks;
    using Suit.Platform.Infrastructure.Core.Commands;
    using Suit.Platform.Infrastructure.Core.Events;

    public class Dispatcher : IDispatcher
    {
        private readonly ICommandSender commandSender;
        private readonly IEventPublisher eventPublisher;

        public Dispatcher(
            ICommandSender commandSender,
            IEventPublisher eventPublisher)
        {
            this.commandSender = commandSender;
            this.eventPublisher = eventPublisher;
        }

        public Task<CommandResponse> SendAsync(Command command)
        {
            return this.commandSender.SendAsync(command);
        }

        public Task PublishAsync<TEvent>(TEvent @event)
            where TEvent : IEvent
        {
            return this.eventPublisher.PublishAsync(@event);
        }
    }
}