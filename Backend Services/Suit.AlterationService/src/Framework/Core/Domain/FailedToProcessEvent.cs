namespace Suit.Platform.Infrastructure.Domain
{
    using System;
    using Suit.Platform.Infrastructure.Core.Domain;

    /// <summary>Event for Agent Creation.</summary>
    public abstract class FailedToProcessEvent : DomainEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FailedToProcessEvent"/> class.
        /// </summary>
        /// <param name="dto">dto</param>
        public FailedToProcessEvent(string exception = null)
        {
            if(exception != null) this.Exception = exception;
        }

        public string Exception { get; set; }

        public abstract string GetMessage();
    }
}
