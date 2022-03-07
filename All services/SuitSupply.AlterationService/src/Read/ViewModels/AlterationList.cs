namespace Shohoz.DeliveryPlatform.Shop.Read.ViewModels
{
    using SuitSupply.AlterationService.Domain.ValueObjects;
    using SuitSupply.Platform.Infrastructure.Core.Models;

    public class AlterationList : ViewModelBase
    {
        public AlterationDetails[] AlterationDetails { get; set; }

        public AlterationStatusEnum Status { get; set; }

        public string CustomerId { get; set; }
    }
}
