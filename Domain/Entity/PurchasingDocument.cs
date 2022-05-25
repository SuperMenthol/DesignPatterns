namespace Domain.Entity
{
    public class PurchasingDocument
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool ConfirmedByCustomer { get; set; }
        public Guid? PaymentId { get; set; }
        public Guid? OrderLetterId { get; set; }
        public DateTime? DeliveredAt { get; set; }
        public int OperationStatus { get; set; }
        public int CustomerId { get; set; }
        public int? Rating { get; set; }
        public string? RatingDescription { get; set; }

        public List<PurchasingDocumentItem> OrderItems { get; set; }
        public List<PaymentInfo> Payments { get; set; }
    }
}