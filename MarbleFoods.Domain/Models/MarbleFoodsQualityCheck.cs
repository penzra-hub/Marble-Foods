using MarbleFoods.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarbleFoods.Domain.Models
{
    public class MarbleFoodsQualityCheck
    {
        [Key]
        public Guid QualityCheckId { get; set; }
        public Guid BatchId { get; set; }
        public DateTime CheckDate { get; set; }
        public QualityStatus QualityStatus { get; set; }
        public string Notes { get; set; }
        public Guid PerformedByUserId { get; set; }
        public ICollection<MarbleFoodsQualityCheckResult> Results { get; set; }
        public MarbleFoodsInventoryBatch Batch { get; set; }
        public MarbleFoodsUser PerformedByUser { get; set; }
    }
}
