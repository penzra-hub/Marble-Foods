using MarbleFoods.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarbleFoods.Domain.Models
{
    public class MarbleFoodsInventoryTransaction
    {
        [Key]
        public Guid TransactionId { get; set; }
        public TransactionType TransactionType { get; set; }
        public Guid BatchId { get; set; }
        public Guid SourceWarehouseId { get; set; }
        public Guid DestinationWarehouseId { get; set; }
        public decimal Quantity { get; set; }
        public string ReferenceNumber { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Notes { get; set; }
        public Guid CreatedByUserId { get; set; }
        public MarbleFoodsInventoryBatch Batch { get; set; }
        public MarbleFoodsWarehouse SourceWarehouse { get; set; }
        public MarbleFoodsWarehouse DestinationWarehouse { get; set; }
        public MarbleFoodsUser CreatedByUser { get; set; }
    }
}
