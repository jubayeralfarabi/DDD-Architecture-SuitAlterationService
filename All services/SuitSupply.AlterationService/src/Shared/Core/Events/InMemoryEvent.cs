namespace Shohoz.Platform.Infrastructure.Core.Events
{
    using Shohoz.Platform.Infrastructure.Core.Bus;

    public class InMemoryEvent : Message, IEvent
    {
        public string Source { get; set; }
    }

}
