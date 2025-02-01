using MarbleFoods.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace MarbleFoods.Domain.Models
{
    public class MarbleFoodsAlert
    {
        [Key]
        public Guid AlertId { get; set; }
        public AlertType AlertType { get; set; }
        public string Message { get; set; }
        public Severity Severity { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid? RelatedEntityId { get; set; }
        public string RelatedEntityType { get; set; }
        public Guid? AssignedToUserId { get; set; }
    }
}
