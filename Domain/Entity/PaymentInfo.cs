namespace Domain.Entity
{
    public class PaymentInfo
    {
        public Guid Id { get; set; }
        public int OrderId { get; set; }
        public decimal Amount { get; set; }

        public PurchasingDocument PurchasingDocument { get; set; }
    }
}