using MarbleFoods.Data.Configurations;
using MarbleFoods.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MarbleFoods.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<MarbleFoodsUser> MarbleFoodsUser { get; set; }
        public DbSet<MarbleFoodsRoles> MarbleFoodsRoles { get; set; }
        //public DbSet<MarbleUserRole> MarbleUserRole { get; set; }
        public DbSet<MarbleFoodsWarehouse> MarbleFoodsWarehouse { get; set; }
        public DbSet<MarbleFoodsCommodity> MarbleFoodsCommodity { get; set; }
        public DbSet<MarbleFoodsInventoryBatch> MarbleFoodsInventoryBatch { get; set; }
        public DbSet<MarbleFoodsQualityParameter> MarbleFoodsQualityParameter { get; set; }
        public DbSet<MarbleFoodsQualityCheck> MarbleFoodsQualityCheck { get; set; }
        public DbSet<MarbleFoodsQualityCheckResult> MarbleFoodsQualityCheckResult { get; set; }
        public DbSet<MarbleFoodsSupplier> MarbleFoodsSupplier { get; set; }
        public DbSet<MarbleFoodsPurchaseOrder> MarbleFoodsPurchaseOrder { get; set; }
        public DbSet<MarbleFoodsPurchaseOrderItem> MarbleFoodsPurchaseOrderItem { get; set; }
        public DbSet<MarbleFoodsInventoryTransaction> MarbleFoodsInventoryTransaction { get; set; }
        public DbSet<MarbleFoodsAuditLog> MarbleFoodsAuditLog { get; set; }
        public DbSet<MarbleFoodsAlert> MarbleFoodsAlert { get; set; }
        public DbSet<MarbleFoodsUserMfaTrustedDeviceUserMfaTrustedDevice> MarbleFoodsUserMfaTrustedDeviceUserMfaTrustedDevice { get; set; }
        public DbSet<MarbleFoodsUserMfaBackupCode> MarbleFoodsUserMfaBackupCode { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply configurations
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new WarehouseConfiguration());
            modelBuilder.ApplyConfiguration(new CommodityConfiguration());
            modelBuilder.ApplyConfiguration(new InventoryBatchConfiguration());
            modelBuilder.ApplyConfiguration(new QualityCheckConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierConfiguration());
            modelBuilder.ApplyConfiguration(new PurchaseOrderConfiguration());
            modelBuilder.ApplyConfiguration(new AuditLogConfiguration());
            modelBuilder.ApplyConfiguration(new UserMfaTrustedDeviceConfiguration());
        }
    }
}
