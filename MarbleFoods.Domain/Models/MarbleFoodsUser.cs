using MarbleFoods.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarbleFoods.Domain.Models
{
    public class MarbleFoodsUser
    {
        [Key]
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Avatar { get; set; }
        public Gender Gender { get; set; }
        public bool IsActive { get; set; }
        public UserStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public bool RequiresMFA { get; set; }
        public Guid UserRole { get; set; }
        public ICollection<MarbleFoodsInventoryTransaction> CreatedTransactions { get; set; }
        public ICollection<MarbleFoodsQualityCheck> QualityChecks { get; set; }
        public ICollection<MarbleFoodsUserMfaTrustedDeviceUserMfaTrustedDevice> TrustedDevices { get; set; }
    }
}
