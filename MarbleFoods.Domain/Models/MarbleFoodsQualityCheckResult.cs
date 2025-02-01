using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarbleFoods.Domain.Models
{
    public class MarbleFoodsQualityCheckResult
    {
        [Key]
        public Guid ResultId { get; set; }
        public Guid QualityCheckId { get; set; }
        public Guid ParameterId { get; set; }
        public decimal Value { get; set; }
        public bool PassedCheck { get; set; }
        public MarbleFoodsQualityCheck QualityCheck { get; set; }
    }
}
