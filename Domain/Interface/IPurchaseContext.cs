using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Domain.Interface
{
    public interface IPurchaseContext
    {
        public DbSet<PurchasingDocument> PurchasingDocuments { get; set; }
        public DbSet<PurchasingDocumentItem> PurchasingDocumentItems { get; set; }
        public DbSet<ItemInfo> Items { get; set; }
        public DbSet<PaymentInfo> Payments { get; set; }
        public DbSet<WarehouseState> WarehouseState { get; set; }
    }
}