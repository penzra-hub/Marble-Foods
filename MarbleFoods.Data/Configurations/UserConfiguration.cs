using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MarbleFoods.Domain.Models;

namespace MarbleFoods.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<MarbleFoodsUser>
    {
        public void Configure(EntityTypeBuilder<MarbleFoodsUser> builder)
        {
            builder.HasKey(u => u.UserId);

            builder.Property(u => u.Username).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
            builder.Property(u => u.PasswordHash).IsRequired();

            // Relationships
            //builder.HasMany(u => u.UserRoles)
            //      .WithOne(ur => ur.User)
            //      .HasForeignKey(ur => ur.UserId)
            //      .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.CreatedTransactions)
                  .WithOne(t => t.CreatedByUser)
                  .HasForeignKey(t => t.CreatedByUserId)
                  .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.QualityChecks)
                  .WithOne(qc => qc.PerformedByUser)
                  .HasForeignKey(qc => qc.PerformedByUserId)
                  .OnDelete(DeleteBehavior.Restrict);
        }
    }

    public class RoleConfiguration : IEntityTypeConfiguration<MarbleFoodsRoles>
    {
        public void Configure(EntityTypeBuilder<MarbleFoodsRoles> builder)
        {
            builder.HasKey(r => r.RoleId);
            builder.Property(r => r.Name).IsRequired().HasMaxLength(50);

            // Relationships
            //builder.HasMany(r => r.UserRoles)
            //      .WithOne(ur => ur.Role)
            //      .HasForeignKey(ur => ur.RoleId);
        }
    }

    public class WarehouseConfiguration : IEntityTypeConfiguration<MarbleFoodsWarehouse>
    {
        public void Configure(EntityTypeBuilder<MarbleFoodsWarehouse> builder)
        {
            builder.HasKey(w => w.WarehouseId);
            builder.Property(w => w.Name).IsRequired().HasMaxLength(100);
            builder.Property(w => w.Location).IsRequired().HasMaxLength(200);

            // Constraints
            //builder.HasCheckConstraint("CHK_Capacity", "AvailableCapacity <= TotalCapacity");

            // Relationships
            builder.HasMany(w => w.InventoryBatches)
                  .WithOne(b => b.Warehouse)
                  .HasForeignKey(b => b.WarehouseId);

            builder.HasMany(w => w.OutboundTransactions)
                  .WithOne(t => t.SourceWarehouse)
                  .HasForeignKey(t => t.SourceWarehouseId)
                  .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(w => w.InboundTransactions)
                  .WithOne(t => t.DestinationWarehouse)
                  .HasForeignKey(t => t.DestinationWarehouseId)
                  .OnDelete(DeleteBehavior.Restrict);
        }
    }

    public class CommodityConfiguration : IEntityTypeConfiguration<MarbleFoodsCommodity>
    {
        public void Configure(EntityTypeBuilder<MarbleFoodsCommodity> builder)
        {
            builder.HasKey(c => c.CommodityId);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
            builder.Property(c => c.UnitOfMeasurement).IsRequired().HasMaxLength(20);

            // Relationships
            builder.HasMany(c => c.InventoryBatches)
                  .WithOne(b => b.Commodity)
                  .HasForeignKey(b => b.CommodityId);

            builder.HasMany(c => c.QualityParameters)
                  .WithMany(qp => qp.Commodities);
                  //.UsingEntity<MarbleFoodsQualityParameter>(
                  //    j => j.HasOne(cqp => cqp.QualityParameter)
                  //         .WithMany()
                  //         .HasForeignKey(cqp => cqp.ParameterId),
                  //    j => j.HasOne(cqp => cqp.Commodity)
                  //         .WithMany()
                  //         .HasForeignKey(cqp => cqp.CommodityId)
                  //);
        }
    }

    public class InventoryBatchConfiguration : IEntityTypeConfiguration<MarbleFoodsInventoryBatch>
    {
        public void Configure(EntityTypeBuilder<MarbleFoodsInventoryBatch> builder)
        {
            builder.HasKey(b => b.BatchId);
            builder.Property(b => b.BatchNumber).IsRequired().HasMaxLength(50);
            builder.Property(b => b.Quantity).HasPrecision(18, 4);

            // Constraints
            //builder.HasCheckConstraint("CHK_Quantity", "Quantity >= 0");
            //builder.HasCheckConstraint("CHK_ExpiryDate", "ManufactureDate < ExpirationDate");

            // Relationships
            builder.HasMany(b => b.QualityChecks)
                  .WithOne(qc => qc.Batch)
                  .HasForeignKey(qc => qc.BatchId);

            builder.HasMany(b => b.Transactions)
                  .WithOne(t => t.Batch)
                  .HasForeignKey(t => t.BatchId);
        }
    }

    public class QualityCheckConfiguration : IEntityTypeConfiguration<MarbleFoodsQualityCheck>
    {
        public void Configure(EntityTypeBuilder<MarbleFoodsQualityCheck> builder)
        {
            builder.HasKey(qc => qc.QualityCheckId);
            builder.Property(qc => qc.QualityStatus).IsRequired().HasMaxLength(20);

            // Relationships
            builder.HasMany(qc => qc.Results)
                  .WithOne(r => r.QualityCheck)
                  .HasForeignKey(r => r.QualityCheckId);
        }
    }

    public class SupplierConfiguration : IEntityTypeConfiguration<MarbleFoodsSupplier>
    {
        public void Configure(EntityTypeBuilder<MarbleFoodsSupplier> builder)
        {
            builder.HasKey(s => s.SupplierId);
            builder.Property(s => s.Name).IsRequired().HasMaxLength(100);
            builder.Property(s => s.Email).HasMaxLength(100);
            builder.Property(s => s.Phone).HasMaxLength(20);

            // Relationships
            builder.HasMany(s => s.PurchaseOrders)
                  .WithOne(po => po.Supplier)
                  .HasForeignKey(po => po.SupplierId);
        }
    }

    public class PurchaseOrderConfiguration : IEntityTypeConfiguration<MarbleFoodsPurchaseOrder>
    {
        public void Configure(EntityTypeBuilder<MarbleFoodsPurchaseOrder> builder)
        {
            builder.HasKey(po => po.PurchaseOrderId);
            builder.Property(po => po.OrderNumber).IsRequired().HasMaxLength(50);
            builder.Property(po => po.PurchaseStatus).IsRequired().HasMaxLength(20);
            builder.Property(po => po.TotalAmount).HasPrecision(18, 4);

            // Constraints
            //builder.HasCheckConstraint("CHK_OrderDates", "OrderDate <= ExpectedDeliveryDate");

            // Relationships
            builder.HasMany(po => po.Items)
                  .WithOne(poi => poi.PurchaseOrder)
                  .HasForeignKey(poi => poi.PurchaseOrderId);
        }
    }

    public class AuditLogConfiguration : IEntityTypeConfiguration<MarbleFoodsAuditLog>
    {
        public void Configure(EntityTypeBuilder<MarbleFoodsAuditLog> builder)
        {
            builder.HasKey(al => al.AuditLogId);
            builder.Property(al => al.Action).IsRequired().HasMaxLength(50);
            builder.Property(al => al.EntityName).IsRequired().HasMaxLength(50);
            builder.Property(al => al.IpAddress).HasMaxLength(50);

            // Index for faster querying
            builder.HasIndex(al => al.Timestamp);
            builder.HasIndex(al => al.EntityName);
        }
    }

    public class UserMfaTrustedDeviceConfiguration : IEntityTypeConfiguration<MarbleFoodsUserMfaTrustedDeviceUserMfaTrustedDevice>
    {
        public void Configure(EntityTypeBuilder<MarbleFoodsUserMfaTrustedDeviceUserMfaTrustedDevice> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.DeviceIdentifier)
                   .IsRequired()
                   .HasMaxLength(256);

            builder.Property(d => d.DeviceName)
                   .HasMaxLength(100);

            builder.Property(d => d.IpAddress)
                   .HasMaxLength(45);  // To accommodate IPv6 addresses

            builder.Property(d => d.UserAgent)
                   .HasMaxLength(500);

            // Relationship with User
            builder.HasOne(d => d.User)
                   .WithMany(u => u.TrustedDevices)
                   .HasForeignKey(d => d.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Index for faster lookups
            builder.HasIndex(d => new { d.UserId, d.DeviceIdentifier });
            builder.HasIndex(d => d.ExpiresAt);
        }
    }
}
