namespace SuitSupply.Platform.Infrastructure.Core.Events
{
    public class Event : IEvent
    {
        public string Source { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
