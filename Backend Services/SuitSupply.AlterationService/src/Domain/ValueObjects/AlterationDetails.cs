using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SuitSupply.AlterationService.Domain.ValueObjects
{
    
    public class AlterationDetails
    {
        [Key]
        public int Id { get; set; }

        public string AlterationName { get; set; }

        public int AlterationValue { get; set; }
    }

    
}
