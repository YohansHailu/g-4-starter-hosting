namespace Application.DTOs.Rating;

public class CreateRatingDto
{
    
        public Guid UserId { get; set; }
        public Guid BlogId { get; set; }
        public int RatingValue { get; set; }
}