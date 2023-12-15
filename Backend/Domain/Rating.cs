using System.ComponentModel.DataAnnotations;
using Domain.Common;

namespace Domain
{
    public class Rating : BaseEntity
    {
        public Guid UserId { get; set; }
        [Required]
        public Guid BlogId { get; set; } 
        [Required]
        public int RatingValue {get; set; }
    }
}