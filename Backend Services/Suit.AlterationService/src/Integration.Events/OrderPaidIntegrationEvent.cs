namespace Suit.PaymentService.Integration.Events
{
    public class OrderPaidIntegrationEvent
    {
        public Guid OrderId { get; set; }

        /// <summary>
        /// In our Alteration Id
        /// </summary>
        public Guid RefId { get; set; }
    }
}