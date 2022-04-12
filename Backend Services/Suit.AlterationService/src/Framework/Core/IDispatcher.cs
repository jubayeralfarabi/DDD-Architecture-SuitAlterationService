namespace Suit.Platform.Infrastructure.Core
{
    using System.Threading.Tasks;
    using Suit.Platform.Infrastructure.Core.Commands;
    using Suit.Platform.Infrastructure.Core.Events;

    public interface IDispatcher
    {
        Task PublishAsync<TEvent>(TEvent @event)
            where TEvent : IEvent;

        Task<CommandResponse> SendAsync(Command command);
    }
}
