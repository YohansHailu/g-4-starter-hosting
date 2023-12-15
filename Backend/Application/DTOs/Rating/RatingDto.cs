namespace Application.DTOs.Rating
{
    public class RatingDto
    {
        public Guid Id {get; set;}
        public string UserId { get; set; } = "";
        public string BlogId { get; set; } = "";
        public int RatingValue {get; set; }
    }
}