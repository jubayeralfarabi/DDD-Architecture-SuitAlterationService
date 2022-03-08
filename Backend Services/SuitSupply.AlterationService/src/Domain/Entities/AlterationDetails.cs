using Microsoft.EntityFrameworkCore;
using SuitSupply.AlterationService.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace SuitSupply.AlterationService.Domain.Entities
{
    
    public class AlterationDetails
    {
        [Key]
        public int Id { get; set; }

        public AlterationTypeEnum AlterationName { get; set; }

        public int AlterationValue { get; set; }
    }

    
}
