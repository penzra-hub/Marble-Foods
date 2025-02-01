using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarbleFoods.Domain.Models
{
    public class MarbleFoodsCommodity
    {
        [Key]
        public Guid CommodityId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string UnitOfMeasurement { get; set; }
        public decimal MinimumStockLevel { get; set; }
        public decimal MaximumStockLevel { get; set; }
        public bool RequiresQualityCheck { get; set; }

        public bool IsPerishable { get; set; }
        public int ShelfLifeDays { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedByUserId { get; set; }
        public ICollection<MarbleFoodsInventoryBatch> InventoryBatches { get; set; }
        public ICollection<MarbleFoodsQualityParameter> QualityParameters { get; set; }
    }
}
