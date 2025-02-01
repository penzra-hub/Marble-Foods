using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarbleFoods.Domain.Models
{
    public class MarbleFoodsUserMfaBackupCode
    {
        [Key]
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public string Code { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UsedAt { get; set; }
        public string? UsedFromIpAddress { get; set; }
        public bool IsUsed { get; set; }
        public MarbleFoodsUser MarbleFoodsUser { get; set; }
    }
}
