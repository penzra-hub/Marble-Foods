using MarbleFoods.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarbleFoods.Domain.Models
{
    public class MarbleFoodsInventoryBatch
    {
        [Key]
        public Guid BatchId { get; set; }
        public string BatchNumber { get; set; }
        public Guid CommodityId { get; set; }
        public Guid WarehouseId { get; set; }
        public decimal Quantity { get; set; }
        public DateTime ManufactureDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string StorageLocation { get; set; }
        public decimal PurchasePrice { get; set; }
        public ItemStatus Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedByUserId { get; set; }
        public ICollection<MarbleFoodsQualityCheck> QualityChecks { get; set; }
        public ICollection<MarbleFoodsInventoryTransaction> Transactions { get; set; }
        public MarbleFoodsCommodity Commodity { get; set; }
        public MarbleFoodsWarehouse Warehouse { get; set; }
    }
}
