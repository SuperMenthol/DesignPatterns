namespace ProgramNamespace.Dto
{
    public class PurchasingDocumentItemDto
    {
        public int OrderPositionId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public ItemInfoDto ItemInfo { get; set; }

        public decimal GetTotalPrice() => ItemInfo.UnitPrice * Quantity;
    }
}