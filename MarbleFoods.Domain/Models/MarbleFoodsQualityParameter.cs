using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarbleFoods.Domain.Models
{
    public class MarbleFoodsQualityParameter
    {
        [Key]
        public Guid ParameterId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UnitOfMeasurement { get; set; }
        public decimal MinimumValue { get; set; }
        public decimal MaximumValue { get; set; }
        public bool IsRequired { get; set; }
        public ICollection<MarbleFoodsCommodity> Commodities { get; set; }
    }
}
