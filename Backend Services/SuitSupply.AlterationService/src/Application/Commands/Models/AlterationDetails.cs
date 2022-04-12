using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suit.AlterationService.Application.Commands.Models
{
    public class AlterationDetailsApplication
    {
        public int Id { get; set; }

        public AlterationTypeApplicationEnum AlterationName { get; set; }

        public int AlterationValue { get; set; }
    }
}
