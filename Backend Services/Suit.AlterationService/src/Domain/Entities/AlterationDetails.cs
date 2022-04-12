using Microsoft.EntityFrameworkCore;
using Suit.AlterationService.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Suit.AlterationService.Domain.Entities
{
    
    public class AlterationDetails
    {
        [Key]
        public int Id { get; set; }

        public AlterationTypeEnum AlterationName { get; set; }

        public int AlterationValue { get; set; }
    }

    
}
