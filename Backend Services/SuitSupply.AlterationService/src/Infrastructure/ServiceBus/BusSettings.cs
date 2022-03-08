using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuitSupply.AlterationService.Infrastructure.ServiceBus
{
    public class BusSettings
    {
        public string ConnectionString { get; set; }
        public string TopicName { get; set; }

    }
}
