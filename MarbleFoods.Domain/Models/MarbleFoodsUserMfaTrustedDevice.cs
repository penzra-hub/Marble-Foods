using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarbleFoods.Domain.Models
{
    public class MarbleFoodsUserMfaTrustedDeviceUserMfaTrustedDevice
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string DeviceIdentifier { get; set; }
        public string DeviceName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public DateTime LastUsedAt { get; set; }
        public string IpAddress { get; set; }
        public string UserAgent { get; set; }
        public bool IsActive { get; set; }
        public MarbleFoodsUser User { get; set; }
    }
}
