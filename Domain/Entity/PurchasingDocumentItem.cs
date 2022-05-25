namespace Domain.Entity
{
    public class PurchasingDocumentItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }

        public ItemInfo ItemInfo { get; set; }
    }
}