namespace Domain.Entity
{
    public class ItemInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }

        public List<PurchasingDocumentItem> PurchasePositions { get; set; }
    }
}