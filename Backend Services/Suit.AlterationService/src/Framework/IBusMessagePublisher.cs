using Suit.Platform.Infrastructure.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suit.AlterationService.Infrastructure.ServiceBus
{
    public interface IBusMessagePublisher
    {
        public Task SendAsync(object @event);
    }
}
