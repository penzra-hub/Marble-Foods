using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarbleFoods.Domain.Models
{
    public class MarbleFoodsPurchaseOrderItem
    {
        [Key]
        public Guid PurchaseOrderItemId { get; set; }
        public Guid PurchaseOrderId { get; set; }
        public Guid CommodityId { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public MarbleFoodsPurchaseOrder PurchaseOrder { get; set; }
    }
}
