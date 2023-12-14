using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Rating
    {
        public int Id {get; set;}
        public string UserId { get; set; } = "";
        [Required]
        public string BlogId { get; set; } = "";
        [Required]
        public int RatingValue {get; set; }
        public DateTime Timestamp { get; set; }
    }
}