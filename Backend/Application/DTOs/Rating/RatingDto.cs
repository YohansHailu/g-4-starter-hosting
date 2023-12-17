namespace Application.DTOs.Rating
{
    public class RatingDto
    {
        public Guid UserId { get; set; }
        public Guid BlogId { get; set; }
        public int RatingValue { get; set; }
    }
}
