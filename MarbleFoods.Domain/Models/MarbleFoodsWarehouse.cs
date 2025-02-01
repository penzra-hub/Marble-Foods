using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarbleFoods.Domain.Models
{
    public class MarbleFoodsWarehouse
    {
        [Key]
        public Guid WarehouseId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Address { get; set; }
        public decimal TotalCapacity { get; set; }
        public decimal AvailableCapacity { get; set; }
        public bool IsActive { get; set; }
        public Guid CreatedByUserId { get; set; }
        public ICollection<MarbleFoodsInventoryBatch> InventoryBatches { get; set; }
        public ICollection<MarbleFoodsInventoryTransaction> OutboundTransactions { get; set; }
        public ICollection<MarbleFoodsInventoryTransaction> InboundTransactions { get; set; }
    }
}
