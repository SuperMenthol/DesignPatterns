using Domain.Entity;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public class PurchaseContext : DbContext, IPurchaseContext
    {
        public DbSet<PurchasingDocument> PurchasingDocuments { get; set; }
        public DbSet<PurchasingDocumentItem> PurchasingDocumentItems { get; set; }
        public DbSet<ItemInfo> Items { get; set; }
        public DbSet<PaymentInfo> Payments { get; set; }
        public DbSet<WarehouseState> WarehouseState { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PurchasingDocument>().ToTable("PurchasingDocuments").HasKey(x => x.Id);
            modelBuilder.Entity<PurchasingDocumentItem>().ToTable("PurchasingDocumentItems").HasKey(x => x.Id);
            modelBuilder.Entity<ItemInfo>().ToTable("Items").HasKey(x => x.Id);
            modelBuilder.Entity<PaymentInfo>().ToTable("Payments").HasKey(x => x.Id);
            modelBuilder.Entity<WarehouseState>().ToTable("WarehouseState").HasKey(x => x.ItemId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["PurchaseEntities"].ConnectionString); // idk why, but it's null
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-NPC8O49\\SOL; Initial Catalog=CommandFactory; Integrated Security=true; MultipleActiveResultSets=true");
            }
        }

        public PurchaseContext()
        {

        }

        public PurchaseContext(DbContextOptions<PurchaseContext> options) : base(options)
        {

        }
    }
}