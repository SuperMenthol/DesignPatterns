namespace ProgramNamespace.Dto
{
    public class PurchasingDocumentDto
    {
        public PurchasingDocumentDto()
        {

        }

        public PurchasingDocumentDto(PurchasingDocumentDto original)
        {
            Id = original.Id;
            CreatedAt = original.CreatedAt;
            ConfirmedByCustomer = original.ConfirmedByCustomer;
            PaymentId = original.PaymentId;
            OrderLetterId = original.OrderLetterId;
            DeliveredAt = original.DeliveredAt;
            OperationStatus = original.OperationStatus;
            CustomerId = original.CustomerId;
            Rating = original.Rating;
            RatingDescription = original.RatingDescription;
            OrderItems = original.OrderItems;
        }

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

        public List<PurchasingDocumentItemDto> OrderItems { get; set; }
    }
}