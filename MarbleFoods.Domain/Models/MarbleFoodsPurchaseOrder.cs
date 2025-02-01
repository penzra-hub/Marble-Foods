using MarbleFoods.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarbleFoods.Domain.Models
{
    public class MarbleFoodsPurchaseOrder
    {
        [Key]
        public Guid PurchaseOrderId { get; set; }
        public string OrderNumber { get; set; }
        public Guid SupplierId { get; set; }
        public MarbleFoodsSupplier Supplier { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ExpectedDeliveryDate { get; set; }
        public PurchaseStatus PurchaseStatus { get; set; }
        public decimal TotalAmount { get; set; }
        public string Notes { get; set; }
        public Guid CreatedByUserId { get; set; }
        public ICollection<MarbleFoodsPurchaseOrderItem> Items { get; set; }
    }
}
